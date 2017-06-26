/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * RDP
 *
 * Copyright 2011-2012 Marc-Andre Moreau <marcandre.moreau@gmail.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using FreeRDP.Exceptions;
using FreeRDP.Utils;

namespace FreeRDP.Core
{	
	public unsafe class RDP : IDisposable
	{
		private static class NativeMethods
		{
			[DllImport("libfreerdp-core", CallingConvention = CallingConvention.Cdecl)]
			public static extern void freerdp_context_new(freerdp* instance);

			[DllImport("libfreerdp-core", CallingConvention = CallingConvention.Cdecl)]
			public static extern void freerdp_context_free(freerdp* instance);

			[DllImport("libfreerdp-core", CallingConvention = CallingConvention.Cdecl)]
			public static extern int freerdp_connect(freerdp* instance);

			[DllImport("libfreerdp-core", CallingConvention = CallingConvention.Cdecl)]
			public static extern int freerdp_disconnect(freerdp* instance);

			[DllImport("libfreerdp-core", CallingConvention = CallingConvention.Cdecl)]
			public static extern int freerdp_check_fds(freerdp* instance);

			[DllImport("libfreerdp-core", CallingConvention = CallingConvention.Cdecl)]
			public static extern freerdp* freerdp_new();

			[DllImport("libfreerdp-core", CallingConvention = CallingConvention.Cdecl)]
			public static extern void freerdp_free(freerdp* instance);

			[DllImport("libfreerdp-core", CallingConvention = CallingConvention.Cdecl)]
			public static extern void freerdp_input_send_synchronize_event(IntPtr input, UInt32 flags);

			[DllImport("libfreerdp-core", CallingConvention = CallingConvention.Cdecl)]
			public static extern void freerdp_input_send_keyboard_event(IntPtr input, UInt16 flags, UInt16 code);

			[DllImport("libfreerdp-core", CallingConvention = CallingConvention.Cdecl)]
			public static extern void freerdp_input_send_unicode_keyboard_event(IntPtr input, UInt16 flags, UInt16 code);

			[DllImport("libfreerdp-core", CallingConvention = CallingConvention.Cdecl)]
			public static extern void freerdp_input_send_mouse_event(IntPtr input, UInt16 flags, UInt16 x, UInt16 y);

			[DllImport("libfreerdp-core", CallingConvention = CallingConvention.Cdecl)]
			public static extern void freerdp_input_send_extended_mouse_event(IntPtr input, UInt16 flags, UInt16 x, UInt16 y);

			[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool SetDllDirectory(string lpPathName);
		}

		private static int _winsock = -1;

		private freerdp* _freerdp;
		private IntPtr _input;
		private rdpContext* _context;
		private rdpSettings* _settings;
		private volatile bool  _connected;
		
		private IUpdate _iUpdate;
		private IPrimaryUpdate _iPrimaryUpdate;
		private ISecondaryUpdate _iSecondaryUpdate;
		private IAltSecUpdate _iAltSecUpdate;
		
		//we need to keep references to prevent GC
		private readonly pContextNew _hContextNew;
		private readonly pContextFree _hContextFree;
		private pPreConnect _hPreConnect;
		private pPostConnect _hPostConnect;
		private readonly pAuthenticate _hAuthenticate;
		private readonly pVerifyCertificate _hVerifyCertificate;
		private readonly TerminateEventHandlerDelegate _terminateEventHandlerDelegate;
		private readonly ErrorInfoEventHandlerDelegate _errorInfoEventHandlerDelegate;

		private Update _update;
		private PrimaryUpdate _primaryUpdate;

		public event EventHandler<ErrorInfoEventArgs> ErrorInfo;
		public event EventHandler Terminated;

		static RDP()
		{
			var nativeDlls = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, Environment.Is64BitProcess ? "x64" : "x86");
			var dllDirectory = NativeMethods.SetDllDirectory(nativeDlls);
		}

		public RDP()
		{
			if (_winsock == -1)
			{
				_winsock = Tcp.WSAStartup();
			}
				

			_freerdp = NativeMethods.freerdp_new();
			if (_freerdp == null)
				throw new FreeRdpException("FreeRDP create failed");
			
			_iUpdate = null;
			_iPrimaryUpdate = null;
			_iSecondaryUpdate = null;
			_iAltSecUpdate = null;

			_terminateEventHandlerDelegate = new TerminateEventHandlerDelegate(TerminateEvent);
			_errorInfoEventHandlerDelegate = new ErrorInfoEventHandlerDelegate(ErrorInfoEvent);
			
			_hContextNew = new pContextNew(ContextNew);
			_hContextFree = new pContextFree(ContextFree);
			
			_freerdp->ContextNew = Marshal.GetFunctionPointerForDelegate(_hContextNew);
			_freerdp->ContextFree = Marshal.GetFunctionPointerForDelegate(_hContextFree);
			
			_hAuthenticate = new pAuthenticate(Authenticate);
			_hVerifyCertificate = new pVerifyCertificate(VerifyCertificate);
			
			_freerdp->Authenticate = Marshal.GetFunctionPointerForDelegate(_hAuthenticate);
			_freerdp->VerifyCertificate = Marshal.GetFunctionPointerForDelegate(_hVerifyCertificate);

			//NativeMethods.freerdp_context_new(_freerdp);

			//_settings = _freerdp->settings;
		}

