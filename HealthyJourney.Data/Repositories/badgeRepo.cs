using HealthyJourney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyJourney.Data.Repositories
{
    class badgeRepo
    {
          
        private HealthyJourneyContext ctx = null;
        public badgeRepo()
        {
            ctx = new HealthyJourneyContext();
        }

        public void AddBadge(Badge b)
        {
            ctx.Badges.Add(b);
            ctx.SaveChanges();
        }

        public IEnumerable<Badge> GetAllBadges()
        {
            
            return ctx.Badges.ToList();

        }
    }
}
