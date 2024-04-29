using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions.Types
{
    public class ValidationException : Exception
    {
        public IEnumerable<string> Errors { get; set; }     // birden fazla hata için

        public ValidationException(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
