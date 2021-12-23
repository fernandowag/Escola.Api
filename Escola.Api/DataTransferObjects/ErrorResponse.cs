using Escola.Api.CrossCutting;
using Escola.Api.CrossCutting.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Escola.Api.DataTransferObjects
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {

        }
        public string Code { get; set; }
        public string Message { get; set; }
           
    }
}
