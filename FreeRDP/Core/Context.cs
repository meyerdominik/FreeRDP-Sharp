/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Context
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
	[StructLayout(LayoutKind.Explicit, Pack = 8)]
	public unsafe struct rdpContext
	{
		[FieldOffset(0)]public freerdp* instance;
		[FieldOffset(1*8)]public IntPtr peer;
		[FieldOffset(2*8)]public fixed UInt32 paddingA[16-2];
		
		[FieldOffset(16*8)]public int argc;
		[FieldOffset(17*8)]public IntPtr argv;
		[FieldOffset(18*8)]public IntPtr pubSub;
		[FieldOffset(19*8)]public fixed UInt32 paddingB[32-19];
		
		[FieldOffset(32*8)]public IntPtr rdp;
		[FieldOffset(33*8)]public IntPtr gdi;
		[FieldOffset(34*8)]public IntPtr rail;
		[FieldOffset(35*8)]public IntPtr cache;
		[FieldOffset(36*8)]public IntPtr channels;
		[FieldOffset(37*8)]public IntPtr graphics;
		[FieldOffset(38*8)]public fixed UInt32 paddingC[64-38];
		[FieldOffset(64*8)]public fixed UInt32 paddingD[96 - 64];
		[FieldOffset(96*8)]public fixed UInt32 paddingE[128 - 96];
	};
}

