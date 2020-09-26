using iPremium.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iPremium.ViewModel
{
    public class ResultsViewModel : BaseViewModel
    {
        private MotorCalViewModel _motor;
        private ResultsModel _result;
        private DateTime year;
        public ResultsViewModel(MotorCalViewModel motor)
        {
            _motor = motor;
        }

        private async Task Results()
        {
            //_result.BasicPremium = _motor.BasicPremium();
            //_result.CCLoading = _motor.CubicLoading();
            //_result.AgeLoading =  _motor.AgeLoading(year);
            //_result.THirdPartyBasicPre = _motor.ThirdPartyBasicPremium();
            //_result.ComprehemsiveBasic = _motor.ComprehensiveBasic();
            //_result.NCD = _motor.NoClaimDiscount();
            //_result.FCD = _motor.FleetClaimDiscount();
            //_result.GrossPremium = _motor.GrossPremium();
            //_result.ExcessBought = _motor.ExcessBought();
            //_result.ExtraTPPd = _motor.ExtraThirdParty();
            //_result.OfficeCharge = _motor.OfficeCharge();
            //_result.ExtraSeat = _motor.ExtraSeat();
            _result.PremiumPackage = _motor.PremiumCalculation();

        }
        #region Calculating Basic Premium using PropertyChangedEvents and Commands
        public double _basicPremium;
        public double BasicPremium
        {
            get { return _basicPremium; }
            set
            {
                _basicPremium = value;
                OnPropertyChanged();
            }
        }
       
        #endregion

    }
}
