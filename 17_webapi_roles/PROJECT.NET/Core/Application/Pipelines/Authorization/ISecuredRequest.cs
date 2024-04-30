using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Authorization
{
    public interface ISecuredRequest    // işaretleme için kullanacağız ve bunu AuthorizationBehavior'da kullanacağız. sadece ISecuredRequest ile işaretlenmiş istekleri pipeline üzerinden geçir diyeceğiz
    {
        public string[] RequiredRoles { get; }     // ISecuredRequest'e bize bir RequiredRoles listesi ver diyoruz. ve set etmeyeceğimiz için setter'ı siliyoruz
    }
}
