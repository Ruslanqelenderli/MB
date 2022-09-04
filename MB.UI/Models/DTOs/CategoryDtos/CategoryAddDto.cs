using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.UI.Models.DTOs.CategoryDtos
{
    public class CategoryAddDto
    {
        [Required]
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
