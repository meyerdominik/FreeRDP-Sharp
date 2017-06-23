using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FreeRDP.Exceptions
{
	[Serializable]
	public class FreeRdpException : Exception
	{
		public FreeRdpException()
		{
		}

		public FreeRdpException(string message) : base(message)
		{
		}

		public FreeRdpException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected FreeRdpException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
