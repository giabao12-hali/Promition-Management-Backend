using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace promotion_net.DTO.Products
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
    }
}