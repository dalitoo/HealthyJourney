using HealthyJourney.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthyJourney.Data.Repositories
{
	public abstract class BadgeRepository<Badge> : IRepository<Badge> where Badge : class
	{
		private HealthyJourneyContext dataContext;
		private IDbSet<Badge> dbset;
		IDatabaseFactory databaseFactory;
		protected BadgeRepository(IDatabaseFactory dbFactory)
		{
			this.databaseFactory = dbFactory;
			dbset = DataContext.Set<Badge>();
		}
		protected HealthyJourneyContext DataContext
		{
			get { return dataContext = databaseFactory.DataContext; }
		}
		public virtual void Add(Badge badge)
		{
			dbset.Add(badge);
		}
		public virtual void Update(Badge badge)
		{
			dbset.Attach(badge);
			dataContext.Entry(badge).State = EntityState.Modified;
		}
		public virtual void Delete(Badge badge)
		{
			dbset.Remove(badge);
		}
		public virtual void Delete(Expression<Func<Badge, bool>> where)
		{
			IEnumerable<Badge> objects = dbset.Where<Badge>(where).AsEnumerable();
			foreach (Badge obj in objects)
				dbset.Remove(obj);
		}
		public virtual Badge GetById(long id)
		{
			return dbset.Find(id);
		}
		public virtual Badge GetById(string id)
		{
			return dbset.Find(id);
		}
		public virtual IEnumerable<Badge> GetAll()
		{
			return dbset.ToList();
		}
		public virtual IEnumerable<Badge> GetMany(Expression<Func<Badge, bool>> where)
		{
			return dbset.Where(where).ToList();
		}
		public Badge Get(Expression<Func<Badge, bool>> where)
		{
			return dbset.First(where);
		}
	}

}
