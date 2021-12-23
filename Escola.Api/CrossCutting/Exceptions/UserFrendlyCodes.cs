using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Api.CrossCutting.Exceptions
{
    public static class UserFrendlyCodes
    {
        public static UserFrendlyCode ParameterNotValid => new UserFrendlyCode {Code = "PARAMMETER_NOT_VALID", Message = "Parameter {0} is not valid." };
        public static UserFrendlyCode NotFound => new UserFrendlyCode { Code = "NOT_FOUND", Message = "No results found for {0} '{1}'." };
    }
}
