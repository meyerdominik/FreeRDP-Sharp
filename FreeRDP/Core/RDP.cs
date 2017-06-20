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
using System.Text;
using System.Runtime.InteropServices;

namespace FreeRDP
{	
	public unsafe class RDP
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

		private static int winsock = -1;

		public int Port { get { return (int) settings->ServerPort; } set { settings->ServerPort = (UInt32) value; } }
		public int Width { get { return (int) settings->DesktopWidth; } set { settings->DesktopWidth = (UInt32) value; } }
		public int Height { get { return (int) settings->DesktopHeight; } set { settings->DesktopHeight = (UInt32) value; } }
		
		private freerdp* handle;
		private IntPtr input;
		private rdpContext* context;
		private rdpSettings* settings;
		
		private IUpdate iUpdate;
		private IPrimaryUpdate iPrimaryUpdate;
		private ISecondaryUpdate iSecondaryUpdate;
		private IAltSecUpdate iAltSecUpdate;
		
		private pContextNew hContextNew;
		private pContextFree hContextFree;
		
		private pPreConnect hPreConnect;
		private pPostConnect hPostConnect;
		
		private pAuthenticate hAuthenticate;
		private pVerifyCertificate hVerifyCertificate;
		
		private Update update;
		private PrimaryUpdate primary;
		
		public RDP()
		{
			if (winsock == -1)
			{
				winsock = Tcp.WSAStartup();
			}
				

			handle = freerdp_new();
			
			iUpdate = null;
			iPrimaryUpdate = null;
			iSecondaryUpdate = null;
			iAltSecUpdate = null;
			
			hContextNew = new pContextNew(ContextNew);
			hContextFree = new pContextFree(ContextFree);
			
			handle->ContextNew = Marshal.GetFunctionPointerForDelegate(hContextNew);
			handle->ContextFree = Marshal.GetFunctionPointerForDelegate(hContextFree);
			
			hAuthenticate = new pAuthenticate(Authenticate);
			hVerifyCertificate = new pVerifyCertificate(VerifyCertificate);
			
			handle->Authenticate = Marshal.GetFunctionPointerForDelegate(hAuthenticate);
			handle->VerifyCertificate = Marshal.GetFunctionPointerForDelegate(hVerifyCertificate);

			//handle->ContextSize++;// = UIntPtr.Add(handle->ContextSize, 1);

			freerdp_context_new(handle);
		}
		
		~RDP()
		{

		}
		
		public void SetUpdateInterface(IUpdate iUpdate)
		{
			this.iUpdate = iUpdate;
		}
		
		public void SetPrimaryUpdateInterface(IPrimaryUpdate iPrimaryUpdate)
		{
			this.iPrimaryUpdate = iPrimaryUpdate;
		}
		
		void ContextNew(freerdp* instance, rdpContext* context)
		{
			Console.WriteLine("ContextNew");
			
			hPreConnect = new pPreConnect(this.PreConnect);
			hPostConnect = new pPostConnect(this.PostConnect);
			
			instance->PreConnect = Marshal.GetFunctionPointerForDelegate(hPreConnect);
			instance->PostConnect = Marshal.GetFunctionPointerForDelegate(hPostConnect);
			
			this.context = context;
			input = instance->input;
			settings = instance->settings;
		}
		
		void ContextFree(freerdp* instance, rdpContext* context)
		{
			Console.WriteLine("ContextFree");
		}
		
		bool PreConnect(freerdp* instance)
		{
			Console.WriteLine("PreConnect");
			
			if (iUpdate != null)
			{
				update = new Update(instance->context);
				update.RegisterInterface(iUpdate);
			}
			
			if (iPrimaryUpdate != null)
			{
				primary = new PrimaryUpdate(instance->context);
				primary.RegisterInterface(iPrimaryUpdate);
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
		
		bool PostConnect(freerdp* instance)
		{
			Console.WriteLine("PostConnect");
			return true;
		}
		
		public bool Connect(string hostname, int port, string username, string domain, string password)
		{
			settings->ServerPort = (uint) port;
			
			Console.WriteLine("hostname:{0} username:{1} width:{2} height:{3} port:{4}",
				hostname, username, settings->DesktopWidth, settings->DesktopHeight, settings->ServerPort);
			
			//settings->IgnoreCertificate = 1;
			
			settings->ServerHostname = Marshal.StringToHGlobalAnsi(hostname);
			settings->Username = Marshal.StringToHGlobalAnsi(username);
			
			if (domain.Length > 1)
				settings->Domain = Marshal.StringToHGlobalAnsi(domain);
			
			if (password.Length > 1)
				settings->Password = Marshal.StringToHGlobalAnsi(password);
			else
				settings->Authentication = 0;

			var freerdpConnect = freerdp_connect(handle);
			return freerdpConnect != 0;
		}
		
		public bool Disconnect()
		{
			return ((freerdp_disconnect(handle) == 0) ? false : true);
		}
		
		private bool Authenticate(freerdp* instance, IntPtr username, IntPtr password, IntPtr domain)
		{
			Console.WriteLine("Authenticate");
			return true;
		}
		
		private bool VerifyCertificate(freerdp* instance, IntPtr subject, IntPtr issuer, IntPtr fingerprint)
		{
			Console.WriteLine("VerifyCertificate");
			return true;
		}
		
		public bool CheckFileDescriptor()
		{
			return ((freerdp_check_fds(handle) == 0) ? false : true);
		}
		
		public void SendInputSynchronizeEvent(UInt32 flags)
		{
			freerdp_input_send_synchronize_event(input, flags);
		}
		
		public void SendInputKeyboardEvent(UInt16 flags, UInt16 code)
		{
			freerdp_input_send_keyboard_event(input, flags, code);
		}
		
		public void SendInputUnicodeKeyboardEvent(UInt16 flags, UInt16 code)
		{
			freerdp_input_send_unicode_keyboard_event(input, flags, code);
		}
		
		public void SendInputMouseEvent(UInt16 flags, UInt16 x, UInt16 y)
		{
			freerdp_input_send_mouse_event(input, flags, x, y);
		}
		
		public void SendInputExtendedMouseEvent(UInt16 flags, UInt16 x, UInt16 y)
		{
			freerdp_input_send_extended_mouse_event(input, flags, x, y);
		}
	}
}

