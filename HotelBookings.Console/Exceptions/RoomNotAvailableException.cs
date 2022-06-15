using System;
using System.Runtime.Serialization;

namespace HotelBookings.Console
{
    [Serializable]
    internal class RoomNotAvailableException : Exception
    {
        public RoomNotAvailableException()
        {
        }

        public RoomNotAvailableException(string message) : base(message)
        {
        }

        public RoomNotAvailableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RoomNotAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}