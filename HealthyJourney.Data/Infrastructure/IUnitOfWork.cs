using HealthyJourney.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyJourney.Data.Infrastructure
{
	public interface IUnitOfWork : IDisposable
	{
		void Commit(); 
        //void Rollback();
		IProviderRepository ProviderRepository { get; }
		ICategoryRepository CategoryRepository { get; }
        IMedicalRecordRepository ProductRepository { get; }
	}

}
