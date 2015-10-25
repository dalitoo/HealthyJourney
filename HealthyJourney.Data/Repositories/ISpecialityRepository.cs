using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthyJourney.Data.Repositories
{
	public interface ISpecialityRepository<Speciality> where Speciality : class
	{
		void Add(Speciality speciality);
		void Update(Speciality speciality);
		void Delete(Speciality speciality);
		void Delete(Expression<Func<Speciality, bool>> where);
        Speciality GetById(long Id);
        Speciality GetById(string Id);
        Speciality Get(Expression<Func<Speciality, bool>> where);
		IEnumerable<Speciality> GetAll();
		IEnumerable<Speciality> GetMany(Expression<Func<Speciality, bool>> where);
	}

}
