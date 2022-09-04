﻿using MB.DataAccess.Abstract.IGenericRepository;
using MB.DataAccess.Concrete.ReturnResult;
using MB.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.DataAccess.Abstract
{
    public interface ICategoryRepository:IRepository<Category,DataAccessReturnResult<Category>>,IAsyncRepository<Category, DataAccessReturnResult<Category>>
    {
    }
}
