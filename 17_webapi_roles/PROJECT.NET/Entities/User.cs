using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User : BaseUser
    {
        // buradaki özellikleri core katmanındaki BaseUser'a ekledik ve bu alanları artık BaseUser'dan miras alıyoruz. Eğer user'ı genişletmek istersek burada tanımlayabiliriz.
    }
}
