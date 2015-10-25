using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthyJourney.Data.Repositories
{
	public interface IMedicalRecordRepository<MedicalRecord> where MedicalRecord : class
	{
		void Add(MedicalRecord medicalRecord);
		void Update(MedicalRecord medicalRecord);
		void Delete(MedicalRecord medicalRecord);
		void Delete(Expression<Func<MedicalRecord, bool>> where);
        MedicalRecord GetById(long Id);
        MedicalRecord GetById(string Id);
        MedicalRecord Get(Expression<Func<MedicalRecord, bool>> where);
		IEnumerable<MedicalRecord> GetAll();
		IEnumerable<MedicalRecord> GetMany(Expression<Func<MedicalRecord, bool>> where);
	}

}
