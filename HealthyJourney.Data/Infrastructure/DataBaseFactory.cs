using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyJourney.Data.Infrastructure
{
	public class DatabaseFactory : Disposable, IDatabaseFactory
	{
		private HealthyJourneyContext dataContext;
		public HealthyJourneyContext DataContext { get { return dataContext; } }

		public DatabaseFactory()
		{
			dataContext = new HealthyJourneyContext();
		}
		protected override void DisposeCore()
		{
			if (DataContext != null)
				DataContext.Dispose();
		}
	}

}
