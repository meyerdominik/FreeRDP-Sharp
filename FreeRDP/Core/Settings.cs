/**
 * FreeRDP: A Remote Desktop Protocol Implementation
 * Settings
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
	[StructLayout(LayoutKind.Explicit)]
	public unsafe struct rdpSettings
	{
		/**
		* WARNING: this data structure is carefully padded for ABI stability!
		* Keeping this area clean is particularly challenging, so unless you are
		* a trusted developer you should NOT take the liberty of adding your own
		* options straight into the ABI stable zone. Instead, append them to the
		* very end of this data structure, in the zone marked as ABI unstable.
		*/

		[FieldOffset(0 * 8)] public void* instance;  /* 0 */
		[FieldOffset(1 * 8)] public fixed UInt64 padding001[16 - 1];  /* 1 */

		/* Core Parameters */
		[FieldOffset(16 * 8)] public int ServerMode;  /* 16 */
		[FieldOffset(17 * 8)] public UInt32 ShareId;  /* 17 */
		[FieldOffset(18 * 8)] public UInt32 PduSource;  /* 18 */
		[FieldOffset(19 * 8)] public UInt32 ServerPort;  /* 19 */
		[FieldOffset(20 * 8)] public IntPtr ServerHostname;  /* 20 */
		[FieldOffset(21 * 8)] public IntPtr Username;  /* 21 */
		[FieldOffset(22 * 8)] public IntPtr Password;  /* 22 */
		[FieldOffset(23 * 8)] public IntPtr Domain;  /* 23 */
		[FieldOffset(24 * 8)] public fixed UInt64 padding0064[64 - 24];  /* 24 */
		[FieldOffset(64 * 8)] public fixed UInt64 padding0128[128 - 64];  /* 64 */

		/**
			* GCC User Data Blocks
			*/

		/* Client/Server Core Data */
		[FieldOffset(128 * 8)] public UInt32 RdpVersion;  /* 128 */
		[FieldOffset(129 * 8)] public UInt32 DesktopWidth;  /* 129 */
		[FieldOffset(130 * 8)] public UInt32 DesktopHeight;  /* 130 */
		[FieldOffset(131 * 8)] public UInt32 ColorDepth;  /* 131 */
		[FieldOffset(132 * 8)] public UInt32 ConnectionType;  /* 132 */
		[FieldOffset(133 * 8)] public UInt32 ClientBuild;  /* 133 */
		[FieldOffset(134 * 8)] public char* ClientHostname;  /* 134 */
		[FieldOffset(135 * 8)] public char* ClientProductId;  /* 135 */
		[FieldOffset(136 * 8)] public UInt32 EarlyCapabilityFlags;  /* 136 */
		[FieldOffset(137 * 8)] public int NetworkAutoDetect;  /* 137 */
		[FieldOffset(138 * 8)] public int SupportAsymetricKeys;  /* 138 */
		[FieldOffset(139 * 8)] public int SupportErrorInfoPdu;  /* 139 */
		[FieldOffset(140 * 8)] public int SupportStatusInfoPdu;  /* 140 */
		[FieldOffset(141 * 8)] public int SupportMonitorLayoutPdu;  /* 141 */
		[FieldOffset(142 * 8)] public int SupportGraphicsPipeline;  /* 142 */
		[FieldOffset(143 * 8)] public int SupportDynamicTimeZone;  /* 143 */
		[FieldOffset(144 * 8)] public fixed UInt64 padding0192[192 - 143];  /* 143 */

		private const int Bug1 = 8;
		/* Client/Server Security Data */
		[FieldOffset(192 * 8 + Bug1)] public int DisableEncryption;  /* 192 */
		[FieldOffset(193 * 8 + Bug1)] public UInt32 EncryptionMethods;  /* 193 */
		[FieldOffset(194 * 8 + Bug1)] public UInt32 ExtEncryptionMethods;  /* 194 */
		[FieldOffset(195 * 8 + Bug1)] public UInt32 EncryptionLevel;  /* 195 */
		[FieldOffset(196 * 8 + Bug1)] public IntPtr ServerRandom;  /* 196 */
		[FieldOffset(197 * 8 + Bug1)] public UInt32 ServerRandomLength;  /* 197 */
		[FieldOffset(198 * 8 + Bug1)] public IntPtr ServerCertificate;  /* 198 */
		[FieldOffset(199 * 8 + Bug1)] public UInt32 ServerCertificateLength;  /* 199 */
		[FieldOffset(200 * 8 + Bug1)] public fixed UInt64 padding0256[256 - 200];  /* 200 */

		/* Client Network Data */
		[FieldOffset(256 * 8 + Bug1)] public UInt32 ChannelCount;  /* 256 */
		[FieldOffset(257 * 8 + Bug1)] public UInt32 ChannelDefArraySize;  /* 257 */
		[FieldOffset(258 * 8 + Bug1)] public IntPtr ChannelDefArray;  /* 258 */
		[FieldOffset(259 * 8 + Bug1)] public fixed UInt64 padding0320[320 - 259];  /* 259 */

		/* Client Cluster Data */
		[FieldOffset(320 * 8 + Bug1)] public UInt32 ClusterInfoFlags;  /* 320 */
		[FieldOffset(321 * 8 + Bug1)] public UInt32 RedirectedSessionId;  /* 321 */
		[FieldOffset(322 * 8 + Bug1)] public int ConsoleSession;  /* 322 */
		[FieldOffset(323 * 8 + Bug1)] public fixed UInt64 padding0384[384 - 323];  /* 323 */

		/* Client Monitor Data */
		[FieldOffset(384 * 8 + Bug1)] public int MonitorCount;  /* 384 */
		[FieldOffset(385 * 8 + Bug1)] public UInt32 MonitorDefArraySize;  /* 385 */
		[FieldOffset(386 * 8 + Bug1)] public IntPtr MonitorDefArray;  /* 386 */
		[FieldOffset(387 * 8 + Bug1)] public int SpanMonitors;  /* 387 */
		[FieldOffset(388 * 8 + Bug1)] public int UseMultimon;  /* 388 */
		[FieldOffset(389 * 8 + Bug1)] public int ForceMultimon;  /* 389 */
		[FieldOffset(390 * 8 + Bug1)] public UInt32 DesktopPosX;  /* 390 */
		[FieldOffset(391 * 8 + Bug1)] public UInt32 DesktopPosY;  /* 391 */
		[FieldOffset(392 * 8 + Bug1)] public int ListMonitors;  /* 392 */
		[FieldOffset(393 * 8 + Bug1)] public IntPtr MonitorIds;  /* 393 */
		[FieldOffset(394 * 8 + Bug1)] public UInt32 NumMonitorIds;  /* 394 */
		[FieldOffset(395 * 8 + Bug1)] public fixed UInt64 padding0448[448 - 395];  /* 395 */

		/* Client Message Channel Data */
		[FieldOffset(448 * 8 + Bug1)] public fixed UInt64 padding0512[512 - 448];  /* 448 */

		/* Client Multitransport Channel Data */
		[FieldOffset(512 * 8 + Bug1)] public UInt32 MultitransportFlags;  /* 512 */
		[FieldOffset(513 * 8 + Bug1)] public fixed UInt64 padding0576[576 - 513];  /* 513 */
		[FieldOffset(576 * 8 + Bug1)] public fixed UInt64 padding0640[640 - 576];  /* 576 */

		/*
			* Client Info
			*/

		/* Client Info (Shell) */
		[FieldOffset(640 * 8 + Bug1)] public char* AlternateShell;  /* 640 */
		[FieldOffset(641 * 8 + Bug1)] public char* ShellWorkingDirectory;  /* 641 */
		[FieldOffset(642 * 8 + Bug1)] public fixed UInt64 padding0704[704 - 642];  /* 642 */

		/* Client Info Flags */
		[FieldOffset(704 * 8 + Bug1)] public int AutoLogonEnabled;  /* 704 */
		[FieldOffset(705 * 8 + Bug1)] public int CompressionEnabled;  /* 705 */
		[FieldOffset(706 * 8 + Bug1)] public int DisableCtrlAltDel;  /* 706 */
		[FieldOffset(707 * 8 + Bug1)] public int EnableWindowsKey;  /* 707 */
		[FieldOffset(708 * 8 + Bug1)] public int MaximizeShell;  /* 708 */
		[FieldOffset(709 * 8 + Bug1)] public int LogonNotify;  /* 709 */
		[FieldOffset(710 * 8 + Bug1)] public int LogonErrors;  /* 710 */
		[FieldOffset(711 * 8 + Bug1)] public int MouseAttached;  /* 711 */
		[FieldOffset(712 * 8 + Bug1)] public int MouseHasWheel;  /* 712 */
		[FieldOffset(713 * 8 + Bug1)] public int RemoteConsoleAudio;  /* 713 */
		[FieldOffset(714 * 8 + Bug1)] public int AudioPlayback;  /* 714 */
		[FieldOffset(715 * 8 + Bug1)] public int AudioCapture;  /* 715 */
		[FieldOffset(716 * 8 + Bug1)] public int VideoDisable;  /* 716 */
		[FieldOffset(717 * 8 + Bug1)] public int PasswordIsSmartcardPin;  /* 717 */
		[FieldOffset(718 * 8 + Bug1)] public int UsingSavedCredentials;  /* 718 */
		[FieldOffset(719 * 8 + Bug1)] public int ForceEncryptedCsPdu;  /* 719 */
		[FieldOffset(720 * 8 + Bug1)] public fixed UInt64 padding0768[768 - 720];  /* 720 */

		/* Client Info (Extra) */
		[FieldOffset(768 * 8 + Bug1)] public int IPv6Enabled;  /* 768 */
		[FieldOffset(769 * 8 + Bug1)] public char* ClientAddress;  /* 769 */
		[FieldOffset(770 * 8 + Bug1)] public char* ClientDir;  /* 770 */
		[FieldOffset(771 * 8 + Bug1)] public fixed UInt64 padding0832[832 - 771];  /* 771 */

		/* Client Info (Auto Reconnection) */
		[FieldOffset(832 * 8 + Bug1)] public int AutoReconnectionEnabled;  /* 832 */
		[FieldOffset(833 * 8 + Bug1)] public UInt32 AutoReconnectMaxRetries;  /* 833 */
		[FieldOffset(834 * 8 + Bug1)] public IntPtr ClientAutoReconnectCookie;  /* 834 */
		[FieldOffset(835 * 8 + Bug1)] public IntPtr ServerAutoReconnectCookie;  /* 835 */
		[FieldOffset(836 * 8 + Bug1)] public fixed UInt64 padding0896[896 - 835];  /* 835 */

		private const int Bug2 = 8;

		/* Client Info (Time Zone) */
		[FieldOffset(896 * 8 + Bug1 + Bug2)] public IntPtr ClientTimeZone;  /* 896 */
		[FieldOffset(897 * 8 + Bug1 + Bug2)] public char* DynamicDSTTimeZoneKeyName;  /* 897 */
		[FieldOffset(898 * 8 + Bug1 + Bug2)] public int DynamicDaylightTimeDisabled;  /* 898 */
		[FieldOffset(899 * 8 + Bug1 + Bug2)] public fixed UInt64 padding0960[960 - 899];  /* 899 */

		/* Client Info (Performance Flags) */
		[FieldOffset(960 * 8 + Bug1 + Bug2)] public UInt32 PerformanceFlags;  /* 960 */
		[FieldOffset(961 * 8 + Bug1 + Bug2)] public int AllowFontSmoothing;  /* 961 */
		[FieldOffset(962 * 8 + Bug1 + Bug2)] public int DisableWallpaper;  /* 962 */
		[FieldOffset(963 * 8 + Bug1 + Bug2)] public int DisableFullWindowDrag;  /* 963 */
		[FieldOffset(964 * 8 + Bug1 + Bug2)] public int DisableMenuAnims;  /* 964 */
		[FieldOffset(965 * 8 + Bug1 + Bug2)] public int DisableThemes;  /* 965 */
		[FieldOffset(966 * 8 + Bug1 + Bug2)] public int DisableCursorShadow;  /* 966 */
		[FieldOffset(967 * 8 + Bug1 + Bug2)] public int DisableCursorBlinking;  /* 967 */
		[FieldOffset(968 * 8 + Bug1 + Bug2)] public int AllowDesktopComposition;  /* 968 */
		[FieldOffset(969 * 8 + Bug1 + Bug2)] public fixed UInt64 padding1024[1024 - 969];  /* 969 */
		[FieldOffset(1024 * 8 + Bug1 + Bug2)] public fixed UInt64 padding1088[1088 - 1024];  /* 1024 */

		/**
			* X.224 Connection Request/Confirm
			*/

		/* Protocol Security */
		[FieldOffset(1088 * 8 + Bug1 + Bug2)] public int TlsSecurity;  /* 1088 */
		[FieldOffset(1089 * 8 + Bug1 + Bug2)] public int NlaSecurity;  /* 1089 */
		[FieldOffset(1090 * 8 + Bug1 + Bug2)] public int RdpSecurity;  /* 1090 */
		[FieldOffset(1091 * 8 + Bug1 + Bug2)] public int ExtSecurity;  /* 1091 */
		[FieldOffset(1092 * 8 + Bug1 + Bug2)] public int Authentication;  /* 1092 */
		[FieldOffset(1093 * 8 + Bug1 + Bug2)] public UInt32 RequestedProtocols;  /* 1093 */
		[FieldOffset(1094 * 8 + Bug1 + Bug2)] public UInt32 SelectedProtocol;  /* 1094 */
		[FieldOffset(1095 * 8 + Bug1 + Bug2)] public UInt32 NegotiationFlags;  /* 1095 */
		[FieldOffset(1096 * 8 + Bug1 + Bug2)] public int NegotiateSecurityLayer;  /* 1096 */
		[FieldOffset(1097 * 8 + Bug1 + Bug2)] public fixed UInt64 padding1152[1152 - 1097];  /* 1097 */

		/* Connection Cookie */
		[FieldOffset(1152 * 8 + Bug1 + Bug2)] public int MstscCookieMode;  /* 1152 */
		[FieldOffset(1153 * 8 + Bug1 + Bug2)] public UInt32 CookieMaxLength;  /* 1153 */
		[FieldOffset(1154 * 8 + Bug1 + Bug2)] public UInt32 PreconnectionId;  /* 1154 */
		[FieldOffset(1155 * 8 + Bug1 + Bug2)] public char* PreconnectionBlob;  /* 1155 */
		[FieldOffset(1156 * 8 + Bug1 + Bug2)] public int SendPreconnectionPdu;  /* 1156 */
		[FieldOffset(1157 * 8 + Bug1 + Bug2)] public fixed UInt64 padding1216[1216 - 1057];  /* 1157 */

		private const int Bug3 = 800;

		/* Server Redirection */
		[FieldOffset(1216 * 8 + Bug1 + Bug2 + Bug3)] public UInt32 RedirectionFlags;  /* 1216 */
		[FieldOffset(1217 * 8 + Bug1 + Bug2 + Bug3)] public IntPtr LoadBalanceInfo;  /* 1217 */
		[FieldOffset(1218 * 8 + Bug1 + Bug2 + Bug3)] public UInt32 LoadBalanceInfoLength;  /* 1218 */
		[FieldOffset(1219 * 8 + Bug1 + Bug2 + Bug3)] public IntPtr RedirectionUsername;  /* 1219 */
		[FieldOffset(1220 * 8 + Bug1 + Bug2 + Bug3)] public UInt32 RedirectionUsernameLength;  /* 1220 */
		[FieldOffset(1221 * 8 + Bug1 + Bug2 + Bug3)] public IntPtr RedirectionDomain;  /* 1221 */
		[FieldOffset(1222 * 8 + Bug1 + Bug2 + Bug3)] public UInt32 RedirectionDomainLength;  /* 1222 */
		[FieldOffset(1223 * 8 + Bug1 + Bug2 + Bug3)] public IntPtr RedirectionPassword;  /* 1223 */
		[FieldOffset(1224 * 8 + Bug1 + Bug2 + Bug3)] public UInt32 RedirectionPasswordLength;  /* 1224 */
		[FieldOffset(1225 * 8 + Bug1 + Bug2 + Bug3)] public IntPtr RedirectionTargetFQDN;  /* 1225 */
		[FieldOffset(1226 * 8 + Bug1 + Bug2 + Bug3)] public UInt32 RedirectionTargetFQDNLength;  /* 1226 */
		[FieldOffset(1227 * 8 + Bug1 + Bug2 + Bug3)] public IntPtr RedirectionTargetNetBiosName;  /* 1227 */
		[FieldOffset(1228 * 8 + Bug1 + Bug2 + Bug3)] public UInt32 RedirectionTargetNetBiosNameLength;  /* 1228 */
		[FieldOffset(1229 * 8 + Bug1 + Bug2 + Bug3)] public IntPtr RedirectionTsvUrl;  /* 1229 */
		[FieldOffset(1230 * 8 + Bug1 + Bug2 + Bug3)] public UInt32 RedirectionTsvUrlLength;  /* 1230 */
		[FieldOffset(1231 * 8 + Bug1 + Bug2 + Bug3)] public UInt32 TargetNetAddressCount;  /* 1231 */
		[FieldOffset(1232 * 8 + Bug1 + Bug2 + Bug3)] public IntPtr TargetNetAddresses;  /* 1232 */
		[FieldOffset(1233 * 8 + Bug1 + Bug2 + Bug3)] public fixed UInt64 padding1280[1280 - 1233];  /* 1233 */

		/**
			* Security
			*/

		/* Credentials Cache */
		[FieldOffset(1280 * 8 + Bug1 + Bug2 + Bug3)] public IntPtr Password51;  /* 1280 */
		[FieldOffset(1281 * 8 + Bug1 + Bug2 + Bug3)] public UInt32 Password51Length;  /* 1281 */
		[FieldOffset(1282 * 8 + Bug1 + Bug2 + Bug3)] public fixed UInt64 padding1344[1344 - 1282];  /* 1282 */

		/* Kerberos Authentication */
		[FieldOffset(1344 * 8 + Bug1 + Bug2 + Bug3)] public char* KerberosKdc;  /* 1344 */
		[FieldOffset(1345 * 8 + Bug1 + Bug2 + Bug3)] public char* KerberosRealm;  /* 1345 */
		[FieldOffset(1346 * 8 + Bug1 + Bug2 + Bug3)] public fixed UInt64 padding1408[1408 - 1346];  /* 1346 */

		/* Server Certificate */
		[FieldOffset(1408 * 8 + Bug1 + Bug2 + Bug3)] public int IgnoreCertificate;  /* 1408 */
		[FieldOffset(1409 * 8 + Bug1 + Bug2 + Bug3)] public char* CertificateName;  /* 1409 */
		[FieldOffset(1410 * 8 + Bug1 + Bug2 + Bug3)] public char* CertificateFile;  /* 1410 */
		[FieldOffset(1411 * 8 + Bug1 + Bug2 + Bug3)] public char* PrivateKeyFile;  /* 1411 */
		[FieldOffset(1412 * 8 + Bug1 + Bug2 + Bug3)] public char* RdpKeyFile;  /* 1412 */
		[FieldOffset(1413 * 8 + Bug1 + Bug2 + Bug3)] public IntPtr RdpServerRsaKey;  /* 1413 */
		[FieldOffset(1414 * 8 + Bug1 + Bug2 + Bug3)] public IntPtr RdpServerCertificate;  /* 1414 */
		[FieldOffset(1415 * 8 + Bug1 + Bug2 + Bug3)] public fixed UInt64 padding1472[1472 - 1350];  /* 1415 */
		private const int Bug7 = 520;
		[FieldOffset(1472 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public fixed UInt64 padding1536[1536 - 1472];  /* 1472 */


		/**
			* User Interface
			*/

		/* Window Settings */
		[FieldOffset(1536 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public int Workarea;  /* 1536 */
		[FieldOffset(1537 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public int Fullscreen;  /* 1537 */
		[FieldOffset(1538 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public UInt32 PercentScreen;  /* 1538 */
		[FieldOffset(1539 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public int GrabKeyboard;  /* 1539 */
		[FieldOffset(1540 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public int Decorations;  /* 1540 */
		[FieldOffset(1541 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public int MouseMotion;  /* 1541 */
		[FieldOffset(1542 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public char* WindowTitle;  /* 1542 */
		[FieldOffset(1543 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public UInt64 ParentWindowId;   /* 1543 */
		[FieldOffset(1544 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public int AsyncInput;  /* 1544 */
		[FieldOffset(1545 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public int AsyncUpdate;  /* 1545 */
		[FieldOffset(1546 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public int AsyncChannels;  /* 1546 */
		[FieldOffset(1547 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public int AsyncTransport;  /* 1547 */
		[FieldOffset(1548 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public int ToggleFullscreen;  /* 1548 */
		[FieldOffset(1549 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public char* WmClass;  /* 1549 */
		[FieldOffset(1550 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public int EmbeddedWindow;  /* 1550 */
		[FieldOffset(1551 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public int SmartSizing;  /* 1551 */
		[FieldOffset(1552 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public int XPan;  /* 1552 */
		[FieldOffset(1553 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public int YPan;  /* 1553 */
		[FieldOffset(1554 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public double ScalingFactor;  /* 1554 */
		[FieldOffset(1555 * 8 + Bug1 + Bug2 + Bug3 + Bug7)] public fixed UInt64 padding1600[1600 - 1555];  /* 1555 */

		private const int Bug9 = -8;

		/* Miscellaneous */
		[FieldOffset(1601 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9)] public int SoftwareGdi;  /* 1601 */
		[FieldOffset(1602 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9)] public int LocalConnection;  /* 1602 */
		[FieldOffset(1603 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9)] public int AuthenticationOnly;  /* 1603 */
		[FieldOffset(1604 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9)] public int CredentialsFromStdin;  /* 1604 */
		[FieldOffset(1605 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9)] public fixed UInt64 padding1664[1664 - 1605];  /* 1605 */

		/* Names */
		[FieldOffset(1664 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9)] public char* ComputerName;  /* 1664 */
		[FieldOffset(1665 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9)] public fixed UInt64 padding1728[1728 - 1605];  /* 1665 */

		private const int Bug4 = 480;

		/* Files */
		[FieldOffset(1728 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public char* ConnectionFile;  /* 1728 */
		[FieldOffset(1729 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public fixed UInt64 padding1792[1792 - 1729];  /* 1729 */

		/* Paths */
		[FieldOffset(1792 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public char* HomePath;  /* 1792 */
		[FieldOffset(1793 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public char* ConfigPath;  /* 1793 */
		[FieldOffset(1794 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public char* CurrentPath;  /* 1794 */
		[FieldOffset(1795 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public fixed UInt64 padding1856[1856 - 1795];  /* 1795 */

		/* Recording */
		[FieldOffset(1856 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public int DumpRemoteFx;  /* 1856 */
		[FieldOffset(1857 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public int PlayRemoteFx;  /* 1857 */
		[FieldOffset(1858 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public char* DumpRemoteFxFile;  /* 1858 */
		[FieldOffset(1859 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public char* PlayRemoteFxFile;  /* 1859 */
		[FieldOffset(1860 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public fixed UInt64 padding1920[1920 - 1860];  /* 1860 */
		[FieldOffset(1920 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public fixed UInt64 padding1984[1984 - 1920];  /* 1920 */

		/**
			* Gateway
			*/

		/* Gateway */
		[FieldOffset(1984 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public UInt32 GatewayUsageMethod;  /* 1984 */
		[FieldOffset(1985 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public UInt32 GatewayPort;  /* 1985 */
		[FieldOffset(1986 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public char* GatewayHostname;  /* 1986 */
		[FieldOffset(1987 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public char* GatewayUsername;  /* 1987 */
		[FieldOffset(1988 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public char* GatewayPassword;  /* 1988 */
		[FieldOffset(1989 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public char* GatewayDomain;  /* 1989 */
		[FieldOffset(1990 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public UInt32 GatewayCredentialsSource;  /* 1990 */
		[FieldOffset(1991 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public int GatewayUseSameCredentials;  /* 1991 */
		[FieldOffset(1992 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public int GatewayEnabled;  /* 1992 */
		[FieldOffset(1993 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public fixed UInt64 padding2048[2048 - 1993];  /* 1993 */
		[FieldOffset(2048 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public fixed UInt64 padding2112[2112 - 2048];  /* 2048 */

		/**
			* RemoteApp
			*/

		/* RemoteApp */
		[FieldOffset(2112 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public int RemoteApplicationMode;  /* 2112 */
		[FieldOffset(2113 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public char* RemoteApplicationName;  /* 2113 */
		[FieldOffset(2114 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public char* RemoteApplicationIcon;  /* 2114 */
		[FieldOffset(2115 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public char* RemoteApplicationProgram;  /* 2115 */
		[FieldOffset(2116 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public char* RemoteApplicationFile;  /* 2116 */
		[FieldOffset(2117 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public char* RemoteApplicationGuid;  /* 2117 */
		[FieldOffset(2118 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public char* RemoteApplicationCmdLine;  /* 2118 */
		[FieldOffset(2119 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public UInt32 RemoteApplicationExpandCmdLine;  /* 2119 */
		[FieldOffset(2120 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public UInt32 RemoteApplicationExpandWorkingDir;  /* 2120 */
		[FieldOffset(2121 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public UInt32 DisableRemoteAppCapsCheck;  /* 2121 */
		[FieldOffset(2122 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public UInt32 RemoteAppNumIconCaches;  /* 2122 */
		[FieldOffset(2123 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public UInt32 RemoteAppNumIconCacheEntries;  /* 2123 */
		[FieldOffset(2124 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public int RemoteAppLanguageBarSupported;  /* 2124 */
		[FieldOffset(2125 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public fixed UInt64 padding2176[2176 - 2125];  /* 2125 */
		[FieldOffset(2176 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4)] public fixed UInt64 padding2240[2240 - 2124];  /* 2176 */

		private const int Bug5 = 416;
		/**
			* Mandatory Capabilities
			*/

		/* Capabilities */
		[FieldOffset(2240 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public IntPtr ReceivedCapabilities;  /* 2240 */
		[FieldOffset(2241 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public UInt32 ReceivedCapabilitiesSize;  /* 2241 */
		[FieldOffset(2242 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public fixed UInt64 padding2304[2304 - 2242];  /* 2242 */

		/* General Capabilities */
		[FieldOffset(2304 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public UInt32 OsMajorType;  /* 2304 */
		[FieldOffset(2305 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public UInt32 OsMinorType;  /* 2305 */
		[FieldOffset(2306 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public int RefreshRect;  /* 2306 */
		[FieldOffset(2307 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public int SuppressOutput;  /* 2307 */
		[FieldOffset(2308 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public int FastPathOutput;  /* 2308 */
		[FieldOffset(2309 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public int SaltedChecksum;  /* 2309 */
		[FieldOffset(2310 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public int LongCredentialsSupported;  /* 2310 */
		[FieldOffset(2311 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public int NoBitmapCompressionHeader;  /* 2311 */
		[FieldOffset(2312 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public int BitmapCompressionDisabled;  /* 2312 */
		[FieldOffset(2313 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public fixed UInt64 padding2368[2368 - 2313];  /* 2313 */

		/* Bitmap Capabilities */
		[FieldOffset(2368 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public int DesktopResize;  /* 2368 */
		[FieldOffset(2369 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public int DrawAllowDynamicColorFidelity;  /* 2369 */
		[FieldOffset(2370 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public int DrawAllowColorSubsampling;  /* 2370 */
		[FieldOffset(2371 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public int DrawAllowSkipAlpha;  /* 2371 */
		[FieldOffset(2372 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public fixed UInt64 padding2432[2432 - 2372];  /* 2372 */

		/* Order Capabilities */
		[FieldOffset(2432 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public IntPtr OrderSupport;  /* 2432 */
		[FieldOffset(2433 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public int BitmapCacheV3Enabled;  /* 2433 */
		[FieldOffset(2434 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public int AltSecFrameMarkerSupport;  /* 2434 */
		[FieldOffset(2435 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug4 + Bug5)] public fixed UInt64 padding2496[2496 - 2435];  /* 2435 */

		private const int Bug10 = -8;

		/* Bitmap Cache Capabilities */
		[FieldOffset(2497 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public int BitmapCacheEnabled;  /* 2497 */
		[FieldOffset(2498 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public UInt32 BitmapCacheVersion;  /* 2498 */
		[FieldOffset(2499 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public int AllowCacheWaitingList;  /* 2499 */
		[FieldOffset(2500 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public int BitmapCachePersistEnabled;  /* 2500 */
		[FieldOffset(2501 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public UInt32 BitmapCacheV2NumCells;  /* 2501 */
		[FieldOffset(2502 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public IntPtr   BitmapCacheV2CellInfo;  /* 2502 */
		[FieldOffset(2503 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public fixed UInt64 padding2560[2560 - 2503];  /* 2503 */

		/* Pointer Capabilities */
		[FieldOffset(2560 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public int ColorPointerFlag;  /* 2560 */
		[FieldOffset(2561 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public UInt32 PointerCacheSize;  /* 2561 */
		[FieldOffset(2562 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public fixed UInt64 padding2624[2624 - 2562];  /* 2562 */

		/* Input Capabilities */
		[FieldOffset(2624 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public UInt32 KeyboardLayout;  /* 2624 */
		[FieldOffset(2625 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public UInt32 KeyboardType;  /* 2625 */
		[FieldOffset(2626 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public UInt32 KeyboardSubType;  /* 2626 */
		[FieldOffset(2627 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public UInt32 KeyboardFunctionKey;  /* 2627 */
		[FieldOffset(2628 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public char* ImeFileName;  /* 2628 */
		[FieldOffset(2629 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public int UnicodeInput;  /* 2629 */
		[FieldOffset(2630 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public int FastPathInput;  /* 2630 */
		[FieldOffset(2631 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public int MultiTouchInput;  /* 2631 */
		[FieldOffset(2632 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public int MultiTouchGestures;  /* 2632 */
		[FieldOffset(2633 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public fixed UInt64 padding2688[2688 - 2633];  /* 2633 */

		/* Brush Capabilities */
		[FieldOffset(2688 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public UInt32 BrushSupportLevel;  /* 2688 */
		[FieldOffset(2689 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public fixed UInt64 padding2752[2752 - 2689];  /* 2689 */

		/* Glyph Cache Capabilities */
		[FieldOffset(2752 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public UInt32 GlyphSupportLevel;  /* 2752 */
		[FieldOffset(2753 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public IntPtr GlyphCache;  /* 2753 */
		[FieldOffset(2754 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public IntPtr FragCache;  /* 2754 */
		[FieldOffset(2755 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public fixed UInt64 padding2816[2816 - 2755];  /* 2755 */

		/* Offscreen Bitmap Cache */
		[FieldOffset(2816 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public UInt32 OffscreenSupportLevel;  /* 2816 */
		[FieldOffset(2817 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public UInt32 OffscreenCacheSize;  /* 2817 */
		[FieldOffset(2818 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public UInt32 OffscreenCacheEntries;  /* 2818 */
		[FieldOffset(2819 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public fixed UInt64 padding2880[2880 - 2819];  /* 2819 */

		/* Virtual Channel Capabilities */
		[FieldOffset(2880 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public UInt32 VirtualChannelCompressionFlags;  /* 2880 */
		[FieldOffset(2881 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public UInt32 VirtualChannelChunkSize;  /* 2881 */
		[FieldOffset(2882 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public fixed UInt64 padding2944[2944 - 2882];  /* 2882 */

		/* Sound Capabilities */
		[FieldOffset(2944 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public int SoundBeepsEnabled;  /* 2944 */
		[FieldOffset(2945 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public fixed UInt64 padding3008[3008 - 2945];  /* 2945 */
		[FieldOffset(3008 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public fixed UInt64 padding3072[3072 - 3008];  /* 3008 */

		/**
			* Optional Capabilities
			*/

		/* Bitmap Cache Host Capabilities */
		[FieldOffset(3072 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public fixed UInt64 padding3136[3136 - 3072];  /* 3072 */

		/* Control Capabilities */
		[FieldOffset(3136 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public fixed UInt64 padding3200[3200 - 3136];  /* 3136 */

		/* Window Activation Capabilities */
		[FieldOffset(3200 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public fixed UInt64 padding3264[3264 - 3200];  /* 3200 */

		/* Font Capabilities */
		[FieldOffset(3264 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5)] public fixed UInt64 padding3328[3328 - 3200];  /* 3264 */

		private const int Bug6 = 512;

		/* Multifragment Update Capabilities */
		[FieldOffset(3328 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public UInt32 MultifragMaxRequestSize;  /* 3328 */
		[FieldOffset(3329 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public fixed UInt64 padding3392[3392 - 3329];  /* 3329 */

		/* Large Pointer Update Capabilities */
		[FieldOffset(3392 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public UInt32 LargePointerFlag;  /* 3392 */
		[FieldOffset(3393 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public fixed UInt64 padding3456[3456 - 3393];  /* 3393 */

		/* Desktop Composition Capabilities */
		[FieldOffset(3456 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public UInt32 CompDeskSupportLevel;  /* 3456 */
		[FieldOffset(3457 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public fixed UInt64 padding3520[3520 - 3457];  /* 3457 */

		/* Surface Commands Capabilities */
		[FieldOffset(3520 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public int SurfaceCommandsEnabled;  /* 3520 */
		[FieldOffset(3521 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public int FrameMarkerCommandEnabled;  /* 3521 */
		[FieldOffset(3522 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public fixed UInt64 padding3584[3584 - 3522];  /* 3522 */
		[FieldOffset(3584 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public fixed UInt64 padding3648[3648 - 3584];  /* 3584 */

		/*
			* Bitmap Codecs Capabilities
			*/

		/* RemoteFX */
		[FieldOffset(3648 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public int RemoteFxOnly;  /* 3648 */
		[FieldOffset(3649 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public int RemoteFxCodec;  /* 3649 */
		[FieldOffset(3650 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public UInt32 RemoteFxCodecId;  /* 3650 */
		[FieldOffset(3651 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public UInt32 RemoteFxCodecMode;  /* 3651 */
		[FieldOffset(3652 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public int RemoteFxImageCodec;  /* 3652 */
		[FieldOffset(3653 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public UInt32 RemoteFxCaptureFlags;  /* 3653 */
		[FieldOffset(3654 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public fixed UInt64 padding3712[3712 - 3654];  /* 3654 */

		/* NSCodec */
		[FieldOffset(3712 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public int NSCodec;  /* 3712 */
		[FieldOffset(3713 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public UInt32 NSCodecId;  /* 3713 */
		[FieldOffset(3714 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public UInt32 FrameAcknowledge;  /* 3714 */
		[FieldOffset(3715 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public fixed UInt64 padding3776[3776 - 3715];  /* 3715 */

		/* JPEG */
		[FieldOffset(3776 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public int JpegCodec;  /* 3776 */
		[FieldOffset(3777 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public UInt32 JpegCodecId;  /* 3777 */
		[FieldOffset(3778 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public UInt32 JpegQuality;  /* 3778 */
		[FieldOffset(3779 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public fixed UInt64 padding3840[3840 - 3779];  /* 3779 */
		[FieldOffset(3840 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6)] public fixed UInt64 padding3904[3904 - 3779];  /* 3840 */

		private const int Bug8 = 488;
		/**
			* Caches
			*/

		/* Bitmap Cache V3 */
		[FieldOffset(3904 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public UInt32 BitmapCacheV3CodecId;  /* 3904 */
		[FieldOffset(3905 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public fixed UInt64 padding3968[3968 - 3905];  /* 3905 */

		/* Draw Nine Grid */
		[FieldOffset(3968 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public int DrawNineGridEnabled;  /* 3968 */
		[FieldOffset(3969 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public UInt32 DrawNineGridCacheSize;  /* 3969 */
		[FieldOffset(3970 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public UInt32 DrawNineGridCacheEntries;  /* 3970 */
		[FieldOffset(3971 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public fixed UInt64 padding4032[4032 - 3971];  /* 3971 */

		/* Draw GDI+ */
		[FieldOffset(4032 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public int DrawGdiPlusEnabled;  /* 4032 */
		[FieldOffset(4033 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public int DrawGdiPlusCacheEnabled;  /* 4033 */
		[FieldOffset(4034 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public fixed UInt64 padding4096[4096 - 4034];  /* 4034 */
		[FieldOffset(4096 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public fixed UInt64 padding4160[4160 - 4096];  /* 4096 */

		/**
			* Device Redirection
			*/

		/* Device Redirection */
		[FieldOffset(4160 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public int DeviceRedirection;  /* 4160 */
		[FieldOffset(4161 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public UInt32 DeviceCount;  /* 4161 */
		[FieldOffset(4162 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public UInt32 DeviceArraySize;  /* 4162 */
		[FieldOffset(4163 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public IntPtr DeviceArray;  /* 4163 */
		[FieldOffset(4164 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public fixed UInt64 padding4288[4288 - 4164];  /* 4164 */

		/* Drive Redirection */
		[FieldOffset(4288 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public int RedirectDrives;  /* 4288 */
		[FieldOffset(4289 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public int RedirectHomeDrive;  /* 4289 */
		[FieldOffset(4290 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public char* DrivesToRedirect;  /* 4290 */
		[FieldOffset(4291 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public fixed UInt64 padding4416[4416 - 4291];  /* 4291 */

		/* Smartcard Redirection */
		[FieldOffset(4416 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public int RedirectSmartCards;  /* 4416 */
		[FieldOffset(4417 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public fixed UInt64 padding4544[4544 - 4417];  /* 4417 */

		/* Printer Redirection */
		[FieldOffset(4544 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public int RedirectPrinters;  /* 4544 */
		[FieldOffset(4545 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public fixed UInt64 padding4672[4672 - 4545];  /* 4545 */

		/* Serial and Parallel Port Redirection */
		[FieldOffset(4672 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public int RedirectSerialPorts;  /* 4672 */
		[FieldOffset(4673 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public int RedirectParallelPorts;  /* 4673 */
		[FieldOffset(4674 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public fixed UInt64 padding4800[4800 - 4674];  /* 4674 */

		/**
			* Other Redirection
			*/

		[FieldOffset(4800 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public int RedirectClipboard;  /* 4800 */
		[FieldOffset(4801 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public fixed UInt64 padding4928[4928 - 4801];  /* 4801 */

		/**
			* Static Virtual Channels
			*/

		[FieldOffset(4928 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public UInt32 StaticChannelCount;  /* 4928 */
		[FieldOffset(4929 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public UInt32 StaticChannelArraySize;  /* 4929 */
		[FieldOffset(4930 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public IntPtr StaticChannelArray;  /* 4930 */
		[FieldOffset(4931 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public fixed UInt64 padding5056[5056 - 4931];  /* 4931 */

		/**
			* Dynamic Virtual Channels
			*/

		[FieldOffset(5056 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public UInt32 DynamicChannelCount;  /* 5056 */
		[FieldOffset(5057 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public UInt32 DynamicChannelArraySize;  /* 5057 */
		[FieldOffset(5058 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public IntPtr DynamicChannelArray;  /* 5058 */
		[FieldOffset(5059 * 8 + Bug1 + Bug2 + Bug3 + Bug7 + Bug9 + Bug10 + Bug4 + Bug5 + Bug6 + Bug8)] public fixed UInt64 padding5184[5184 - 5059];  /* 5059 */

		/**
			* WARNING: End of ABI stable zone!
			*
			* The zone below this point is ABI unstable, and
			* is therefore potentially subject to ABI breakage.
			*/

		/*
			* Extensions
			*/

		/* Extensions */
		//ALIGN64 int num_extensions; /*  */
		//ALIGN64 struct rdp_ext_set extensions[16]; /*  */
	
		//ALIGN64 IntPtr settings_modified; /* byte array marking fields that have been modified from their default value */
	};
}

