using iPremium.Interfaces;
using iPremium.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iPremium.ViewModel
{
    public class MotorCalViewModel : BaseViewModel, IPrimeCalculation
    {
        private string _covertype;
        private double _value;
        private ResultsModel results;
        private MotorCalModel _motor;
        private DateTime _yearMake;
        public Task AgeLoading(DateTime currentYear)
        {

            _yearMake = _motor.YearOfMake;
            var result = results.AgeLoading;
            if (currentYear.Year.CompareTo(_yearMake) <= 5)
            {
                result = results.BasicPremium * 0.05;
            }
            else if ((currentYear.Year.CompareTo(_yearMake) < 10))
            {
                result = results.BasicPremium * 0.05;
                result = results.BasicPremium * 0.075;
            }
            return Task.FromResult(result);
        }

        public async Task<double> BasicPremium()
        {
            double percentage = 0;
            _value = _motor.Value;
            var result = results.BasicPremium;
            var covertype = new CoverType();
            switch (covertype)
            {
                case CoverType.PrivateIndividual:
                    percentage = 0.05;
                    break;
                case CoverType.Corporate:
                    percentage = 0.06;
                    break;
                case CoverType.Taxi:
                    percentage = 0.07;
                    break;
                case CoverType.Hiring:
                    percentage = 0.07;
                    break;
                case CoverType.MiniBus:
                    percentage = 0.07;
                    break;
                case CoverType.MaxiBus:
                    percentage = 0.07;
                    break;
                case CoverType.MotorCycle:
                    percentage = 0.03;

                    break;
                case CoverType.Ambulance:
                    percentage = 0.07;
                    break;
                case CoverType.OwnGoods:
                    percentage = 0.04;
                    break;
                case CoverType.ArticulatorOrTanker:
                    percentage = 0.08;
                    break;
                case CoverType.GeneralCartage:
                    percentage = 0.06;
                    break;
                case CoverType.SpecialOnSite:
                    percentage = 0.015;
                    break;
                case CoverType.SpecialOnRoad:
                    percentage = 0.03;
                    break;
                case CoverType.GW1Class1:
                    percentage = 0.05;
                    break;
                case CoverType.GW1Class2:
                    percentage = 0.06;
                    break;
                case CoverType.GW1Class3:
                    percentage = 0.07;
                    break;
                default:
                    break;
            }
            result = percentage * _value;
            return await Task.FromResult(result);
        }

        public Task ComprehensiveBasic()
        {
            var resulty = results.BasicPremium + results.CCLoading + results.AgeLoading + results.THirdPartyBasicPre;
            return Task.FromResult(resulty);
        }

        public Task CubicLoading()
        {
            int lessThan = 0;
            double greaterThan = 0.05;
            double other = 0.01;
            var result = results.CCLoading;
            if (_motor.CubicCapacity < 1600)
            {
                result = (lessThan * results.BasicPremium);
            }
            if (_motor.CubicCapacity <= 2000)
            {
                result = (greaterThan * results.BasicPremium);
            }
            else
                result = (other * results.BasicPremium);

            return Task.FromResult(result);
        }

        public Task ExcessBought()
        {
  
            var result = _motor.ExcessBought * results.BasicPremium;

            return Task.FromResult(result);
        }

        public Task ExtraSeat()
        {
            var result = results.ExtraSeat;
            if (CoverType.PrivateIndividual.Equals("Private Individual"))
            {
              var res = (_motor.SeatCapacity - 5) * (5 / 1) < 0;
                
            }
            else
            {
               var others = _motor.SeatCapacity - 5 * (8 / 1) < 0;
            }
            return Task.FromResult(result);
        }

        public Task ExtraThirdParty()
        {
            var result = _motor.ThirdPartyPD - (5000 / 1) * 0.02 > 0;
            return Task.FromResult(result);
        }

        public Task FleetClaimDiscount()
        {
            var result = (results.ComprehemsiveBasic - results.NCD) * _motor.FCD;
            return Task.FromResult(result);
        }

        public Task GrossPremium()
        {
            var result = results.ComprehemsiveBasic - results.NCD - results.FCD;
            return Task.FromResult(result);
        }

        public Task NoClaimDiscount()
        {

            var ncDiscountRate = _motor.NCD * results.ComprehemsiveBasic;
            return Task.FromResult(results);
        }

        public Task OfficeCharge()
        {
            var covertype = new CoverType();
            var value = 0;
            switch (covertype)
            {
                case CoverType.PrivateIndividual:
                    value = 55;
                    break;
                case CoverType.Corporate:
                    value = 55;
                    break;
                case CoverType.Taxi:
                    value = 60;
                    break;
                case CoverType.Hiring:
                    value = 60;
                    break;
                case CoverType.MiniBus:
                    value = 60;
                    break;
                case CoverType.MaxiBus:
                    value = 60;
                    break;
                case CoverType.MotorCycle:
                    value = 50;
                    break;
                case CoverType.Ambulance:
                    value = 57;
                    break;
                case CoverType.OwnGoods:
                    value = 65;
                    break;
                case CoverType.ArticulatorOrTanker:
                    value = 65;
                    break;
                case CoverType.GeneralCartage:
                    value = 65;
                    break;
                case CoverType.SpecialOnSite:
                    value = 40;
                    break;
                case CoverType.SpecialOnRoad:
                    value = 65;
                    break;
                case CoverType.GW1Class1:
                    value = 60;
                    break;
                case CoverType.GW1Class2:
                    value = 60;
                    break;
                case CoverType.GW1Class3:
                    value = 60;
                    break;
                default:
                    value = 0;
                    break;
            }
            var result = value / 1;
            return Task.FromResult(result);
        }

        public Task PremiumCalculation()
        {
            var result = results.GrossPremium + results.ExcessBought + results.ExtraTPPd + results.OfficeCharge + results.ExtraSeat;
            return Task.FromResult(result);
        }

        public Task ThirdPartyBasicPremium()
        {
            double value;
            var result = results.THirdPartyBasicPre;
            var covertype = new CoverType();
            switch (covertype)
            {
                case CoverType.PrivateIndividual:
                    value = 272;
                    break;
                case CoverType.Corporate:
                    value = 272;
                    break;
                case CoverType.Taxi:
                    value = 378;
                    break;
                case CoverType.Hiring:
                    value = 387;
                    break;
                case CoverType.MiniBus:
                    value = 387;
                    break;
                case CoverType.MaxiBus:
                    value = 387;
                    break;
                case CoverType.MotorCycle:
                    value = 99;
                    break;
                case CoverType.Ambulance:
                    value = 297;
                    break;
                case CoverType.OwnGoods:
                    value = 387;
                    break;
                case CoverType.ArticulatorOrTanker:
                    value = 594;
                    break;
                case CoverType.GeneralCartage:
                    value = 486;
                    break;
                case CoverType.SpecialOnSite:
                    value = 198;
                    break;
                case CoverType.SpecialOnRoad:
                    value = 387;
                    break;
                case CoverType.GW1Class1:
                    value = 330;
                    break;
                case CoverType.GW1Class2:
                    value = 440;
                    break;
                case CoverType.GW1Class3:
                    value = 550;
                    break;
                default:
                    value = 0;
                    break;
            }
            result = ((value) / (1));
            return Task.FromResult(result);
        }
    }
}
