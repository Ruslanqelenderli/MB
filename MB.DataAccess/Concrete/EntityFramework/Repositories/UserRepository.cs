using MB.DataAccess.Abstract;
using MB.DataAccess.Concrete.EntityFramework.Context;
using MB.DataAccess.Concrete.EntityFramework.Repositories.GenericRepository;
using MB.DataAccess.Concrete.ReturnResult;
using MB.Entity.Entities;
using MB.Entity.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.DataAccess.Concrete.EntityFramework.Repositories
{
    public class UserRepository : EFGenericRepository<AppUser, DataAccessReturnResult<AppUser>, MBDbContext>, IUserRepository
    {
        public UserRepository(MBDbContext context) : base(context) { }
    }
}
