﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FFImageLoading.Forms;
using iPremium.Controls;
using iPremium.Interfaces;
using Newtonsoft.Json.Converters;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace iPremium.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : GradientContentPage
    {
        private bool _initialized = false;
        private bool _starsAdded = false;
        private List<VisualElement> _stars = new List<VisualElement>();
        public ResultPage()
        {
            InitializeComponent();
            SubTitleLabel.TranslateTo(1000, 0, 0, null);
            TitleLabel.TranslateTo(1000, 0, 0, null);
            MoonBoy.TranslateTo(0, 1000, 0, null);
            Card.TranslateTo(1000, 0, 0, null);
          
            //Testing Codes using dictionary
           xBasicPremium.Text = Preferences.Get("BasicPremium", string.Empty);
            xThirdPart.Text = Preferences.Get("ThirdParty", string.Empty);
            xCubicLoading.Text = Preferences.Get("CubicLoading", string.Empty);
            xAgeLaoding.Text = Preferences.Get("AgeLoading", string.Empty);
            xCovertype.Text = Preferences.Get("CoverType", string.Empty);
            xRegistrationNumber.Text = Preferences.Get("RegistrationNumber",string.Empty);
            xVehicleMake.Text = Preferences.Get("VehicleMake",string.Empty);
            xExcessBought.Text = Preferences.Get("ExcessLoad", string.Empty);
            xTPPD.Text = Preferences.Get("ExtraThirdParty", string.Empty);
            xoffice.Text = Preferences.Get("OfficeCharge", string.Empty);
            xSeat.Text = Preferences.Get("ExtraSeat", string.Empty);
            double ncd = Convert.ToDouble(Preferences.Get("NCD", string.Empty));
            double comprehensive = Convert.ToDouble(xBasicPremium.Text) + Convert.ToDouble(xAgeLaoding.Text) + Convert.ToDouble(xCubicLoading.Text) + Convert.ToDouble(xThirdPart.Text);
            xComprehensive.Text = comprehensive.ToString();
            var ncdrate = ncd * comprehensive;
            xNCD.Text = $"{ncdrate.ToString()}";
            double fcd = Convert.ToDouble(Preferences.Get("FCD", string.Empty));
            var fcdrate = fcd * Convert.ToDouble(xComprehensive.Text) - ncdrate * fcd;
            xFCD.Text = $"{fcdrate.ToString()}";
            var gross = comprehensive - ncdrate - fcdrate;
            xGrossP.Text = gross.ToString();
            //var premium = gross + Convert.ToDouble(xExcessBought.Text) + Convert.ToDouble(xTPPD.Text) + Convert.ToDouble(xoffice.Text) + Convert.ToDouble(xSeat.Text);
            //xPremium.Text = "GHS " + premium.ToString();
            xPremium.Text = PremiumCedis(gross,Convert.ToDouble(xExcessBought.Text),Convert.ToDouble(xTPPD.Text),Convert.ToDouble(xoffice.Text),Convert.ToDouble(xSeat.Text));
            xPremiumDollar.Text = PremiumDollar(gross,Convert.ToDouble(xExcessBought.Text),Convert.ToDouble(xTPPD.Text),Convert.ToDouble(xoffice.Text),Convert.ToDouble(xSeat.Text));
            xPremiumPounds.Text = PremiumPounds(gross,Convert.ToDouble(xExcessBought.Text),Convert.ToDouble(xTPPD.Text),Convert.ToDouble(xoffice.Text),Convert.ToDouble(xSeat.Text));
            xPremiumEuros.Text = PremiumEuros(gross,Convert.ToDouble(xExcessBought.Text),Convert.ToDouble(xTPPD.Text),Convert.ToDouble(xoffice.Text),Convert.ToDouble(xSeat.Text));
        }
        private string PremiumCedis(double gross, double excessload,double tddd, double office, double seatSize)
        {
            
            string premium = (string)(gross + excessload + tddd + office + seatSize).ToString("N0");
            
            return ($"₵ {premium}");
        }
        private string PremiumDollar(double gross, double excessload, double tddd, double office, double seatSize)
        {

            var premium = ((gross + excessload + tddd + office + seatSize ) / 4).ToString("N0");

            return ($"$ {premium}");
        }
        private string PremiumPounds(double gross, double excessload, double tddd, double office, double seatSize)
        {

            string premium = ((gross + excessload + tddd + office + seatSize) / 6.5).ToString("N0");

            return ($"£ {premium}");
        }
        private string PremiumEuros(double gross, double excessload, double tddd, double office, double seatSize)
        {

            var premium = ((gross + excessload + tddd + office + seatSize) / 4.5).ToString("N0");

            return ($"€ {premium}");
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!_initialized)
            {
                PositionStars();
                RotateStars();

                await Task.WhenAll(
                    SubTitleLabel.TranslateTo(0, 0, 400, Easing.CubicInOut),
                    TitleLabel.TranslateTo(0, 0, 450, Easing.CubicInOut),
                    Card.TranslateTo(0, 0, 500, Easing.CubicInOut),
                    MoonBoy.TranslateTo(0, 0, 550, Easing.CubicInOut)
                );

                 RotateElement(MoonBoy, 600000, new CancellationToken());

                _initialized = true;
            }
        }
        private void PositionStars()
        {
            if (!_starsAdded)
            {
                var random = new Random();
                var metrics = DeviceDisplay.MainDisplayInfo;

                var formsWidth = Convert.ToInt32(metrics.Width / metrics.Density);
                var formsHeight = Convert.ToInt32(metrics.Height / metrics.Density);
                var tasks = new List<Task>();

                for (int j = 0; j < 5; j++)
                {
                    var starField = new Grid();

                    for (int i = 0; i < 20; i++)
                    {
                        var size = random.Next(3, 7);
                        var star = new CachedImage() { Source = "star.png", Opacity = 0.3, HeightRequest = size, WidthRequest = size, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Start, TranslationX = random.Next(0, formsWidth), TranslationY = random.Next(0, formsHeight) };
                        starField.Children.Add(star);
                    }

                    _stars.Add(starField);
                    MainGrid.Children.Insert(0, starField);
                }
            }
        }
        private async Task RotateStars()
        {
            var rotateTasks = new List<Task>();
            var random = new Random();

            foreach (var star in _stars)
            {
                var rate = random.Next(240000, 300000);
                rotateTasks.Add(RotateElement(star, (uint)rate, new CancellationToken()));
            }

            await Task.WhenAll(rotateTasks);
        }

        public async void ShareInfo()
        {
             await Share.RequestAsync(new ShareTextRequest
             {
                 Subject = "Comprehensive Motor Insurance",
                 Text = $"Comprehensive Motor Insurance:\n\nCover Type - {xCovertype.Text}\nRegistration Number - {xRegistrationNumber.Text}\nVehicle Make - {xVehicleMake.Text}\n" +
                 $"Basic Premium - {xBasicPremium.Text}\nCubic Loading - {xCubicLoading.Text}\nAge Loading - {xAgeLaoding.Text}\nThird Party Basic Premium - {xThirdPart.Text}\nComprehensive Basic - {xComprehensive.Text}\nNCD% - {xNCD.Text}\nFCD% - {xFCD.Text}\nGross Premium - {xGrossP.Text}\nExcess Bought - {xExcessBought.Text}\nExtra Third Party Property Damage - {xTPPD.Text}\nOffice Charge - {xoffice.Text}\nExtra Seat - {xSeat.Text}\nPremium - {xPremium.Text}",
                 Title = "Comprehensive Motor Insurance"
             });
        }

        private void CalculateButton_Clicked(object sender, EventArgs e)
        {
            ShareInfo();
        }
    }
}