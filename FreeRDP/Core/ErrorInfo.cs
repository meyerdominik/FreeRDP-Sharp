using System.Collections.Generic;

namespace FreeRDP.Core
{
	public enum ErrorInfoCode : uint
	{
		ERRINFO_SUCCESS = 0x00000000,
		ERRINFO_RPC_INITIATED_DISCONNECT = 0x00000001,
		ERRINFO_RPC_INITIATED_LOGOFF = 0x00000002,
		ERRINFO_IDLE_TIMEOUT = 0x00000003,
		ERRINFO_LOGON_TIMEOUT = 0x00000004,
		ERRINFO_DISCONNECTED_BY_OTHER_CONNECTION = 0x00000005,
		ERRINFO_OUT_OF_MEMORY = 0x00000006,
		ERRINFO_SERVER_DENIED_CONNECTION = 0x00000007,
		ERRINFO_SERVER_INSUFFICIENT_PRIVILEGES = 0x00000009,
		ERRINFO_SERVER_FRESH_CREDENTIALS_REQUIRED = 0x0000000A,
		ERRINFO_RPC_INITIATED_DISCONNECT_BY_USER = 0x0000000B,
		ERRINFO_LOGOFF_BY_USER = 0x0000000C,
		ERRINFO_LICENSE_INTERNAL = 0x00000100,
		ERRINFO_LICENSE_NO_LICENSE_SERVER = 0x00000101,
		ERRINFO_LICENSE_NO_LICENSE = 0x00000102,
		ERRINFO_LICENSE_BAD_CLIENT_MSG = 0x00000103,
		ERRINFO_LICENSE_HWID_DOESNT_MATCH_LICENSE = 0x00000104,
		ERRINFO_LICENSE_BAD_CLIENT_LICENSE = 0x00000105,
		ERRINFO_LICENSE_CANT_FINISH_PROTOCOL = 0x00000106,
		ERRINFO_LICENSE_CLIENT_ENDED_PROTOCOL = 0x00000107,
		ERRINFO_LICENSE_BAD_CLIENT_ENCRYPTION = 0x00000108,
		ERRINFO_LICENSE_CANT_UPGRADE_LICENSE = 0x00000109,
		ERRINFO_LICENSE_NO_REMOTE_CONNECTIONS = 0x0000010A,
		ERRINFO_UNKNOWN_DATA_PDU_TYPE = 0x000010C9,
		ERRINFO_UNKNOWN_PDU_TYPE = 0x000010CA,
		ERRINFO_DATA_PDU_SEQUENCE = 0x000010CB,
		ERRINFO_CONTROL_PDU_SEQUENCE = 0x000010CD,
		ERRINFO_INVALID_CONTROL_PDU_ACTION = 0x000010CE,
		ERRINFO_INVALID_INPUT_PDU_TYPE = 0x000010CF,
		ERRINFO_INVALID_INPUT_PDU_MOUSE = 0x000010D0,
		ERRINFO_INVALID_REFRESH_RECT_PDU = 0x000010D1,
		ERRINFO_CREATE_USER_DATA_FAILED = 0x000010D2,
		ERRINFO_CONNECT_FAILED = 0x000010D3,
		ERRINFO_CONFIRM_ACTIVE_HAS_WRONG_SHAREID = 0x000010D4,
		ERRINFO_CONFIRM_ACTIVE_HAS_WRONG_ORIGINATOR = 0x000010D5,
		ERRINFO_PERSISTENT_KEY_PDU_BAD_LENGTH = 0x000010DA,
		ERRINFO_PERSISTENT_KEY_PDU_ILLEGAL_FIRST = 0x000010DB,
		ERRINFO_PERSISTENT_KEY_PDU_TOO_MANY_TOTAL_KEYS = 0x000010DC,
		ERRINFO_PERSISTENT_KEY_PDU_TOO_MANY_CACHE_KEYS = 0x000010DD,
		ERRINFO_INPUT_PDU_BAD_LENGTH = 0x000010DE,
		ERRINFO_BITMAP_CACHE_ERROR_PDU_BAD_LENGTH = 0x000010DF,
		ERRINFO_SECURITY_DATA_TOO_SHORT = 0x000010E0,
		ERRINFO_VCHANNEL_DATA_TOO_SHORT = 0x000010E1,
		ERRINFO_SHARE_DATA_TOO_SHORT = 0x000010E2,
		ERRINFO_BAD_SUPPRESS_OUTPUT_PDU = 0x000010E3,
		ERRINFO_CONFIRM_ACTIVE_PDU_TOO_SHORT = 0x000010E5,
		ERRINFO_CAPABILITY_SET_TOO_SMALL = 0x000010E7,
		ERRINFO_CAPABILITY_SET_TOO_LARGE = 0x000010E8,
		ERRINFO_NO_CURSOR_CACHE = 0x000010E9,
		ERRINFO_BAD_CAPABILITIES = 0x000010EA,
		ERRINFO_VIRTUAL_CHANNEL_DECOMPRESSION = 0x000010EC,
		ERRINFO_INVALID_VC_COMPRESSION_TYPE = 0x000010ED,
		ERRINFO_INVALID_CHANNEL_ID = 0x000010EF,
		ERRINFO_VCHANNELS_TOO_MANY = 0x000010F0,
		ERRINFO_REMOTEAPP_NOT_ENABLED = 0x000010F3,
		ERRINFO_CACHE_CAP_NOT_SET = 0x000010F4,
		ERRINFO_BITMAP_CACHE_ERROR_PDU_BAD_LENGTH2 = 0x000010F5,
		ERRINFO_OFFSCREEN_CACHE_ERROR_PDU_BAD_LENGTH = 0x000010F6,
		ERRINFO_DRAWNINEGRID_CACHE_ERROR_PDU_BAD_LENGTH = 0x000010F7,
		ERRINFO_GDIPLUS_PDU_BAD_LENGTH = 0x000010F8,
		ERRINFO_SECURITY_DATA_TOO_SHORT2 = 0x00001111,
		ERRINFO_SECURITY_DATA_TOO_SHORT3 = 0x00001112,
		ERRINFO_SECURITY_DATA_TOO_SHORT4 = 0x00001113,
		ERRINFO_SECURITY_DATA_TOO_SHORT5 = 0x00001114,
		ERRINFO_SECURITY_DATA_TOO_SHORT6 = 0x00001115,
		ERRINFO_SECURITY_DATA_TOO_SHORT7 = 0x00001116,
		ERRINFO_SECURITY_DATA_TOO_SHORT8 = 0x00001117,
		ERRINFO_SECURITY_DATA_TOO_SHORT9 = 0x00001118,
		ERRINFO_SECURITY_DATA_TOO_SHORT10 = 0x00001119,
		ERRINFO_SECURITY_DATA_TOO_SHORT11 = 0x0000111A,
		ERRINFO_SECURITY_DATA_TOO_SHORT12 = 0x0000111B,
		ERRINFO_SECURITY_DATA_TOO_SHORT13 = 0x0000111C,
		ERRINFO_SECURITY_DATA_TOO_SHORT14 = 0x0000111D,
		ERRINFO_SECURITY_DATA_TOO_SHORT15 = 0x0000111E,
		ERRINFO_SECURITY_DATA_TOO_SHORT16 = 0x0000111F,
		ERRINFO_SECURITY_DATA_TOO_SHORT17 = 0x00001120,
		ERRINFO_SECURITY_DATA_TOO_SHORT18 = 0x00001121,
		ERRINFO_SECURITY_DATA_TOO_SHORT19 = 0x00001122,
		ERRINFO_SECURITY_DATA_TOO_SHORT20 = 0x00001123,
		ERRINFO_SECURITY_DATA_TOO_SHORT21 = 0x00001124,
		ERRINFO_SECURITY_DATA_TOO_SHORT22 = 0x00001125,
		ERRINFO_SECURITY_DATA_TOO_SHORT23 = 0x00001126,
		ERRINFO_BAD_MONITOR_DATA = 0x00001129,
		ERRINFO_VC_DECOMPRESSED_REASSEMBLE_FAILED = 0x0000112A,
		ERRINFO_VC_DATA_TOO_LONG = 0x0000112B,
		ERRINFO_GRAPHICS_MODE_NOT_SUPPORTED = 0x0000112D,
		ERRINFO_GRAPHICS_SUBSYSTEM_RESET_FAILED = 0x0000112E,
		ERRINFO_UPDATE_SESSION_KEY_FAILED = 0x00001191,
		ERRINFO_DECRYPT_FAILED = 0x00001192,
		ERRINFO_ENCRYPT_FAILED = 0x00001193,
		ERRINFO_ENCRYPTION_PACKAGE_MISMATCH = 0x00001194,
		ERRINFO_DECRYPT_FAILED2 = 0x00001195,
		ERRINFO_NONE = 0xFFFFFFFF,

	}

