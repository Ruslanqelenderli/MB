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
    public class ProductRepository:EFGenericRepository<Product,DataAccessReturnResult<Product>,MBDbContext>,IProductRepository
    {
        public ProductRepository(MBDbContext context):base(context) { }
    }
}
