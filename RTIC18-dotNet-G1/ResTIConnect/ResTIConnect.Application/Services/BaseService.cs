using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Infra.Data.Context;

namespace ResTIConnect.Application.Services
{
    public abstract class BaseService
    {
        protected readonly ResTIConnectContext _context;
        protected BaseService(ResTIConnectContext context)
        {
            _context = context;
        }
    }
}