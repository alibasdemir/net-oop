using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Authorization
{
    public interface ISecuredRequest    // işaretleme için kullanacağız ve bunu AuthorizationBehavior'da kullanacağız. sadece ISecuredRequest ile işaretlenmiş istekleri pipeline üzerinden geçir diyeceğiz
    {
    }
}
