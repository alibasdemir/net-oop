using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class ProblemDetails
    {
        public string Title { get; set; }
        public string Detail {  get; set; }
        public string Type {  get; set; }
    }
}
