

using System.Runtime.Serialization;

namespace IntegerArrayMath
{
    [Serializable]
    internal class NonIntResultException : Exception
    {
        private int v1;
        private int v2;

        public NonIntResultException()
        {
        }

        public NonIntResultException(string? message) : base(message)
        {
        }

        public NonIntResultException(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public NonIntResultException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NonIntResultException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}