﻿using Core.DataAccess;
using Entities;     // Core.Entites değil Entites olmalı (Enties içine UserOperationClaim ekleme işlemlerinden sonra)
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfUserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
    {
        public EfUserOperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
 