namespace BHF_grad_task.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BHF_grad_task.DataAccessLayer.BHFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLayer.BHFContext context)
        {
            context.donateDB.AddOrUpdate(i => i.DonationID,
                new Donation
                {
                    Money = 10.00M,
                    DonationDate = new DateTime(2016, 11, 12, 12, 33, 41),
                    Regularity = "None"
                },

                new Donation
                {
                    Money = 10.00M,
                    DonationDate = new DateTime(2016, 11, 16, 15, 43, 46),
                    Regularity = "None"
                }
                );

                context.userDB.AddOrUpdate(i => i.UserID,
                    new User
                    {
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
        }
    }
}
