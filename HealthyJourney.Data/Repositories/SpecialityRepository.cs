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
	public abstract class SpecialityRepository<Speciality> : IRepository<Speciality> where Speciality : class
	{
		private HealthyJourneyContext dataContext;
		private IDbSet<Speciality> dbset;
		IDatabaseFactory databaseFactory;
		protected SpecialityRepository(IDatabaseFactory dbFactory)
		{
			this.databaseFactory = dbFactory;
			dbset = DataContext.Set<Speciality>();
		}
		protected HealthyJourneyContext DataContext
		{
			get { return dataContext = databaseFactory.DataContext; }
		}
		public virtual void Add(Speciality speciality)
		{
			dbset.Add(speciality);
		}
		public virtual void Update(Speciality speciality)
		{
			dbset.Attach(speciality);
			dataContext.Entry(speciality).State = EntityState.Modified;
		}
		public virtual void Delete(Speciality speciality)
		{
			dbset.Remove(speciality);
		}
		public virtual void Delete(Expression<Func<Speciality, bool>> where)
		{
			IEnumerable<Speciality> objects = dbset.Where<Speciality>(where).AsEnumerable();
			foreach (Speciality obj in objects)
				dbset.Remove(obj);
		}
		public virtual Speciality GetById(long id)
		{
			return dbset.Find(id);
		}
		public virtual Speciality GetById(string id)
		{
			return dbset.Find(id);
		}
		public virtual IEnumerable<Speciality> GetAll()
		{
			return dbset.ToList();
		}
		public virtual IEnumerable<Speciality> GetMany(Expression<Func<Speciality, bool>> where)
		{
			return dbset.Where(where).ToList();
		}
		public Speciality Get(Expression<Func<Speciality, bool>> where)
		{
			return dbset.First(where);
		}
	}

}
