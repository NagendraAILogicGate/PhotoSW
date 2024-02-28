using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	public enum IMAPI_FORMAT2_DATA_MEDIA_STATE
	{
		[TypeLibVar(64)]
		IMAPI_FORMAT2_DATA_MEDIA_STATE_UNKNOWN,
		IMAPI_FORMAT2_DATA_MEDIA_STATE_OVERWRITE_ONLY,
		IMAPI_FORMAT2_DATA_MEDIA_STATE_RANDOMLY_WRITABLE = 1,
		IMAPI_FORMAT2_DATA_MEDIA_STATE_BLANK,
		IMAPI_FORMAT2_DATA_MEDIA_STATE_APPENDABLE = 4,
		IMAPI_FORMAT2_DATA_MEDIA_STATE_FINAL_SESSION = 8,
		IMAPI_FORMAT2_DATA_MEDIA_STATE_INFORMATIONAL_MASK = 15,
		IMAPI_FORMAT2_DATA_MEDIA_STATE_DAMAGED = 1024,
		IMAPI_FORMAT2_DATA_MEDIA_STATE_ERASE_REQUIRED = 2048,
		IMAPI_FORMAT2_DATA_MEDIA_STATE_NON_EMPTY_SESSION = 4096,
		IMAPI_FORMAT2_DATA_MEDIA_STATE_WRITE_PROTECTED = 8192,
		IMAPI_FORMAT2_DATA_MEDIA_STATE_FINALIZED = 16384,
		IMAPI_FORMAT2_DATA_MEDIA_STATE_UNSUPPORTED_MEDIA = 32768,
		IMAPI_FORMAT2_DATA_MEDIA_STATE_UNSUPPORTED_MASK = 64512
	}
}