	public static class ErrorInfo
	{

		private static Dictionary<ErrorInfoCode, string> ErrorInfoCodeToStr = new Dictionary<ErrorInfoCode, string>()
		{
			{ErrorInfoCode.ERRINFO_SUCCESS, "Success."},
			{
				ErrorInfoCode.ERRINFO_RPC_INITIATED_DISCONNECT,
				"The disconnection was initiated by an administrative tool on the server in another session."
			},
			{
				ErrorInfoCode.ERRINFO_RPC_INITIATED_LOGOFF,
				"The disconnection was due to a forced logoff initiated by an administrative tool on the server in another session."
			},
			{ErrorInfoCode.ERRINFO_IDLE_TIMEOUT, "The idle session limit timer on the server has elapsed."},
			{ErrorInfoCode.ERRINFO_LOGON_TIMEOUT, "The active session limit timer on the server has elapsed."},
			{
				ErrorInfoCode.ERRINFO_DISCONNECTED_BY_OTHER_CONNECTION,
				"Another user connected to the server, forcing the disconnection of the current connection."
			},
			{ErrorInfoCode.ERRINFO_OUT_OF_MEMORY, "The server ran out of available memory resources."},
			{ErrorInfoCode.ERRINFO_SERVER_DENIED_CONNECTION, "The server denied the connection."},
			{
				ErrorInfoCode.ERRINFO_SERVER_INSUFFICIENT_PRIVILEGES,
				"The user cannot connect to the server due to insufficient access privileges."
			},
			{
				ErrorInfoCode.ERRINFO_SERVER_FRESH_CREDENTIALS_REQUIRED,
				"The server does not accept saved user credentials and requires that the user enter their credentials for each connection."
			},
			{
				ErrorInfoCode.ERRINFO_RPC_INITIATED_DISCONNECT_BY_USER,
				"The disconnection was initiated by an administrative tool on the server running in the user's session."
			},
			{
				ErrorInfoCode.ERRINFO_LOGOFF_BY_USER,
				"The disconnection was initiated by the user logging off his or her session on the server."
			},
			{
				ErrorInfoCode.ERRINFO_LICENSE_INTERNAL,
				"An internal error has occurred in the Terminal Services licensing component."
			},
			{
				ErrorInfoCode.ERRINFO_LICENSE_NO_LICENSE_SERVER,
				"A Remote Desktop License Server ([MS-RDPELE] section 1.1) could not be found to provide a license."
			},
			{
				ErrorInfoCode.ERRINFO_LICENSE_NO_LICENSE,
				"There are no Client Access Licenses ([MS-RDPELE] section 1.1) available for the target remote computer."
			},
			{
				ErrorInfoCode.ERRINFO_LICENSE_BAD_CLIENT_MSG,
				"The remote computer received an invalid licensing message from the client."
			},
			{
				ErrorInfoCode.ERRINFO_LICENSE_HWID_DOESNT_MATCH_LICENSE,
				"The Client Access License ([MS-RDPELE] section 1.1) stored by the client has been modified."
			},
			{
				ErrorInfoCode.ERRINFO_LICENSE_BAD_CLIENT_LICENSE,
				"The Client Access License ([MS-RDPELE] section 1.1) stored by the client is in an invalid format."
			},
			{
				ErrorInfoCode.ERRINFO_LICENSE_CANT_FINISH_PROTOCOL,
				"Network problems have caused the licensing protocol ([MS-RDPELE] section 1.3.3) to be terminated."
			},
			{
				ErrorInfoCode.ERRINFO_LICENSE_CLIENT_ENDED_PROTOCOL,
				"The client prematurely ended the licensing protocol ([MS-RDPELE] section 1.3.3)."
			},
			{
				ErrorInfoCode.ERRINFO_LICENSE_BAD_CLIENT_ENCRYPTION,
				"A licensing message ([MS-RDPELE] sections 2.2 and 5.1) was incorrectly encrypted."
			},
			{
				ErrorInfoCode.ERRINFO_LICENSE_CANT_UPGRADE_LICENSE,
				"The Client Access License ([MS-RDPELE] section 1.1) stored by the client could not be upgraded or renewed."
			},
			{
				ErrorInfoCode.ERRINFO_LICENSE_NO_REMOTE_CONNECTIONS,
				"The remote computer is not licensed to accept remote connections."
			},
			{
				ErrorInfoCode.ERRINFO_UNKNOWN_DATA_PDU_TYPE,
				"Unknown pduType2 field in a received Share Data Header (section 2.2.8.1.1.1.2)."
			},
			{
				ErrorInfoCode.ERRINFO_UNKNOWN_PDU_TYPE,
				"Unknown pduType field in a received Share Control Header (section 2.2.8.1.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_DATA_PDU_SEQUENCE,
				"An out-of-sequence Slow-Path Data PDU (section 2.2.8.1.1.1.1) has been received."
			},
			{
				ErrorInfoCode.ERRINFO_CONTROL_PDU_SEQUENCE,
				"An out-of-sequence Slow-Path Non-Data PDU (section 2.2.8.1.1.1.1) has been received."
			},
			{
				ErrorInfoCode.ERRINFO_INVALID_CONTROL_PDU_ACTION,
				"A Control PDU (sections 2.2.1.15 and 2.2.1.16) has been received with an invalid action field."
			},
			{
				ErrorInfoCode.ERRINFO_INVALID_INPUT_PDU_TYPE,
				"(a) A Slow-Path Input Event (section 2.2.8.1.1.3.1.1) has been received with an invalid messageType field.\n(b) A Fast-Path Input Event (section 2.2.8.1.2.2) has been received with an invalid eventCode field."
			},
			{
				ErrorInfoCode.ERRINFO_INVALID_INPUT_PDU_MOUSE,
				"(a) A Slow-Path Mouse Event (section 2.2.8.1.1.3.1.1.3) or Extended Mouse Event (section 2.2.8.1.1.3.1.1.4) has been received with an invalid pointerFlags field.\n(b) A Fast-Path Mouse Event (section 2.2.8.1.2.2.3) or Fast-Path Extended Mouse Event \n(section 2.2.8.1.2.2.4) has been received with an invalid pointerFlags field. "
			},
			{ErrorInfoCode.ERRINFO_INVALID_REFRESH_RECT_PDU, "An invalid Refresh Rect PDU (section 2.2.11.2) has been received."},
			{
				ErrorInfoCode.ERRINFO_CREATE_USER_DATA_FAILED,
				"The server failed to construct the GCC Conference Create Response user data (section 2.2.1.4)."
			},
			{
				ErrorInfoCode.ERRINFO_CONNECT_FAILED,
				"Processing during the Channel Connection phase of the RDP Connection Sequence (see section 1.3.1.1 for an overview of the RDP Connection Sequence phases) has failed."
			},
			{
				ErrorInfoCode.ERRINFO_CONFIRM_ACTIVE_HAS_WRONG_SHAREID,
				"A Confirm Active PDU (section 2.2.1.13.2) was received from the client with an invalid shareId field."
			},
			{
				ErrorInfoCode.ERRINFO_CONFIRM_ACTIVE_HAS_WRONG_ORIGINATOR,
				"A Confirm Active PDU (section 2.2.1.13.2) was received from the client with an invalid originatorId field."
			},
			{
				ErrorInfoCode.ERRINFO_PERSISTENT_KEY_PDU_BAD_LENGTH,
				"There is not enough data to process a Persistent Key List PDU (section 2.2.1.17)."
			},
			{
				ErrorInfoCode.ERRINFO_PERSISTENT_KEY_PDU_ILLEGAL_FIRST,
				"A Persistent Key List PDU (section 2.2.1.17) marked as PERSIST_PDU_FIRST (0x01) was received after the reception of a prior Persistent Key List PDU also marked as PERSIST_PDU_FIRST."
			},
			{
				ErrorInfoCode.ERRINFO_PERSISTENT_KEY_PDU_TOO_MANY_TOTAL_KEYS,
				"A Persistent Key List PDU (section 2.2.1.17) was received which specified a total number of bitmap cache entries larger than 262144."
			},
			{
				ErrorInfoCode.ERRINFO_PERSISTENT_KEY_PDU_TOO_MANY_CACHE_KEYS,
				"A Persistent Key List PDU (section 2.2.1.17) was received which specified an invalid total number of keys for a bitmap cache (the number of entries that can be stored within each bitmap cache is specified in the Revision 1 or 2 Bitmap Cache Capability Set (section 2.2.7.1.4) that is sent from client to server)."
			},
			{
				ErrorInfoCode.ERRINFO_INPUT_PDU_BAD_LENGTH,
				"There is not enough data to process Input Event PDU Data (section 2.2.8.1.1.3.1) or a Fast-Path Input Event PDU (section 2.2.8.1.2)."
			},
			{
				ErrorInfoCode.ERRINFO_BITMAP_CACHE_ERROR_PDU_BAD_LENGTH,
				"There is not enough data to process the shareDataHeader, NumInfoBlocks, Pad1, and Pad2 fields of the Bitmap Cache Error PDU Data ([MS-RDPEGDI] section 2.2.2.3.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT,
				"(a) The dataSignature field of the Fast-Path Input Event PDU (section 2.2.8.1.2) does not contain enough data.\n(b) The fipsInformation and dataSignature fields of the Fast-Path Input Event PDU (section 2.2.8.1.2) do not contain enough data."
			},
			{
				ErrorInfoCode.ERRINFO_VCHANNEL_DATA_TOO_SHORT,
				"(a) There is not enough data in the Client Network Data (section 2.2.1.3.4) to read the virtual channel configuration data.\n(b) There is not enough data to read a complete Channel PDU Header (section 2.2.6.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SHARE_DATA_TOO_SHORT,
				"(a) There is not enough data to process Control PDU Data (section 2.2.1.15.1).\n(b) There is not enough data to read a complete Share Control Header (section 2.2.8.1.1.1.1).\n(c) There is not enough data to read a complete Share Data Header (section 2.2.8.1.1.1.2) of a Slow-Path Data PDU (section 2.2.8.1.1.1.1).\n(d) There is not enough data to process Font List PDU Data (section 2.2.1.18.1)."
			},
			{
				ErrorInfoCode.ERRINFO_BAD_SUPPRESS_OUTPUT_PDU,
				"(a) There is not enough data to process Suppress Output PDU Data (section 2.2.11.3.1).\n(b) The allowDisplayUpdates field of the Suppress Output PDU Data (section 2.2.11.3.1) is invalid."
			},
			{
				ErrorInfoCode.ERRINFO_CONFIRM_ACTIVE_PDU_TOO_SHORT,
				"(a) There is not enough data to read the shareControlHeader, shareId, originatorId, lengthSourceDescriptor, and lengthCombinedCapabilities fields of the Confirm Active PDU Data (section 2.2.1.13.2.1).\n(b) There is not enough data to read the sourceDescriptor, numberCapabilities, pad2Octets, and capabilitySets fields of the Confirm Active PDU Data (section 2.2.1.13.2.1)."
			},
			{
				ErrorInfoCode.ERRINFO_CAPABILITY_SET_TOO_SMALL,
				"There is not enough data to read the capabilitySetType and the lengthCapability fields in a received Capability Set (section 2.2.1.13.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_CAPABILITY_SET_TOO_LARGE,
				"A Capability Set (section 2.2.1.13.1.1.1) has been received with a lengthCapability field that contains a value greater than the total length of the data received."
			},
			{
				ErrorInfoCode.ERRINFO_NO_CURSOR_CACHE,
				"(a) Both the colorPointerCacheSize and pointerCacheSize fields in the Pointer Capability Set (section 2.2.7.1.5) are set to zero.\n(b) The pointerCacheSize field in the Pointer Capability Set (section 2.2.7.1.5) is not present, and the colorPointerCacheSize field is set to zero."
			},
			{
				ErrorInfoCode.ERRINFO_BAD_CAPABILITIES,
				"The capabilities received from the client in the Confirm Active PDU (section 2.2.1.13.2) were not accepted by the server."
			},
			{
				ErrorInfoCode.ERRINFO_VIRTUAL_CHANNEL_DECOMPRESSION,
				"An error occurred while using the bulk compressor (section 3.1.8 and [MS-RDPEGDI] section 3.1.8) to decompress a Virtual Channel PDU (section 2.2.6.1)"
			},
			{
				ErrorInfoCode.ERRINFO_INVALID_VC_COMPRESSION_TYPE,
				"An invalid bulk compression package was specified in the flags field of the Channel PDU Header (section 2.2.6.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_INVALID_CHANNEL_ID,
				"An invalid MCS channel ID was specified in the mcsPdu field of the Virtual Channel PDU (section 2.2.6.1)."
			},
			{
				ErrorInfoCode.ERRINFO_VCHANNELS_TOO_MANY,
				"The client requested more than the maximum allowed 31 static virtual channels in the Client Network Data (section 2.2.1.3.4)."
			},
			{
				ErrorInfoCode.ERRINFO_REMOTEAPP_NOT_ENABLED,
				"The INFO_RAIL flag (0x00008000) MUST be set in the flags field of the Info Packet (section 2.2.1.11.1.1) as the session on the remote server can only host remote applications."
			},
			{
				ErrorInfoCode.ERRINFO_CACHE_CAP_NOT_SET,
				"The client sent a Persistent Key List PDU (section 2.2.1.17) without including the prerequisite Revision 2 Bitmap Cache Capability Set (section 2.2.7.1.4.2) in the Confirm Active PDU (section 2.2.1.13.2)."
			},
			{
				ErrorInfoCode.ERRINFO_BITMAP_CACHE_ERROR_PDU_BAD_LENGTH2,
				"The NumInfoBlocks field in the Bitmap Cache Error PDU Data is inconsistent with the amount of data in the Info field ([MS-RDPEGDI] section 2.2.2.3.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_OFFSCREEN_CACHE_ERROR_PDU_BAD_LENGTH,
				"There is not enough data to process an Offscreen Bitmap Cache Error PDU ([MS-RDPEGDI] section 2.2.2.3.2)."
			},
			{
				ErrorInfoCode.ERRINFO_DRAWNINEGRID_CACHE_ERROR_PDU_BAD_LENGTH,
				"There is not enough data to process a DrawNineGrid Cache Error PDU ([MS-RDPEGDI] section 2.2.2.3.3)."
			},
			{
				ErrorInfoCode.ERRINFO_GDIPLUS_PDU_BAD_LENGTH,
				"There is not enough data to process a GDI+ Error PDU ([MS-RDPEGDI] section 2.2.2.3.4)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT2,
				"There is not enough data to read a Basic Security Header (section 2.2.8.1.1.2.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT3,
				"There is not enough data to read a Non-FIPS Security Header (section 2.2.8.1.1.2.2) or FIPS Security Header (section 2.2.8.1.1.2.3)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT4,
				"There is not enough data to read the basicSecurityHeader and length fields of the Security Exchange PDU Data (section 2.2.1.10.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT5,
				"There is not enough data to read the CodePage, flags, cbDomain, cbUserName, cbPassword, cbAlternateShell, cbWorkingDir, Domain, UserName, Password, AlternateShell, and WorkingDir fields in the Info Packet (section 2.2.1.11.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT6,
				"There is not enough data to read the CodePage, flags, cbDomain, cbUserName, cbPassword, cbAlternateShell, and cbWorkingDir fields in the Info Packet (section 2.2.1.11.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT7,
				"There is not enough data to read the clientAddressFamily and cbClientAddress fields in the Extended Info Packet (section 2.2.1.11.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT8,
				"There is not enough data to read the clientAddress field in the Extended Info Packet (section 2.2.1.11.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT9,
				"There is not enough data to read the cbClientDir field in the Extended Info Packet (section 2.2.1.11.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT10,
				"There is not enough data to read the clientDir field in the Extended Info Packet (section 2.2.1.11.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT11,
				"There is not enough data to read the clientTimeZone field in the Extended Info Packet (section 2.2.1.11.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT12,
				"There is not enough data to read the clientSessionId field in the Extended Info Packet (section 2.2.1.11.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT13,
				"There is not enough data to read the performanceFlags field in the Extended Info Packet (section 2.2.1.11.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT14,
				"There is not enough data to read the cbAutoReconnectLen field in the Extended Info Packet (section 2.2.1.11.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT15,
				"There is not enough data to read the autoReconnectCookie field in the Extended Info Packet (section 2.2.1.11.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT16,
				"The cbAutoReconnectLen field in the Extended Info Packet (section 2.2.1.11.1.1.1) contains a value which is larger than the maximum allowed length of 128 bytes."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT17,
				"There is not enough data to read the clientAddressFamily and cbClientAddress fields in the Extended Info Packet (section 2.2.1.11.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT18,
				"There is not enough data to read the clientAddress field in the Extended Info Packet (section 2.2.1.11.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT19,
				"There is not enough data to read the cbClientDir field in the Extended Info Packet (section 2.2.1.11.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT20,
				"There is not enough data to read the clientDir field in the Extended Info Packet (section 2.2.1.11.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT21,
				"There is not enough data to read the clientTimeZone field in the Extended Info Packet (section 2.2.1.11.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT22,
				"There is not enough data to read the clientSessionId field in the Extended Info Packet (section 2.2.1.11.1.1.1)."
			},
			{
				ErrorInfoCode.ERRINFO_SECURITY_DATA_TOO_SHORT23,
				"There is not enough data to read the Client Info PDU Data (section 2.2.1.11.1)."
			},
			{
				ErrorInfoCode.ERRINFO_BAD_MONITOR_DATA,
				"The monitorCount field in the Client Monitor Data (section 2.2.1.3.6) is invalid."
			},
			{
				ErrorInfoCode.ERRINFO_VC_DECOMPRESSED_REASSEMBLE_FAILED,
				"The server-side decompression buffer is invalid, or the size of the decompressed VC data exceeds the chunking size specified in the Virtual Channel Capability Set (section 2.2.7.1.10)."
			},
			{
				ErrorInfoCode.ERRINFO_VC_DATA_TOO_LONG,
				"The size of a received Virtual Channel PDU (section 2.2.6.1) exceeds the chunking size specified in the Virtual Channel Capability Set (section 2.2.7.1.10)."
			},
			{
				ErrorInfoCode.ERRINFO_GRAPHICS_MODE_NOT_SUPPORTED,
				"The graphics mode requested by the client is not supported by the server."
			},
			{ErrorInfoCode.ERRINFO_GRAPHICS_SUBSYSTEM_RESET_FAILED, "The server-side graphics subsystem failed to reset."},
			{
				ErrorInfoCode.ERRINFO_UPDATE_SESSION_KEY_FAILED,
				"An attempt to update the session keys while using Standard RDP Security mechanisms (section 5.3.7) failed."
			},
			{
				ErrorInfoCode.ERRINFO_DECRYPT_FAILED,
				"(a) Decryption using Standard RDP Security mechanisms (section 5.3.6) failed.\n(b) Session key creation using Standard RDP Security mechanisms (section 5.3.5) failed."
			},
			{ErrorInfoCode.ERRINFO_ENCRYPT_FAILED, "Encryption using Standard RDP Security mechanisms (section 5.3.6) failed."},
			{
				ErrorInfoCode.ERRINFO_ENCRYPTION_PACKAGE_MISMATCH,
				"Failed to find a usable Encryption Method (section 5.3.2) in the encryptionMethods field of the Client Security Data (section 2.2.1.4.3)."
			},
			{
				ErrorInfoCode.ERRINFO_DECRYPT_FAILED2,
				"Unencrypted data was encountered in a protocol stream which is meant to be encrypted with Standard RDP Security mechanisms (section 5.3.6)."
			},
			{ErrorInfoCode.ERRINFO_NONE, ""},

		};

		public static string ErrorInfoCodeToString(this ErrorInfoCode errorInfoCode)
		{
			string str;
			if (ErrorInfoCodeToStr.TryGetValue(errorInfoCode, out str))
			{
				return str;
			}

			return "Unknown error.";
		}
	}
}