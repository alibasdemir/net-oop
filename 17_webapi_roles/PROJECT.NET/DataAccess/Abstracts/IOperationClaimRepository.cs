using Core.DataAccess;
using Entities;     // Core.Entites değil Entites olmalı (Enties içine OperationClaim ekleme işlemlerinden sonra)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IOperationClaimRepository : IRepository<OperationClaim>, IAsyncRepository<OperationClaim>  // OperationClaim için repomuzu oluşturduk
    {
    }
}
