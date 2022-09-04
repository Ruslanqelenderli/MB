using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Abstract.Services.GenericService
{
    public interface IAsyncService<TModel, TReturnResult>
    {
        
        
        
        Task<TReturnResult> DeleteAsync(Guid Id);
    }
}
