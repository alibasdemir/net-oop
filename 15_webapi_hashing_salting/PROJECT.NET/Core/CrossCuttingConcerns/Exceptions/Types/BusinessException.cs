using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions.Types
{
    public class BusinessException : Exception   // Exception'dan miras almayı unutmuyoruz, sonuçta bu oluşturduğumuz da bir Exception
    {
        public BusinessException(string? message) : base(message)   // içerisine mesaj alabilmesi için mesaj üreten constructor oluşturduk
        {
        }
    }
}
