using System;
using System.Runtime.Serialization;

namespace Decorator.Core
{
    [Serializable]
    internal class ShardClosedException : Exception
    {
        public ShardClosedException()
        {
        }

        public ShardClosedException(string message) : base(message)
        {
        }

        public ShardClosedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ShardClosedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}