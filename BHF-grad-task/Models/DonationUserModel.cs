using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BHF_grad_task.Models
{
    public class DonationUserModel
    {
        public Donation donation { get; set; }
        public User user { get; set; }
        
    }
}