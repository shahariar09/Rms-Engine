using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rms.Models.Common
{
    public class Result
    {
        private Result(bool succeeded, IEnumerable<string> errors, string sucess)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
            Message = sucess;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }

        public static Result Success(string sucess = "Success")
        {
            return new Result(true,new string[] { },sucess);
        }

        public static Result Failure(IEnumerable<String> errors)
        {
            return new Result(false, errors,null);
        }
    }
}
