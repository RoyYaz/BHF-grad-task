using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace BHF_grad_task.Models
{
    public class User
    {
        protected string title { get; set; }

        [Required]
        [StringLength(35)]
        protected string forename { get; set; }

        [Required]
        [StringLength(35)]
        protected string surname { get; set; }

        [EmailAddress]
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        protected string email { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        [Required]
        [StringLength(35)]
        protected string noAddress { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$")]
        [Required]
        [StringLength(35)]
        protected string address { get; set; }

        [Required]
        [StringLength(8, MinimumLength =6)]
        protected string postCode { get; set; }

        [MaxLength(12)]
        protected int telephone { get; set; }

        public class UserDBContext : DbContext
        {
            public DbSet<User> UserDB { get; set; }
        }
    }
}