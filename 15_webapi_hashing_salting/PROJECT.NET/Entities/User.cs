using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User : Entity
    {
        public User() 
        {
        }

        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }    // şifreleri byte array olarak tutarız string olarak tutmayız. Ayrıca şifleri hashleriz. hashingde geri döndürülemez olması karşılaştırabilir olma özelliğini engellemez. yani karşılaştırılabilir ve db işlemlerinde karşılaştırma yapmamıza engel değildir.
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }

    }
}
