using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace Tabs
{
	public class AzureManager
	{

		private static AzureManager instance;
		private MobileServiceClient client;
		private IMobileServiceTable<NotaMobileModel> notMobileTable;

		private AzureManager()
		{
			this.client = new MobileServiceClient("http://notamobile.azurewebsites.net");
            this.notMobileTable = this.client.GetTable<NotaMobileModel>();
		}

		public MobileServiceClient AzureClient
		{
			get { return client; }
		}

		public static AzureManager AzureManagerInstance
		{
			get
			{
				if (instance == null)
				{
					instance = new AzureManager();
				}

				return instance;
			}
		}

		public async Task<List<NotaMobileModel>> GetMobileInformation()
		{
			return await this.notMobileTable.ToListAsync();
		}

        public async Task PostMobileInformation(NotaMobileModel notMobileModel)
		{
			await this.notMobileTable.InsertAsync(notMobileModel);
		}
	}
}
