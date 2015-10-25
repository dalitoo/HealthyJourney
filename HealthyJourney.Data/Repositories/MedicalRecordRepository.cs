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
	public abstract class MedicalRecordRepository<MedicalRecord> : IRepository<MedicalRecord> where MedicalRecord : class
	{
		private HealthyJourneyContext dataContext;
		private IDbSet<MedicalRecord> dbset;
		IDatabaseFactory databaseFactory;
		protected MedicalRecordRepository(IDatabaseFactory dbFactory)
		{
			this.databaseFactory = dbFactory;
			dbset = DataContext.Set<MedicalRecord>();
		}
		protected HealthyJourneyContext DataContext
		{
			get { return dataContext = databaseFactory.DataContext; }
		}
		public virtual void Add(MedicalRecord medicalRecord)
		{
			dbset.Add(medicalRecord);
		}
		public virtual void Update(MedicalRecord medicalRecord)
		{
			dbset.Attach(medicalRecord);
			dataContext.Entry(medicalRecord).State = EntityState.Modified;
		}
		public virtual void Delete(MedicalRecord medicalRecord)
		{
			dbset.Remove(medicalRecord);
		}
		public virtual void Delete(Expression<Func<MedicalRecord, bool>> where)
		{
			IEnumerable<MedicalRecord> objects = dbset.Where<MedicalRecord>(where).AsEnumerable();
			foreach (MedicalRecord obj in objects)
				dbset.Remove(obj);
		}
		public virtual MedicalRecord GetById(long id)
		{
			return dbset.Find(id);
		}
		public virtual MedicalRecord GetById(string id)
		{
			return dbset.Find(id);
		}
		public virtual IEnumerable<MedicalRecord> GetAll()
		{
			return dbset.ToList();
		}
		public virtual IEnumerable<MedicalRecord> GetMany(Expression<Func<MedicalRecord, bool>> where)
		{
			return dbset.Where(where).ToList();
		}
		public MedicalRecord Get(Expression<Func<MedicalRecord, bool>> where)
		{
			return dbset.First(where);
		}
	}

}
