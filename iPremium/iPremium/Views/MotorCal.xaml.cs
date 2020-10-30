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

        /// <summary>
        /// Testing basic functionalities here using a code behind logic
        /// Main logic will is the MotorCalViewModel class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                excessBought = (Convert.ToDouble(xExcessLoad.Text) / 100) * basicPremium;
                double officeCharge = 55;

                var charge = officeCharge / 1;
                ncdRate = enteredNCDRate / 100;
                fcdRate = enteredFCD / 100;

                if (enterCapacity <= 5)
                {
                    extraSeat = 0;
                }
                else
                {
                    extraSeat = (enterCapacity - 5) * (5 / 1);
                }
                if (inputTPPD <= 5000)
                {
                    extraTPPD = 0;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                else if(inputTPPD > 5000)
                {
                    extraTPPD = (inputTPPD - 5000 / 1 )* 0.02;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                if (basicCubic < 1600)
                {
                    cubicLoading = 0 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }
                
                else if (basicCubic >= 1600 && basicCubic <= 2000)
                {
                    cubicLoading = 0.05 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                 
                }
                if (ageSub < 5)
                {
                    ageLoading = basicPremium * 0;
                    Preferences.Set("AgeLoading", ageLoading);
                
                }
                else if (ageSub >= 5 && ageSub < 10)
                {
                    ageLoading = basicPremium * 0.05;
                    Preferences.Set("AgeLoading", ageLoading);
                    
                }
                else if (ageSub >= 10)
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
                
                Preferences.Set("ExtraSeat", extraSeat);
                Preferences.Set("OfficeCharge", officeCharge);
                Preferences.Set("NCD", ncdRate);
                Preferences.Set("FCD", fcdRate);
                
            }
            // Calculating the next Corporate cover type
            else if (xCovertype.SelectedIndex == 1)
            {
                
                basicPremium = 0.06 * Convert.ToDouble(xValue.Text);
                thirdParty = 272 / 1;
                excessBought = Convert.ToDouble(xExcessLoad.Text) * basicPremium;
                double officeCharge = 55;

                var charge = officeCharge / 1;
                ncdRate = enteredNCDRate / 100;
                fcdRate = enteredFCD / 100;

                if (enterCapacity <= 5)
                {
                    extraSeat = 0;
                }
                else
                {
                    extraSeat = (enterCapacity - 5) * (5 / 1);
                }
                if (inputTPPD <= 5000)
                {
                    extraTPPD = 0;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                else if (inputTPPD > 5000)
                {
                    extraTPPD = (inputTPPD - 5000 / 1) * 0.02;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                if (basicCubic < 1600)
                {
                    cubicLoading = 0 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }

                else if (basicCubic >= 1600 && basicCubic <= 2000)
                {
                    cubicLoading = 0.05 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);

                }
                if (ageSub < 5)
                {
                    ageLoading = basicPremium * 0;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 5 && ageSub < 10)
                {
                    ageLoading = basicPremium * 0.05;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 10)
                {
                    ageLoading = basicPremium * 0.075;
                    Preferences.Set("AgeLoading", ageLoading);

                }

                Preferences.Set("BasicPremium", basicPremium);
                Preferences.Set("ThirdParty", thirdParty);
                Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Preferences.Set("RegistrationNumber", xRegistrationNumber.Text);
                Preferences.Set("VehicleMake", xVehicleMake.Text);
                Preferences.Set("ExcessLoad", excessBought);

                Preferences.Set("ExtraSeat", extraSeat);
                Preferences.Set("OfficeCharge", officeCharge);
                Preferences.Set("NCD", ncdRate);
                Preferences.Set("FCD", fcdRate);
                
            }
            //Calculating for Motor cycle
            else if (xCovertype.SelectedIndex == 2)
            {

                
                basicPremium = 0.03 * Convert.ToDouble(xValue.Text);
                thirdParty = 99 / 1;
                excessBought = Convert.ToDouble(xExcessLoad.Text) * basicPremium;
                double officeCharge = 50;

                var charge = officeCharge / 1;
                ncdRate = enteredNCDRate / 100;
                fcdRate = enteredFCD / 100;

                
                extraSeat = 0;
                if (inputTPPD <= 5000)
                {
                    extraTPPD = 0;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                else if (inputTPPD > 5000)
                {
                    extraTPPD = (inputTPPD - 5000 / 1) * 0.02;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                if (basicCubic < 1600)
                {
                    cubicLoading = 0 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }

                else if (basicCubic >= 1600 && basicCubic <= 2000)
                {
                    cubicLoading = 0.05 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);

                }
                if (ageSub < 5)
                {
                    ageLoading = basicPremium * 0;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 5 && ageSub < 10)
                {
                    ageLoading = basicPremium * 0.05;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 10)
                {
                    ageLoading = basicPremium * 0.075;
                    Preferences.Set("AgeLoading", ageLoading);

                }

                Preferences.Set("BasicPremium", basicPremium);
                Preferences.Set("ThirdParty", thirdParty);
                Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Preferences.Set("RegistrationNumber", xRegistrationNumber.Text);
                Preferences.Set("VehicleMake", xVehicleMake.Text);
                Preferences.Set("ExcessLoad", excessBought);

                Preferences.Set("ExtraSeat", extraSeat);
                Preferences.Set("OfficeCharge", officeCharge);
                Preferences.Set("NCD", ncdRate);
                Preferences.Set("FCD", fcdRate);
               
            }
            //Calculating for Taxi
            else if (xCovertype.SelectedIndex == 3)
            {

                
                basicPremium = 0.07 * Convert.ToDouble(xValue.Text);
                thirdParty = 378 / 1;
                excessBought = Convert.ToDouble(xExcessLoad.Text) * basicPremium;
                double officeCharge = 60;

                var charge = officeCharge / 1;
                ncdRate = enteredNCDRate / 100;
                fcdRate = enteredFCD / 100;

                if (enterCapacity <= 5)
                {
                    extraSeat = 0;
                }
                else
                {
                    extraSeat = (enterCapacity - 5) * (5 / 1);
                }

                if (inputTPPD <= 5000)
                {
                    extraTPPD = 0;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                else if (inputTPPD > 5000)
                {
                    extraTPPD = (inputTPPD - 5000 / 1) * 0.02;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                if (basicCubic < 1600)
                {
                    cubicLoading = 0 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }

                else if (basicCubic >= 1600 && basicCubic <= 2000)
                {
                    cubicLoading = 0.05 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);

                }
                if (ageSub < 5)
                {
                    ageLoading = basicPremium * 0;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 5 && ageSub < 10)
                {
                    ageLoading = basicPremium * 0.05;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 10)
                {
                    ageLoading = basicPremium * 0.075;
                    Preferences.Set("AgeLoading", ageLoading);

                }

                Preferences.Set("BasicPremium", basicPremium);
                Preferences.Set("ThirdParty", thirdParty);
                Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Preferences.Set("RegistrationNumber", xRegistrationNumber.Text);
                Preferences.Set("VehicleMake", xVehicleMake.Text);
                Preferences.Set("ExcessLoad", excessBought);

                Preferences.Set("ExtraSeat", extraSeat);
                Preferences.Set("OfficeCharge", officeCharge);
                Preferences.Set("NCD", ncdRate);
                Preferences.Set("FCD", fcdRate);

            }
            //Calculating for Ambulance
            else if (xCovertype.SelectedIndex == 4)
            {

               
                basicPremium = 0.07 * Convert.ToDouble(xValue.Text);
                thirdParty = 297 / 1;
                excessBought = Convert.ToDouble(xExcessLoad.Text) * basicPremium;
                double officeCharge = 57;

                var charge = officeCharge / 1;
                ncdRate = enteredNCDRate / 100;
                fcdRate = enteredFCD / 100;

                if (enterCapacity <= 5)
                {
                    extraSeat = 0;
                }
                else
                {
                    extraSeat = (enterCapacity - 5) * (5 / 1);
                }

                if (inputTPPD <= 5000)
                {
                    extraTPPD = 0;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                else if (inputTPPD > 5000)
                {
                    extraTPPD = (inputTPPD - 5000 / 1) * 0.02;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                if (basicCubic < 1600)
                {
                    cubicLoading = 0 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }

                else if (basicCubic >= 1600 && basicCubic <= 2000)
                {
                    cubicLoading = 0.05 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);

                }
                if (ageSub < 5)
                {
                    ageLoading = basicPremium * 0;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 5 && ageSub < 10)
                {
                    ageLoading = basicPremium * 0.05;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 10)
                {
                    ageLoading = basicPremium * 0.075;
                    Preferences.Set("AgeLoading", ageLoading);

                }

                Preferences.Set("BasicPremium", basicPremium);
                Preferences.Set("ThirdParty", thirdParty);
                Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Preferences.Set("RegistrationNumber", xRegistrationNumber.Text);
                Preferences.Set("VehicleMake", xVehicleMake.Text);
                Preferences.Set("ExcessLoad", excessBought);

                Preferences.Set("ExtraSeat", extraSeat);
                Preferences.Set("OfficeCharge", officeCharge);
                Preferences.Set("NCD", ncdRate);
                Preferences.Set("FCD", fcdRate);

            }
            //Calculating for Hiring
            else if (xCovertype.SelectedIndex == 5)
            {

               
                basicPremium = 0.07 * Convert.ToDouble(xValue.Text);
                thirdParty = 387 / 1;
                excessBought = Convert.ToDouble(xExcessLoad.Text) * basicPremium;
                double officeCharge = 60;

                var charge = officeCharge / 1;
                ncdRate = enteredNCDRate / 100;
                fcdRate = enteredFCD / 100;

                if (enterCapacity <= 5)
                {
                    extraSeat = 0;
                }
                else
                {
                    extraSeat = (enterCapacity - 5) * (5 / 1);
                }

                if (inputTPPD <= 5000)
                {
                    extraTPPD = 0;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                else if (inputTPPD > 5000)
                {
                    extraTPPD = (inputTPPD - 5000 / 1) * 0.02;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                if (basicCubic < 1600)
                {
                    cubicLoading = 0 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }

                else if (basicCubic >= 1600 && basicCubic <= 2000)
                {
                    cubicLoading = 0.05 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);

                }
                if (ageSub < 5)
                {
                    ageLoading = basicPremium * 0;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 5 && ageSub < 10)
                {
                    ageLoading = basicPremium * 0.05;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 10)
                {
                    ageLoading = basicPremium * 0.075;
                    Preferences.Set("AgeLoading", ageLoading);

                }

                Preferences.Set("BasicPremium", basicPremium);
                Preferences.Set("ThirdParty", thirdParty);
                Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Preferences.Set("RegistrationNumber", xRegistrationNumber.Text);
                Preferences.Set("VehicleMake", xVehicleMake.Text);
                Preferences.Set("ExcessLoad", excessBought);

                Preferences.Set("ExtraSeat", extraSeat);
                Preferences.Set("OfficeCharge", officeCharge);
                Preferences.Set("NCD", ncdRate);
                Preferences.Set("FCD", fcdRate);

            }
            //Calculating for Mini Bus
            else if (xCovertype.SelectedIndex == 6)
            {

                
                basicPremium = 0.07 * Convert.ToDouble(xValue.Text);
                thirdParty = 387 / 1;
                excessBought = Convert.ToDouble(xExcessLoad.Text) * basicPremium;
                double officeCharge = 60;

                var charge = officeCharge / 1;
                ncdRate = enteredNCDRate / 100;
                fcdRate = enteredFCD / 100;

                if (enterCapacity <= 5)
                {
                    extraSeat = 0;
                }
                else
                {
                    extraSeat = (enterCapacity - 5) * (5 / 1);
                }

                if (inputTPPD <= 5000)
                {
                    extraTPPD = 0;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                else if (inputTPPD > 5000)
                {
                    extraTPPD = (inputTPPD - 5000 / 1) * 0.02;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                if (basicCubic < 1600)
                {
                    cubicLoading = 0 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }

                else if (basicCubic >= 1600 && basicCubic <= 2000)
                {
                    cubicLoading = 0.05 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);

                }
                if (ageSub < 5)
                {
                    ageLoading = basicPremium * 0;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 5 && ageSub < 10)
                {
                    ageLoading = basicPremium * 0.05;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 10)
                {
                    ageLoading = basicPremium * 0.075;
                    Preferences.Set("AgeLoading", ageLoading);

                }

                Preferences.Set("BasicPremium", basicPremium);
                Preferences.Set("ThirdParty", thirdParty);
                Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Preferences.Set("RegistrationNumber", xRegistrationNumber.Text);
                Preferences.Set("VehicleMake", xVehicleMake.Text);
                Preferences.Set("ExcessLoad", excessBought);

                Preferences.Set("ExtraSeat", extraSeat);
                Preferences.Set("OfficeCharge", officeCharge);
                Preferences.Set("NCD", ncdRate);
                Preferences.Set("FCD", fcdRate);

            }
            //Calculating for Maxi Bus
            else if (xCovertype.SelectedIndex == 7)
            {

              
                basicPremium = 0.07 * Convert.ToDouble(xValue.Text);
                thirdParty = 387 / 1;
                excessBought = Convert.ToDouble(xExcessLoad.Text) * basicPremium;
                double officeCharge = 60;

                var charge = officeCharge / 1;
                ncdRate = enteredNCDRate / 100;
                fcdRate = enteredFCD / 100;

                if (enterCapacity <= 5)
                {
                    extraSeat = 0;
                }
                else
                {
                    extraSeat = (enterCapacity - 5) * (5 / 1);
                }

                if (inputTPPD <= 5000)
                {
                    extraTPPD = 0;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                else if (inputTPPD > 5000)
                {
                    extraTPPD = (inputTPPD - 5000 / 1) * 0.02;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                if (basicCubic < 1600)
                {
                    cubicLoading = 0 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }

                else if (basicCubic >= 1600 && basicCubic <= 2000)
                {
                    cubicLoading = 0.05 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);

                }
                if (ageSub < 5)
                {
                    ageLoading = basicPremium * 0;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 5 && ageSub < 10)
                {
                    ageLoading = basicPremium * 0.05;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 10)
                {
                    ageLoading = basicPremium * 0.075;
                    Preferences.Set("AgeLoading", ageLoading);

                }

                Preferences.Set("BasicPremium", basicPremium);
                Preferences.Set("ThirdParty", thirdParty);
                Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Preferences.Set("RegistrationNumber", xRegistrationNumber.Text);
                Preferences.Set("VehicleMake", xVehicleMake.Text);
                Preferences.Set("ExcessLoad", excessBought);

                Preferences.Set("ExtraSeat", extraSeat);
                Preferences.Set("OfficeCharge", officeCharge);
                Preferences.Set("NCD", ncdRate);
                Preferences.Set("FCD", fcdRate);

            }
            //Calculating for Own Goods
            else if (xCovertype.SelectedIndex == 8)
            {

                basicPremium = 0.04 * Convert.ToDouble(xValue.Text);
                thirdParty = 387 / 1;
                excessBought = Convert.ToDouble(xExcessLoad.Text) * basicPremium;
                double officeCharge = 65;

                var charge = officeCharge / 1;
                ncdRate = enteredNCDRate / 100;
                fcdRate = enteredFCD / 100;

                if (enterCapacity <= 5)
                {
                    extraSeat = 0;
                }
                else
                {
                    extraSeat = (enterCapacity - 5) * (5 / 1);
                }

                if (inputTPPD <= 5000)
                {
                    extraTPPD = 0;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                else if (inputTPPD > 5000)
                {
                    extraTPPD = (inputTPPD - 5000 / 1) * 0.02;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                if (basicCubic < 1600)
                {
                    cubicLoading = 0 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }

                else if (basicCubic >= 1600 && basicCubic <= 2000)
                {
                    cubicLoading = 0.05 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);

                }
                if (ageSub < 5)
                {
                    ageLoading = basicPremium * 0;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 5 && ageSub < 10)
                {
                    ageLoading = basicPremium * 0.05;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 10)
                {
                    ageLoading = basicPremium * 0.075;
                    Preferences.Set("AgeLoading", ageLoading);

                }

                Preferences.Set("BasicPremium", basicPremium);
                Preferences.Set("ThirdParty", thirdParty);
                Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Preferences.Set("RegistrationNumber", xRegistrationNumber.Text);
                Preferences.Set("VehicleMake", xVehicleMake.Text);
                Preferences.Set("ExcessLoad", excessBought);

                Preferences.Set("ExtraSeat", extraSeat);
                Preferences.Set("OfficeCharge", officeCharge);
                Preferences.Set("NCD", ncdRate);
                Preferences.Set("FCD", fcdRate);

            }
            //Calculating for Tanker or Articulator
            else if (xCovertype.SelectedIndex == 9)
            {

                basicPremium = 0.08 * Convert.ToDouble(xValue.Text);
                thirdParty = 594 / 1;
                excessBought = Convert.ToDouble(xExcessLoad.Text) * basicPremium;
                double officeCharge = 65;

                var charge = officeCharge / 1;
                ncdRate = enteredNCDRate / 100;
                fcdRate = enteredFCD / 100;

                if (enterCapacity <= 5)
                {
                    extraSeat = 0;
                }
                else
                {
                    extraSeat = (enterCapacity - 5) * (5 / 1);
                }

                if (inputTPPD <= 5000)
                {
                    extraTPPD = 0;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                else if (inputTPPD > 5000)
                {
                    extraTPPD = (inputTPPD - 5000 / 1) * 0.02;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                if (basicCubic < 1600)
                {
                    cubicLoading = 0 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }

                else if (basicCubic >= 1600 && basicCubic <= 2000)
                {
                    cubicLoading = 0.05 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);

                }
                if (ageSub < 5)
                {
                    ageLoading = basicPremium * 0;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 5 && ageSub < 10)
                {
                    ageLoading = basicPremium * 0.05;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 10)
                {
                    ageLoading = basicPremium * 0.075;
                    Preferences.Set("AgeLoading", ageLoading);

                }

                Preferences.Set("BasicPremium", basicPremium);
                Preferences.Set("ThirdParty", thirdParty);
                Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Preferences.Set("RegistrationNumber", xRegistrationNumber.Text);
                Preferences.Set("VehicleMake", xVehicleMake.Text);
                Preferences.Set("ExcessLoad", excessBought);

                Preferences.Set("ExtraSeat", extraSeat);
                Preferences.Set("OfficeCharge", officeCharge);
                Preferences.Set("NCD", ncdRate);
                Preferences.Set("FCD", fcdRate);

            }
            //Calculating for General Cartage
            else if (xCovertype.SelectedIndex == 10)
            {

                
                basicPremium = 0.06 * Convert.ToDouble(xValue.Text);
                thirdParty = 486 / 1;
                excessBought = Convert.ToDouble(xExcessLoad.Text) * basicPremium;
                double officeCharge = 65;

                var charge = officeCharge / 1;
                ncdRate = enteredNCDRate / 100;
                fcdRate = enteredFCD / 100;

                if (enterCapacity <= 5)
                {
                    extraSeat = 0;
                }
                else
                {
                    extraSeat = (enterCapacity - 5) * (5 / 1);
                }

                if (inputTPPD <= 5000)
                {
                    extraTPPD = 0;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                else if (inputTPPD > 5000)
                {
                    extraTPPD = (inputTPPD - 5000 / 1) * 0.02;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                if (basicCubic < 1600)
                {
                    cubicLoading = 0 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }

                else if (basicCubic >= 1600 && basicCubic <= 2000)
                {
                    cubicLoading = 0.05 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);

                }
                if (ageSub < 5)
                {
                    ageLoading = basicPremium * 0;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 5 && ageSub < 10)
                {
                    ageLoading = basicPremium * 0.05;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 10)
                {
                    ageLoading = basicPremium * 0.075;
                    Preferences.Set("AgeLoading", ageLoading);

                }

                Preferences.Set("BasicPremium", basicPremium);
                Preferences.Set("ThirdParty", thirdParty);
                Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Preferences.Set("RegistrationNumber", xRegistrationNumber.Text);
                Preferences.Set("VehicleMake", xVehicleMake.Text);
                Preferences.Set("ExcessLoad", excessBought);

                Preferences.Set("ExtraSeat", extraSeat);
                Preferences.Set("OfficeCharge", officeCharge);
                Preferences.Set("NCD", ncdRate);
                Preferences.Set("FCD", fcdRate);

            }
            //Calculating for Special on roads
            else if (xCovertype.SelectedIndex == 11)
            {

            
                basicPremium = 0.03 * Convert.ToDouble(xValue.Text);
                thirdParty = 387 / 1;
                excessBought = Convert.ToDouble(xExcessLoad.Text) * basicPremium;
                double officeCharge = 65;

                var charge = officeCharge / 1;
                ncdRate = enteredNCDRate / 100;
                fcdRate = enteredFCD / 100;

                if (enterCapacity <= 5)
                {
                    extraSeat = 0;
                }
                else
                {
                    extraSeat = (enterCapacity - 5) * (5 / 1);
                }

                if (inputTPPD <= 5000)
                {
                    extraTPPD = 0;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                else if (inputTPPD > 5000)
                {
                    extraTPPD = (inputTPPD - 5000 / 1) * 0.02;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                if (basicCubic < 1600)
                {
                    cubicLoading = 0 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }

                else if (basicCubic >= 1600 && basicCubic <= 2000)
                {
                    cubicLoading = 0.05 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);

                }
                if (ageSub < 5)
                {
                    ageLoading = basicPremium * 0;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 5 && ageSub < 10)
                {
                    ageLoading = basicPremium * 0.05;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 10)
                {
                    ageLoading = basicPremium * 0.075;
                    Preferences.Set("AgeLoading", ageLoading);

                }

                Preferences.Set("BasicPremium", basicPremium);
                Preferences.Set("ThirdParty", thirdParty);
                Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Preferences.Set("RegistrationNumber", xRegistrationNumber.Text);
                Preferences.Set("VehicleMake", xVehicleMake.Text);
                Preferences.Set("ExcessLoad", excessBought);

                Preferences.Set("ExtraSeat", extraSeat);
                Preferences.Set("OfficeCharge", officeCharge);
                Preferences.Set("NCD", ncdRate);
                Preferences.Set("FCD", fcdRate);

            }
            //Calculating for Special on site
            else if (xCovertype.SelectedIndex == 12)
            {

              
                basicPremium = 0.015 * Convert.ToDouble(xValue.Text);
                thirdParty = 198 / 1;
                excessBought = Convert.ToDouble(xExcessLoad.Text) * basicPremium;
                double officeCharge = 50;

                var charge = officeCharge / 1;
                ncdRate = enteredNCDRate / 100;
                fcdRate = enteredFCD / 100;

                if (enterCapacity <= 5)
                {
                    extraSeat = 0;
                }
                else
                {
                    extraSeat = (enterCapacity - 5) * (5 / 1);
                }

                if (inputTPPD <= 5000)
                {
                    extraTPPD = 0;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                else if (inputTPPD > 5000)
                {
                    extraTPPD = (inputTPPD - 5000 / 1) * 0.02;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                if (basicCubic < 1600)
                {
                    cubicLoading = 0 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }

                else if (basicCubic >= 1600 && basicCubic <= 2000)
                {
                    cubicLoading = 0.05 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);

                }
                if (ageSub < 5)
                {
                    ageLoading = basicPremium * 0;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 5 && ageSub < 10)
                {
                    ageLoading = basicPremium * 0.05;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 10)
                {
                    ageLoading = basicPremium * 0.075;
                    Preferences.Set("AgeLoading", ageLoading);

                }

                Preferences.Set("BasicPremium", basicPremium);
                Preferences.Set("ThirdParty", thirdParty);
                Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Preferences.Set("RegistrationNumber", xRegistrationNumber.Text);
                Preferences.Set("VehicleMake", xVehicleMake.Text);
                Preferences.Set("ExcessLoad", excessBought);

                Preferences.Set("ExtraSeat", extraSeat);
                Preferences.Set("OfficeCharge", officeCharge);
                Preferences.Set("NCD", ncdRate);
                Preferences.Set("FCD", fcdRate);

            }
            //Calculating for GW1 Class 1
            else if (xCovertype.SelectedIndex == 13)
            {

                basicPremium = 0.05 * Convert.ToDouble(xValue.Text);
                thirdParty = 330 / 1;
                excessBought = Convert.ToDouble(xExcessLoad.Text) * basicPremium;
                double officeCharge = 60;

                var charge = officeCharge / 1;
                ncdRate = enteredNCDRate / 100;
                fcdRate = enteredFCD / 100;

                if (enterCapacity <= 5)
                {
                    extraSeat = 0;
                }
                else
                {
                    extraSeat = (enterCapacity - 5) * (5 / 1);
                }

                if (inputTPPD <= 5000)
                {
                    extraTPPD = 0;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                else if (inputTPPD > 5000)
                {
                    extraTPPD = (inputTPPD - 5000 / 1) * 0.02;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                if (basicCubic < 1600)
                {
                    cubicLoading = 0 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }

                else if (basicCubic >= 1600 && basicCubic <= 2000)
                {
                    cubicLoading = 0.05 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);

                }
                if (ageSub < 5)
                {
                    ageLoading = basicPremium * 0;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 5 && ageSub < 10)
                {
                    ageLoading = basicPremium * 0.05;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 10)
                {
                    ageLoading = basicPremium * 0.075;
                    Preferences.Set("AgeLoading", ageLoading);

                }

                Preferences.Set("BasicPremium", basicPremium);
                Preferences.Set("ThirdParty", thirdParty);
                Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Preferences.Set("RegistrationNumber", xRegistrationNumber.Text);
                Preferences.Set("VehicleMake", xVehicleMake.Text);
                Preferences.Set("ExcessLoad", excessBought);

                Preferences.Set("ExtraSeat", extraSeat);
                Preferences.Set("OfficeCharge", officeCharge);
                Preferences.Set("NCD", ncdRate);
                Preferences.Set("FCD", fcdRate);

            }
            //Calculating for GW1 Class 2
            else if (xCovertype.SelectedIndex == 14)
            {

                basicPremium = 0.06 * Convert.ToDouble(xValue.Text);
                thirdParty = 440 / 1;
                excessBought = Convert.ToDouble(xExcessLoad.Text) * basicPremium;
                double officeCharge = 60;

                var charge = officeCharge / 1;
                ncdRate = enteredNCDRate / 100;
                fcdRate = enteredFCD / 100;

                if (enterCapacity <= 5)
                {
                    extraSeat = 0;
                }
                else
                {
                    extraSeat = (enterCapacity - 5) * (5 / 1);
                }

                if (inputTPPD <= 5000)
                {
                    extraTPPD = 0;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                else if (inputTPPD > 5000)
                {
                    extraTPPD = (inputTPPD - 5000 / 1) * 0.02;
                    Preferences.Set("ExtraThirdParty", extraTPPD);
                }
                if (basicCubic < 1600)
                {
                    cubicLoading = 0 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);
                }

                else if (basicCubic >= 1600 && basicCubic <= 2000)
                {
                    cubicLoading = 0.05 * basicPremium;
                    Preferences.Set("CubicLoading", cubicLoading);

                }
                if (ageSub < 5)
                {
                    ageLoading = basicPremium * 0;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 5 && ageSub < 10)
                {
                    ageLoading = basicPremium * 0.05;
                    Preferences.Set("AgeLoading", ageLoading);

                }
                else if (ageSub >= 10)
                {
                    ageLoading = basicPremium * 0.075;
                    Preferences.Set("AgeLoading", ageLoading);

                }

                Preferences.Set("BasicPremium", basicPremium);
                Preferences.Set("ThirdParty", thirdParty);
                Preferences.Set("CoverType", (string)xCovertype.SelectedItem);
                Preferences.Set("RegistrationNumber", xRegistrationNumber.Text);
                Preferences.Set("VehicleMake", xVehicleMake.Text);
                Preferences.Set("ExcessLoad", excessBought);

                Preferences.Set("ExtraSeat", extraSeat);
                Preferences.Set("OfficeCharge", officeCharge);
                Preferences.Set("NCD", ncdRate);
                Preferences.Set("FCD", fcdRate);

            }
            Navigation.PushAsync(new ResultPage());
        }
    }
}