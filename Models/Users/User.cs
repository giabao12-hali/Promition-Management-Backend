using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using promotion_net.Enum;

namespace promotion_net.Models.Users
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;
        [Required, MaxLength(255)]
        public string PasswordHash { get; set; } = string.Empty;
        public RoleType Role { get; set; } = RoleType.User;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }
    }
}