namespace BHF_grad_task.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.BHFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLayer.BHFContext context)
        {
            context.userDB.AddOrUpdate(i => i.UserID,
                new User
                {
                    UserID = 1,
                    Title = "Mr",
                    Forename = "Tim",
                    Surname = "Marsh",
                    Email = "tim@hotmail.com",
                    NoAddress = "180",
                    Address = "Hampstead Rd",
                    PostCode = "NW1 7AW",
                    Telephone = "02085320140"
                },

                new User
                {
                    UserID = 2,
                    Title = "Mr",
                    Forename = "Roy",
                    Surname = "Yazbeck",
                    Email = "roy@hotmail.com",
                    NoAddress = "180",
                    Address = "Hampstead Rd",
                    PostCode = "NW1 7AW",
                    Telephone = "02079350185"
                }
                );

            context.donateDB.AddOrUpdate(i => i.DonationID,
                new Donation
                {
                    UserID =1,
                    Money = 10.00M,
                    DonationDate = DateTime.Now,
                    Regularity = "One-off"
                },

                new Donation
                {
                    UserID = 2,
                    Money = 10.00M,
                    DonationDate = DateTime.Now,
                    Regularity = "One-off"
                }
                );
        }
    }
}
