using iPremium.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iPremium.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MotorCal : GradientContentPage
    {
        public MotorCal()
        {
            InitializeComponent();
        }

        private void CalculateButton_Clicked(object sender, EventArgs e)
        {
            double basicPremium;
            if (xCovertype.SelectedIndex == 0)
            {
                basicPremium = 0.05 * Convert.ToDouble(xValue.Text);
                Xamarin.Essentials.Preferences.Set("BasicPremium", basicPremium);
                Xamarin.Essentials.Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Xamarin.Essentials.Preferences.Set("RegistrationNumber",xRegistrationNumber.Text);
                Xamarin.Essentials.Preferences.Set("VehicleMake",xVehicleMake.Text);
                App.Current.MainPage = new NavigationPage(new ResultPage());
            }
        }
    }
}