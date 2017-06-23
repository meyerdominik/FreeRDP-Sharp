using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using FreeRDP.Exceptions;

namespace FreeRDP.Core
{
	internal unsafe class PubSub
	{
		private static class NativeMethods
		{
			[DllImport("libwinpr-utils", CallingConvention = CallingConvention.Cdecl)]
			public static extern int PubSub_Subscribe(IntPtr pubSub, string eventName, IntPtr eventHandler);

			[DllImport("libwinpr-utils", CallingConvention = CallingConvention.Cdecl)]
			public static extern int PubSub_Unsubscribe(IntPtr pubSub, string eventName, IntPtr eventHandler);
		}


		public static void SubscribeToTerminate(rdpContext* context, TerminateEventHandlerDelegate handler)
		{
			if (NativeMethods.PubSub_Subscribe(context->pubSub, "Terminate", Marshal.GetFunctionPointerForDelegate(handler)) != 0)
				throw new FreeRdpException("Failed to subscribe to Terminate event");
		}

		public static void UnSubscribeToTerminate(rdpContext* context, TerminateEventHandlerDelegate handler)
		{
			NativeMethods.PubSub_Unsubscribe(context->pubSub, "Terminate", Marshal.GetFunctionPointerForDelegate(handler));
		}

		public static void SubscribeToErrorInfo(rdpContext* context, ErrorInfoEventHandlerDelegate handler)
		{
			if (NativeMethods.PubSub_Subscribe(context->pubSub, "ErrorInfo", Marshal.GetFunctionPointerForDelegate(handler)) != 0)
				throw new FreeRdpException("Failed to subscribe to ErrorInfo event");
		}
		public static void UnSubscribeToErrorInfo(rdpContext* context, ErrorInfoEventHandlerDelegate handler)
		{
			NativeMethods.PubSub_Unsubscribe(context->pubSub, "ErrorInfo", Marshal.GetFunctionPointerForDelegate(handler));
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct pEventArgs
	{
		public uint Size;
		public IntPtr Sender;
	};

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct pTerminateEventArgs
	{
		public pEventArgs e;
		public int code;
	};

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal unsafe delegate void EventHandlerDelegate(IntPtr context, pEventArgs* e);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal unsafe delegate void TerminateEventHandlerDelegate(IntPtr context, pTerminateEventArgs* args);

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct pErrorInfoEventArgs
	{
		public pEventArgs e;
		public ErrorInfoCode code;
	};

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal unsafe delegate void ErrorInfoEventHandlerDelegate(IntPtr context, pErrorInfoEventArgs* args);
}
