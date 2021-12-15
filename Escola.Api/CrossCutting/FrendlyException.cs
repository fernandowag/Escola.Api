using System;

namespace Escola.Api.CrossCutting
{
    public class FrendlyException : Exception
    {
        public FrendlyException(string mensagem)
        {
            this.Message = mensagem + "detalhes: "+ base.Message;
        }

        public string Message { get; set; }
    }
}
