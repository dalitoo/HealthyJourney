using HealthyJourney.Data.Infrastructure;
using HealthyJourney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthyJourney.Data.Repositories
{
	public abstract class UserRepository<User> : IRepository<User> where User : class
	{
		private HealthyJourneyContext dataContext;
		private IDbSet<User> dbset;
		IDatabaseFactory databaseFactory;
		protected UserRepository(IDatabaseFactory dbFactory)
		{
			this.databaseFactory = dbFactory;
			dbset = DataContext.Set<User>();
		}
		protected HealthyJourneyContext DataContext
		{
			get { return dataContext = databaseFactory.DataContext; }
		}
		public virtual void Add(User user)
		{
			dbset.Add(user);
		}
		public virtual void Update(User user)
		{
			dbset.Attach(user);
			dataContext.Entry(user).State = EntityState.Modified;
		}
		public virtual void Delete(User user)
		{
			dbset.Remove(user);
		}
		public virtual void Delete(Expression<Func<User, bool>> where)
		{
			IEnumerable<User> objects = dbset.Where<User>(where).AsEnumerable();
			foreach (User obj in objects)
				dbset.Remove(obj);
		}
		public virtual User GetById(long id)
		{
			return dbset.Find(id);
		}
		public virtual User GetById(string id)
		{
			return dbset.Find(id);
		}
		public virtual IEnumerable<User> GetAll()
		{
			return dbset.ToList();
		}
        public IEnumerable<Admin> GetAllAdmins()
        {
            return dbset.OfType<Admin>().ToList();
        }
        public IEnumerable<Client> GetAllClients()
        {
            return dbset.OfType<Client>().ToList();
        }
        public IEnumerable<Consultant> GetAllConsultants()
        {
            return dbset.OfType<Consultant>().ToList();
        }
        public IEnumerable<Doctor> GetAllDoctors()
        {
            return dbset.OfType<Doctor>().ToList();
        }
        public IEnumerable<Insurance> GetAllInsurances()
        {
            return dbset.OfType<Insurance>().ToList();
        }
        public IEnumerable<MedicalCenter> GetAllMedicalCenters()
        {
            return dbset.OfType<MedicalCenter>().ToList();
        }




        public virtual IEnumerable<User> GetMany(Expression<Func<User, bool>> where)
		{
			return dbset.Where(where).ToList();
		}
		public User Get(Expression<Func<User, bool>> where)
		{
			return dbset.First(where);
		}
	}

}
