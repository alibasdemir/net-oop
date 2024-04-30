using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    // Bir user birden fazla operationClaim'e sahip olabilir, bir operationClaim birden fazla user'a atanabilir. Örneğin bir user'ın hem read hem delete gibi operasyonu olabilir ve read operasyonu birden fazla user'a verilebilir. Çoktan çoka ilişki, bu yüzden bu ara tabloyu oluşturduk.
    public class UserOperationClaim : Entity    // ARA TABLO
    {
        // Hangi user'ın hangi operationClaim'e atandığını belirleyeceğiz
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        // --- ÖNEMLİ NOT --- İLİŞKİLERDE ARA TABLO BİLE OLSA VIRTUAL ALANLARI EKLEMEYİ UNUTMUYORUZ

        //public virtual BaseUser User { get; set; }
        //public virtual OperationClaim OperationClaim { get; set; }

        // --- ÖNEMLİ NOT --- BU VIRTUAL ALANLARI CORE PAKETİ HİÇBİR YERE BAĞIMLI OLMADAN YAZMAMIZ GEREKİYOR BU YÜZDEN ENTITES KATMANINDA UserOperationClaim oluşturuyoruz ve virtual alanları oraya ekliyoruz. Ayrıca BaseDbContext'te ki en üstte yer alan using Core.Entities'i siliyoruz ve sadece using Entites kullanıyoruz. User.cs içine UserOperationClaim alanını List şeklinde virtual olarak eklemeyi unutmuyoruz 

        // NOT2: AYRICA OLUŞTURDUĞUMUZ TABLOLARI BASEDBCONTEXT'E EKLEMEYİ UNUTMUYORUZ (OperationClaim ve UserOperationClaim)


    }
}
