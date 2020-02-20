using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheapAwesome.Domain.Models.Response
{
    public class CommonResponse
    {
        public CommonResponse()
        {

        }

        public CommonResponse(string msg)
        {
            Message = msg;
        }
        [JsonProperty("data")]
        public object Data { get; set; }

        public string Details { get; set; }
        public string Message { get; set; }
        public string MessageCode { get; set; }
        public int StatusCode { get; set; }
        public bool Successful { get; set; }
        [JsonProperty("errors")]
        public List<ValidationError> Errors { get; set; }


        public static CommonResponse CreateSuccessResponse(string msg, object data = null, int stausCode = 200, string messageCode = "")
        {
            return new CommonResponse()
            {
                Data = data,
                Message = msg,
                Successful = true,
                StatusCode = stausCode,
                MessageCode = messageCode
            };
        }
        public static CommonResponse CreateErrorResponse(string msg, object data = null, int stausCode = 200, string messageCode = "")
        {
            return new CommonResponse()
            {
                Data = data,
                Message = msg,
                Successful = false,
                StatusCode = stausCode,
                MessageCode = messageCode
            };
        }

        public static CommonResponse CreateValidationErrorResponse(ModelStateDictionary modelState)
        {
            return new CommonResponse()
            {
                Message = "Validation Failed",
                Errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList(),
                StatusCode = StatusCodes.Status422UnprocessableEntity
            };
        }

    }


}
