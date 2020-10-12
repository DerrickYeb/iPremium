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
            double thirdParty;
            int thisYear = 2020;
            double comprehensive;
            double excessBought = 0;
            double extraTPPD;
            double extraSeat;
            double officeCharge = 55;
            double ncdRate;
            double enteredNCDRate = Convert.ToDouble(xNCD.Text);
            double fcdRate;
            double enteredFCD = Convert.ToDouble(xFCD.Text);
            double enterCapacity = Convert.ToDouble(xSeatCapacity.Text);
            double inputTPPD = Convert.ToDouble(x3PropertyDamaged.Text);
            yearOfMake = xYearOfMake.Text;
            //var ageSub = currentYear.Year - Convert.ToInt32(yearOfMake);
            var ageSub = thisYear - Convert.ToInt64(xYearOfMake.Text);
            double basicCubic = Convert.ToDouble(CubicCapacity.Text);
           
            if (xCovertype.SelectedIndex == 0)
            {
                basicPremium = 0.05 * Convert.ToDouble(xValue.Text);
                thirdParty = 272 / 1;
                excessBought = Convert.ToDouble(xExcessLoad.Text) * basicPremium;
                extraTPPD = inputTPPD - (5000 / 1 * 0.02);
                extraSeat = (enterCapacity - 5) * (5 / 1);
                var charge = officeCharge / 1;
                ncdRate = enteredNCDRate / 100;
                fcdRate = enteredFCD / 100;
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
                if (ageSub < 5)
                {
                    ageLoading = basicPremium * 0;
                    Preferences.Set("AgeLoading", ageLoading);
                
                }
                else if (ageSub <= 5)
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
                Preferences.Set("ThirdParty", thirdParty);
                Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Preferences.Set("RegistrationNumber",xRegistrationNumber.Text);
                Preferences.Set("VehicleMake",xVehicleMake.Text);
                Preferences.Set("ExcessLoad", excessBought);
                Preferences.Set("ExtraThirdParty", extraTPPD);
                Preferences.Set("ExtraSeat", extraSeat);
                Preferences.Set("OfficeCharge", officeCharge);
                Preferences.Set("NCD", ncdRate);
                Preferences.Set("FCD", fcdRate);
                Navigation.PushAsync(new ResultPage());
            }

        }
    }
}