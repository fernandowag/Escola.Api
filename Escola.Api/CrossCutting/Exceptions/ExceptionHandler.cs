using Escola.Api.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escola.Api.CrossCutting.Exceptions
{
    public static class ExceptionHandler
    {
        static ErrorResponse errorResponse = new ErrorResponse();
        public static IActionResult GetErrorResponse(Exception ex)
        {
            if (ex is UserFrendlyException exception)
            {
                errorResponse.Code = exception.UserFrendlyCode.Code;
                errorResponse.Message = exception.UserFrendlyCode.Message;

                if (exception is BadRequestException brEx)
                    return new BadRequestObjectResult(errorResponse);
                if (exception is NotFoundException nfEx)
                    return new NotFoundObjectResult(errorResponse);
                return new ObjectResult(errorResponse);
            }
            else
            {
                errorResponse.Code = ex.Message;
                errorResponse.Message = ex.InnerException.Message;
                return new ObjectResult(errorResponse);
            }


        }
    }
}
