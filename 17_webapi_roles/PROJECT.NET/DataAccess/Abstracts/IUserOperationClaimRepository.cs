using Core.DataAccess;
using Entities; // // Core.Entites değil Entites olmalı (Enties içine UserOperationClaim ekleme işlemlerinden sonra)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IUserOperationClaimRepository : IRepository<UserOperationClaim>, IAsyncRepository<UserOperationClaim>  // UserOperationClaim için repo oluşturduk
    {
    }
}
