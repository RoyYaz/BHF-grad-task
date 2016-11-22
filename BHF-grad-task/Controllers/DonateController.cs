using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BHF_grad_task.DataAccessLayer;
using BHF_grad_task.Models;

namespace BHF_grad_task.Controllers
{
    public class DonateController : Controller
    {
        private BHFContext db = new BHFContext();

        // GET: Donate
        public ActionResult Index()
        {
            //var query1 = db.donateDB
            //    .Join(db.userDB, 
            //    a => a.userID, b => b.userID, (b, a) => new { Donation = b, User = a });

            //ICollection<DonationUserModel> DUMList;

            var query = from d in db.donateDB
                        join u in db.userDB
                        on d.UserID equals u.UserID
                        select new DonationUserModel()
                        {
                            donation = d, user = u
                        };

            //foreach(var item in query)
            //{
            //    if (item is Donation)
            //    {

            //    }
            //}

            return View(query.ToList());
        }

        // GET: Donate/DonateForm
        public ActionResult DonateForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DonateForm([Bind(Include = "Title, Forename, Surname, Email, NoAddress, Address, Postcode, Telephone")]User user, [Bind(Include = "Money, Regularity")] Donation donation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User email = db.userDB.FirstOrDefault(u => u.Email.ToLower() == user.Email.ToLower());
                    if (email == null)
                    {
                        donation.UserID = user.UserID;
                        donation.DonationDate = DateTime.Now;

                        db.userDB.Add(user);
                        db.donateDB.Add(donation);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        donation.UserID = email.UserID;
                        donation.DonationDate = DateTime.Now;

                        db.donateDB.Add(donation);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    //donation.DonationDate = DateTime.Now;
                    //db.donateDB.Add(donation);
                    //db.userDB.Add(user);
                    //db.SaveChanges();
                    //return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", dex + " Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return RedirectToAction("Index");
        }

        // GET: Donate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.donateDB.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // GET: Donate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonationID,Money,DonationDate,Regularity")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                donation.DonationDate = DateTime.Now;
                db.donateDB.Add(donation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donation);
        }

        // GET: Donate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.donateDB.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: Donate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonationID,Money,DonationDate,Regularity")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                donation.DonationDate = DateTime.Now;
                db.Entry(donation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donation);
        }

        // GET: Donate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.donateDB.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: Donate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donation donation = db.donateDB.Find(id);
            db.donateDB.Remove(donation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
