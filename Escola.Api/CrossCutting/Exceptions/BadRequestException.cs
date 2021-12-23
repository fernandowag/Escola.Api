using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Api.CrossCutting.Exceptions
{
    public class BadRequestException : UserFrendlyException
    {
        public BadRequestException(UserFrendlyCode userFrendlyCode,
            params object[] messageArgs) : base(userFrendlyCode, messageArgs)
        {
            
        }
    }
}
