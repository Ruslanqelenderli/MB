using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Concrete.DTOs.CategoryDtos
{
    public class CategoryUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
