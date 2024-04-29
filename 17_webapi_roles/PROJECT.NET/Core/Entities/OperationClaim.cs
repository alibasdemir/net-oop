using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class OperationClaim : Entity    // operasyon yetkisi üzerine bir sistem kuracağız. Yetkileri gruplandıracağız. örneğin ürün silmeyi sadece moderatör yapacak, ürün eklemeyi admin yapacak. ürün listelemek için yetki olmayacak vs
    {
        public string Name { get; set; }    // ilgili operasyonun ismi örneğin: product.add, product.update, product.delete, product.read, product.write gibi roller 

        // NOT: OLUŞTURDUĞUMUZ TABLOLARI BASEDBCONTEXT'E EKLEMEYİ UNUTMUYORUZ (OperationClaim ve UserOperationClaim)
    }
}
