/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * FreeRDP
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
using System.Runtime.InteropServices;

namespace FreeRDP
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void pContextNew(freerdp* instance, rdpContext* context);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate void pContextFree(freerdp* instance, rdpContext* context);
	
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool pPreConnect(freerdp* instance);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool pPostConnect(freerdp* instance);
	
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool pAuthenticate(freerdp* instance, IntPtr username, IntPtr password, IntPtr domain);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public unsafe delegate bool pVerifyCertificate(freerdp* instance, IntPtr subject, IntPtr issuer, IntPtr fingerprint);
	
	[StructLayout(LayoutKind.Explicit, Pack = 8)]
	public unsafe struct freerdp
	{
		[FieldOffset(0)] public rdpContext* context;
		[FieldOffset(1*8)] public fixed UInt64 paddingA[16-1];
		
		[FieldOffset(16*8)] public IntPtr input;
		[FieldOffset(17*8)] public rdpUpdate* update;
		[FieldOffset(18*8)] public rdpSettings* settings;
		[FieldOffset(19*8)] public fixed UInt64 paddingB[32-19];
		
		[FieldOffset(32*8)] public UInt32 ContextSize;
		[FieldOffset(33*8)] public IntPtr ContextNew;
		[FieldOffset(34*8)] public IntPtr ContextFree;
		[FieldOffset(35*8)] public fixed UInt64 paddingC[48-35];
		
		[FieldOffset(48*8)] public IntPtr PreConnect;
		[FieldOffset(49*8)] public IntPtr PostConnect;
		[FieldOffset(50*8)] public IntPtr Authenticate;
		[FieldOffset(51*8)] public IntPtr VerifyCertificate;
		[FieldOffset(52*8)] public fixed UInt64 paddingD[64-52];
		
		[FieldOffset(64*8)] public IntPtr SendChannelData;
		[FieldOffset(65*8)] public IntPtr RecvChannelData;
		[FieldOffset(66*8)] public fixed UInt64 paddingF[80-66];
	};
}