		public bool Connected
		{
			get { return _connected; }
		}

		public void SetUpdateInterface(IUpdate iUpdate)
		{
			if (_connected)
				throw new FreeRdpException("Update interface must be registered before connection is made.");
			this._iUpdate = iUpdate;
		}
		
		public void SetPrimaryUpdateInterface(IPrimaryUpdate iPrimaryUpdate)
		{
			if (_connected)
				throw new FreeRdpException("Update interface must be registered before connection is made.");
			this._iPrimaryUpdate = iPrimaryUpdate;
		}
		
		private void ContextNew(freerdp* instance, rdpContext* context)
		{
			Debug.WriteLine("ContextNew");
			
			_hPreConnect = new pPreConnect(this.PreConnect);
			_hPostConnect = new pPostConnect(this.PostConnect);
			
			instance->PreConnect = Marshal.GetFunctionPointerForDelegate(_hPreConnect);
			instance->PostConnect = Marshal.GetFunctionPointerForDelegate(_hPostConnect);
			
			this._context = context;
			_input = instance->input;

			PubSub.SubscribeToTerminate(_context, _terminateEventHandlerDelegate);
			PubSub.SubscribeToErrorInfo(_context, _errorInfoEventHandlerDelegate);
		}
		
		private void ContextFree(freerdp* instance, rdpContext* context)
		{
			this._context = null;
			_input = IntPtr.Zero;
			Debug.WriteLine("ContextFree");
		}

		private bool PreConnect(freerdp* instance)
		{
			Debug.WriteLine("PreConnect");
			
			if (_iUpdate != null)
			{
				_update = new Update(instance->context);
				_update.RegisterInterface(_iUpdate);
			}
			
			if (_iPrimaryUpdate != null)
			{
				_primaryUpdate = new PrimaryUpdate(instance->context);
				_primaryUpdate.RegisterInterface(_iPrimaryUpdate);
			}

			//settings->RemoteFxCodec = 1;
			//settings->RemoteFxOnly = 1;
			//settings->FastPathOutput = 1;
			//settings->ColorDepth = 32;
			//settings->FrameAcknowledge = 0;
			//settings->PerformanceFlags = 0;
			//settings->LargePointerFlag = 1;
			//settings->GlyphSupportLevel = 0;
			//settings->BitmapCacheEnabled = 0;
			//settings->OffscreenSupportLevel = 0;

			return true;
		}

		private bool PostConnect(freerdp* instance)
		{
			Debug.WriteLine("PostConnect");
			return true;
		}

		/// <summary>
		/// Connects the specified hostname.
		/// </summary>
		/// <param name="hostname">The hostname.</param>
		/// <param name="domain">The domain.</param>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <param name="port">The port.</param>
		/// <returns></returns>
		public void Connect(string hostname, string domain, string username, string password, int port = 3389,
			ConnectionSettings connectionSettings = null)
		{
			if (hostname == null) throw new ArgumentNullException(nameof(hostname));
			if (username == null) throw new ArgumentNullException(nameof(username));

			if (_connected)
				throw new FreeRdpException("Cannot connect when different connection is already active.");

			DisposeContext();
			NativeMethods.freerdp_context_new(_freerdp);
			_settings = _freerdp->settings;
			if (_settings == null)
				throw new FreeRdpException("Contex creation failed");

			_settings->ServerPort = (uint) port;
			_settings->AsyncTransport = 1;
			_settings->AutoLogonEnabled = 1;
			//_settings->IgnoreCertificate = 1;
			//_settings->LocalConnection = 1;

			if (connectionSettings != null)
			{
				_settings->DesktopWidth = (uint)connectionSettings.DesktopWidth;
				_settings->DesktopHeight = (uint)connectionSettings.DesktopHeight;
				_settings->ColorDepth = (uint)connectionSettings.ColorDepth;
			}

			Debug.WriteLine("hostname:{0} username:{1} width:{2} height:{3} port:{4}",
				hostname, username, _settings->DesktopWidth, _settings->DesktopHeight, _settings->ServerPort);


			//The freerdp_context_free will free all strings, however it will cause Assert in debug mode, because 
			// the heap manager used by c++ in debug is not the same as Marshal.StringToHGlobalAnsi uses
			_settings->ServerHostname = Marshal.StringToHGlobalAnsi(hostname);
			_settings->Username = Marshal.StringToHGlobalAnsi(username);
			
			if (!string.IsNullOrEmpty(domain))
			{
				_settings->Domain = Marshal.StringToHGlobalAnsi(domain);
			}

			if (!string.IsNullOrEmpty(password))
			{
				_settings->Password = Marshal.StringToHGlobalAnsi(password);
			}
			else
				_settings->Authentication = 0;


			_connected = NativeMethods.freerdp_connect(_freerdp) != 0;
			if (!_connected)
				throw new FreeRdpException("Connection failed");
		}

