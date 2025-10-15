using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using promotion_net.Models.Products;

namespace promotion_net.Models.Categories
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? Description { get; set; }

        public Guid? ParentId { get; set; }
        public Category? Parent { get; set; }
        public ICollection<Category>? Children { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}