using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthyJourney.Data.Repositories
{
	public interface IBadgeRepository<Badge> where Badge : class
	{
		void Add(Badge badge);
		void Update(Badge badge);
		void Delete(Badge badge);
		void Delete(Expression<Func<Badge, bool>> where);
        Badge GetById(long Id);
        Badge GetById(string Id);
        Badge Get(Expression<Func<Badge, bool>> where);
		IEnumerable<Badge> GetAll();
		IEnumerable<Badge> GetMany(Expression<Func<Badge, bool>> where);
	}

}
