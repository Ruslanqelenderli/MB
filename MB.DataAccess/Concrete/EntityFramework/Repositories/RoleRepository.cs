using MB.DataAccess.Abstract;
using MB.DataAccess.Concrete.EntityFramework.Context;
using MB.DataAccess.Concrete.EntityFramework.Repositories.GenericRepository;
using MB.DataAccess.Concrete.ReturnResult;
using MB.Entity.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.DataAccess.Concrete.EntityFramework.Repositories
{
    public class RoleRepository : EFGenericRepository<AppRole, DataAccessReturnResult<AppRole>, MBDbContext>, IRoleRepository
    {
        public RoleRepository(MBDbContext context) : base(context) { }
    }
}
