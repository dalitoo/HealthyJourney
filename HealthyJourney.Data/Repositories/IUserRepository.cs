using HealthyJourney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthyJourney.Data.Repositories
{
	public interface IUserRepository<User> where User : class
	{
		void Add(User user);
		void Update(User user);
		void Delete(User user);
		void Delete(Expression<Func<User, bool>> where);
        User GetById(long Id);
        User GetById(string Id);
    
		IEnumerable<User> GetAll();
        IEnumerable<Admin> GetAllAdmins();
        IEnumerable<Doctor> GetAllDoctors();
        IEnumerable<Consultant> GetAllConsultants();
        IEnumerable<Insurance> GetAllInsurances();

        IEnumerable<Client> GetAllClients();
        IEnumerable<MedicalCenter> GetAllMedicalCenters();


        User Get(Expression<Func<User, bool>> where);
        IEnumerable<User> GetMany(Expression<Func<User, bool>> where);
	}

}
