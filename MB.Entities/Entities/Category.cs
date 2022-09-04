using MB.Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Entity.Entities
{
    public class Category:BaseEntity
    {
        #region ctor
        public Category() { }
        public Category(string name)
        {
            this.Name = name;
        }
        #endregion

        #region property
        public string Name { get; set; }
        #endregion
        public ICollection<Product> Products { get; set; }

    }
}
