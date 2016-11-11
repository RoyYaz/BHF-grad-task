using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BHF_grad_task.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public string Title { get; set; }

        [Required]
        [StringLength(35)]
        public string Forename { get; set; }

        [Required]
        [StringLength(35)]
        public string Surname { get; set; }

        [EmailAddress]
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string Email { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        [Required]
        [StringLength(35)]
        public string NoAddress { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]*$")]
        [Required]
        [StringLength(35)]
        public string Address { get; set; }

        [Required]
        [StringLength(8, MinimumLength =6)]
        public string PostCode { get; set; }

        [RegularExpression(@"^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$")]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        
    }

    //public class UserDBContext : DbContext
    //{
    //    public DbSet<User> UserDB { get; set; }
    //}
}