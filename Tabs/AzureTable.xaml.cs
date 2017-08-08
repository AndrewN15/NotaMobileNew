using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Tabs
{
    public partial class AzureTable : ContentPage
    {
		Geocoder geoCoder;
       
        public AzureTable()
        {
            InitializeComponent();
            geoCoder = new Geocoder();

		}

		async void Handle_ClickedAsync(object sender, System.EventArgs e)
		{
            loading.IsRunning = true;
			List<NotaMobileModel> notMobileInformation = await AzureManager.AzureManagerInstance.GetMobileInformation();

			foreach (NotaMobileModel model in notMobileInformation)
			{
				var position = new Position(model.Latitude, model.Longitude);
				var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
				foreach (var address in possibleAddresses)
                    model.City = address;
			}

			MobileList.ItemsSource = notMobileInformation;
            loading.IsRunning = false;
		}

    }
}
