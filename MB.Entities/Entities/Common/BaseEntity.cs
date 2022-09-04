using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Entity.Entities.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public  DateTime? UpdateDate { get; set; }
    }
}
