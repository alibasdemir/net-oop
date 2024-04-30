using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserOperationClaim : Core.Entities.UserOperationClaim
    {
        // UserOperationClaim'in içinde OperationClaim ve User alanı vardır, şu user şu rolle bağdaştırılmıştır gibi. bu yüzden bunları virtual olarak ekliyoruz.
        public virtual OperationClaim OperationClaim { get; set; }
        public virtual User User { get; set; }
    }
}
