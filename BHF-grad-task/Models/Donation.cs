using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace BHF_grad_task.Models
{
    public class Donation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DonationID { get; set; }
        
        
        [Range(1, 5000)]
        [DataType(DataType.Currency)]
        [Display(Name = "Other amount")]
        public decimal Money { get; set; }

        [Display(Name = "Donation Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DonationDate { get; set; }

        public string Regularity { get; set; }

        
        public int UserID { get; set; }

        public virtual User User { get; set; }



    }

    //public class DonationDBContext : DbContext
    //{
    //    public DbSet<Donation> DonationDB { get; set; }

    //    protected override void OnModelCreating(ModuleBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Donation>.HasKey(x => x.donationId);
    //        base.OnModelCreating(modelBuilder);
    //    }
    //}
}    
    