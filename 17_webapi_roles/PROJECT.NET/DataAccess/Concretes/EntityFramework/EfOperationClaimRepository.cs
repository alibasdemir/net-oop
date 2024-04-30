using Core.DataAccess;
using Entities; // Core.Entites değil Entites olmalı (Enties içine OperationClaim ekleme işlemlerinden sonra)
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfOperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
    {
        public EfOperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
