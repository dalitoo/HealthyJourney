using HealthyJourney.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyJourney.Data.Infrastructure
{
	public class UnitOfWork : IUnitOfWork
	{
		private HealthyJourneyContext dataContext;
		IDatabaseFactory dbFactory;
		public UnitOfWork(IDatabaseFactory dbFactory)
		{
			this.dbFactory = dbFactory;
		}
		private IProviderRepository providerRepository;
		public IProviderRepository ProviderRepository
		{
			get { return providerRepository = new ProviderRepository(dbFactory); }
		}
		private ICategoryRepository categoryRepository;
		public ICategoryRepository CategoryRepository
		{
			get { return categoryRepository = new CategoryRepository(dbFactory); }
		}
		private IProductRepository productRepository;
		public IProductRepository ProductRepository
		{
			get { return productRepository = new ProductRepository(dbFactory); }
		}
		protected MyFinanceContext DataContext
		{
			get
			{
				return dataContext = dbFactory.DataContext;
			}
		}
		public void Commit()
		{
			DataContext.SaveChanges();
		}
		public void Dispose()
		{
			dbFactory.Dispose();
		}
	}

}
