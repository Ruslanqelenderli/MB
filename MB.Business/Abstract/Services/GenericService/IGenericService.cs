using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Abstract.Services.GenericService
{
    public interface IGenericService<TModel, TReturnResult> :IAsyncService<TModel,TReturnResult>,IService<TModel, TReturnResult>
    {
    }
}
