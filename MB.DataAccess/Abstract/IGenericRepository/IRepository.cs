
using MB.Entity.Entities.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MB.DataAccess.Abstract.IGenericRepository
{
    public interface IRepository<TEntity, TReturnResult>:IQuery<TEntity> where TEntity:BaseEntity
    {
        TReturnResult Get(Expression<Func<TEntity,bool>> expression,params string[] include);
        TReturnResult GetAll(Expression<Func<TEntity, bool>>? expression = null,
                             bool enableTracking = true,
                             params string[] include);
        TReturnResult Add(TEntity entity);
        TReturnResult Update(TEntity entity);
        TReturnResult Delete(Guid Id);
        TReturnResult DeleteRange(ICollection<TEntity> entities);


    }
}