		private void TerminateEvent(IntPtr context, pTerminateEventArgs* args)
		{
			Debug.Write("TerminateEvent");
			_connected = false;
			OnTerminated();
		}

		private void ErrorInfoEvent(IntPtr context, pErrorInfoEventArgs* args)
		{
			Debug.Write(string.Format(CultureInfo.CurrentCulture, "Code:{0:X}({1}) Message:{2}", (uint)args->code, args->code, args->code.ErrorInfoCodeToString()));
			OnErrorInfo(new ErrorInfoEventArgs(args->code));
		}

		public void Disconnect()
		{
			EnsureConnected();
			var status = NativeMethods.freerdp_disconnect(_freerdp);
			if (status == 0)
				throw new FreeRdpException("Disconnect failed");

			DisposeContext();
			_connected = false;
			OnTerminated();
		}
		
		private bool Authenticate(freerdp* instance, IntPtr username, IntPtr password, IntPtr domain)
		{
			Debug.WriteLine("Authenticate");
			return true;
		}
		
		private bool VerifyCertificate(freerdp* instance, IntPtr subject, IntPtr issuer, IntPtr fingerprint)
		{
			Debug.WriteLine("VerifyCertificate");
			return true;
		}
		
		public void SendInputSynchronizeEvent(UInt32 flags)
		{
			EnsureConnected();
			NativeMethods.freerdp_input_send_synchronize_event(_input, flags);
		}
		
		public void SendInputKeyboardEvent(KeyboardFlags flags, UInt16 code)
		{
			EnsureConnected();
			NativeMethods.freerdp_input_send_keyboard_event(_input, (ushort)flags, code);
		}
		
		public void SendInputUnicodeKeyboardEvent(UInt16 flags, UInt16 code)
		{
			EnsureConnected();
			NativeMethods.freerdp_input_send_unicode_keyboard_event(_input, flags, code);
		}
		
		public void SendInputMouseEvent(UInt16 flags, UInt16 x, UInt16 y)
		{
			EnsureConnected();
			NativeMethods.freerdp_input_send_mouse_event(_input, flags, x, y);
		}
		
		public void SendInputExtendedMouseEvent(UInt16 flags, UInt16 x, UInt16 y)
		{
			EnsureConnected();
			NativeMethods.freerdp_input_send_extended_mouse_event(_input, flags, x, y);
		}

		private void EnsureConnected()
		{
			if (!_connected)
				throw new FreeRdpException("Not connected");
		}

		protected virtual void OnErrorInfo(ErrorInfoEventArgs e)
		{
			ErrorInfo?.Invoke(this, e);
		}

		protected virtual void OnTerminated()
		{
			Terminated?.Invoke(this, EventArgs.Empty);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~RDP()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			//if (disposing)
			//{
			//	// free managed resources
			//}
			// free native resources if there are any.  
			if (_freerdp != null)
			{
				if (_connected)
				{
					NativeMethods.freerdp_disconnect(_freerdp);
					_connected = false;
				}
				DisposeContext();
				NativeMethods.freerdp_free(_freerdp);
				_freerdp = null;
			}
		}

		private unsafe void DisposeContext()
		{
			if (_context != null)
			{
				PubSub.UnSubscribeToTerminate(_context, _terminateEventHandlerDelegate);
				PubSub.UnSubscribeToErrorInfo(_context, _errorInfoEventHandlerDelegate);

				NativeMethods.freerdp_context_free(_freerdp);
				_context = null;
			}
		}
	}

	public class ConnectionSettings
	{
		public int DesktopWidth { get; set; } = 1024;

		public int DesktopHeight { get; set; } = 768;

		public int ColorDepth { get; set; } = 32;
	}

	public class ErrorInfoEventArgs : EventArgs
	{
		public ErrorInfoCode ErrorCode { get; }

		public string ErrorInfoMessage => this.ErrorCode.ErrorInfoCodeToString();

		public ErrorInfoEventArgs(ErrorInfoCode errorCode)
		{
			ErrorCode = errorCode;
		}
	}
}

