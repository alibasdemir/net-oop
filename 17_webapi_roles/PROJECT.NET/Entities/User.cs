﻿using Core.DataAccess;
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
        // User'ın içinde UserOperationClaim ile ortak tabloyla çalıştığımız alandır. Virtual olarak ekliyoruz
        public virtual List<UserOperationClaim> UserOperationClaim { get; set; }
    }
}
