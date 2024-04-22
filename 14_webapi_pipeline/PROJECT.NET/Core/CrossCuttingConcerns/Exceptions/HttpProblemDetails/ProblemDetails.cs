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

// https://github.dev/kodlamaio-projects/nArchitecture.Core/tree/61ba9a8357308bfb76c1d9ed7fdebd38c90044e9
// Bu linkten Exceptionslar detaylı olarak incelenebilir. Problemdetails kısmı, json'a yazma kısmı, extension haline getirilmiş hali, error typelar vs incelenebilir.
