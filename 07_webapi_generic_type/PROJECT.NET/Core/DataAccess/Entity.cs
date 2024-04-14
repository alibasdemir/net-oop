using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public class Entity     // TÜM YAPILARDAKİ ORTAK ALANLARIN BULUNDUĞU BİR Entity CLASS'I OLUŞTURUYORUZ ve EfRepositoryBase'de TEntity'nin Entity gibi davranmasını söylüyoruz. (where TEntity : Entity)
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
