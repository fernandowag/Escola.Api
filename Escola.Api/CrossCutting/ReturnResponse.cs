using System;

namespace Escola.Api.CrossCutting
{
    public class ReturnResponse
    {
        public string Mensagem { get; set; }

        public ReturnResponse(Exception e)
        {
            this.Mensagem = e.Message.ToString();
        }

    }
}
