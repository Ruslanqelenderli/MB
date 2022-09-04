using MB.DataAccess.Abstract;
using MB.DataAccess.Concrete.EntityFramework.Context;
using MB.DataAccess.Concrete.EntityFramework.Repositories.GenericRepository;
using MB.DataAccess.Concrete.ReturnResult;
using MB.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.DataAccess.Concrete.EntityFramework.Repositories
{
    public  class CategoryRepository:EFGenericRepository<Category,DataAccessReturnResult<Category>,MBDbContext>,ICategoryRepository
    {
        public CategoryRepository(MBDbContext context):base(context){ }
    }
}
