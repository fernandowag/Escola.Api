using System;

namespace Escola.Api.CrossCutting
{
    public class UserFrendlyException : Exception
    {
        public UserFrendlyCode UserFrendlyCode { get; }

        public UserFrendlyException(UserFrendlyCode userFrendlyCode, params object[] messageArgs)
        {
            UserFrendlyCode = userFrendlyCode;
            UserFrendlyCode.MessageArgs = messageArgs;
        }

        public override string Message => UserFrendlyCode.Message;
    }
}
