using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace BHF_grad_task.Models
{
    public class Donation
    {
        protected int donateID { get; set; }

        
        [Range(1, 5000)]
        [DataType(DataType.Currency)]
        protected decimal money { get; set; }

        [Display(Name = "DateTime")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        protected DateTime dateTime { get; set; }

        protected string regularity { get; set; }

        public class DonationDBContext : DbContext
        {
            public DbSet<Donation> DonationDB { get; set; }
        }
    }
}    
    