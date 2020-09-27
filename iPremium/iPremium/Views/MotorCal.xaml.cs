using iPremium.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iPremium.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MotorCal : GradientContentPage
    {
        DateTime currentYear;
        private string yearOfMake;
        public MotorCal()
        {
            InitializeComponent();
        }

        private void CalculateButton_Clicked(object sender, EventArgs e)
        {
            double basicPremium;
            double cubicLoading;
            double ageLoading;
            yearOfMake = xYearOfMake.Text;
            var ageSub = currentYear.Year - Convert.ToInt32(yearOfMake);
            double basicCubic = Convert.ToDouble(CubicCapacity.Text);
           
            if (xCovertype.SelectedIndex == 0)
            {
                basicPremium = 0.05 * Convert.ToDouble(xValue.Text);
                if (basicCubic < 1600)
                {
                    cubicLoading = 0 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }
                else if (basicCubic <= 2000)
                {
                    cubicLoading = 0.05 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }
                if (ageSub <= 5)
                {
                    ageLoading = basicPremium * 0.05;
                    Preferences.Set("AgeLoading", ageLoading);
                }
                else if (ageSub < 10)
                {
                    ageLoading = basicPremium * 0.075;
                    Preferences.Set("AgeLoading", ageLoading);
                }
                Preferences.Set("BasicPremium", basicPremium);

                Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Preferences.Set("RegistrationNumber",xRegistrationNumber.Text);
                Preferences.Set("VehicleMake",xVehicleMake.Text);
                Navigation.PushAsync(new ResultPage());
            }

        }
    }
}