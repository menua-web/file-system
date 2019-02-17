using System;
using System.Runtime.Serialization;

namespace DAL.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public object ID { get; protected set; }
        protected string _message;
        public EntityNotFoundException(object id) : base()
        {
            this.ID = id;
            _message = $"Entity with ID = {id.ToString()} not found.";
        }

        public EntityNotFoundException(string message) : base(message)
        {
            _message = message;
        }

        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
            _message = message;
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }


        public override string Message => _message;
    }
}
