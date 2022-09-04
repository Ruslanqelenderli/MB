using MB.DataAccess.Abstract.IGenericRepository;
using MB.Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Abstract.Services.GenericService
{
    public interface IService<TModel, TReturnResult> 
    {
        TReturnResult Delete(Guid Id);
    }
}
