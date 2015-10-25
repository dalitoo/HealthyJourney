using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthyJourney.Data;
using HealthyJourney.Domain.Entities;

namespace HealthyJourney.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            HealthyJourneyContext ctx = null;
            ctx = new HealthyJourneyContext();

            Admin c = new Admin { UserName = "thaer",Password="thaer",ConfirmPAssword="thaer",Email="thaer.saidi@esprit.tn",IsApproved=false };

            ctx.Users.Add(c);
            ctx.SaveChanges();
        }
    }
}
