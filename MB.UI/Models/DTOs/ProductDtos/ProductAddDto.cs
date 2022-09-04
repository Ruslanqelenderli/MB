using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.UI.Models.DTOs.ProductDtos
{
    public class ProductAddDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public int Count { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AppUserId { get; set; }
    }
}
