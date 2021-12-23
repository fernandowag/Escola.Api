namespace Escola.Api.CrossCutting.Exceptions
{
    public class NotFoundException : UserFrendlyException
    {
        public NotFoundException(UserFrendlyCode userFrendlyCode,
            params object[] messageArgs) : base(userFrendlyCode, messageArgs)
        {

        }
    }
}
