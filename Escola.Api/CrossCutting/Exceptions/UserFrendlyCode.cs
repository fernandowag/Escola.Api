using System;

namespace Escola.Api.CrossCutting
{
    public class UserFrendlyCode
    {
        public string Code { get; set; }

        public object[] MessageArgs { get; set; } = Array.Empty<object>();

        public string _message;
        public string Message
        {
            get => string.Format(_message, MessageArgs);
            set => _message = value;
        }

    }
}
