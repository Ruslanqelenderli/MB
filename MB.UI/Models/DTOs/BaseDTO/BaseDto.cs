using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.UI.Models.DTOs.BaseDTO
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
