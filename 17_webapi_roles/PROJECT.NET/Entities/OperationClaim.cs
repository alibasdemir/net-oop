using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OperationClaim : Core.Entities.OperationClaim
    {
        //OperationClaim içinde UserOperationClaim listesi var. Ara tabloyla ilişkili olduğu. Bunu virtual olarak ekliyoruz
        public virtual List<UserOperationClaim> UserOperationClaim { get; set; }
    }
}
