using iPremium.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iPremium.Interfaces
{
    public interface IPrimeCalculation
    {

        public Task<double> BasicPremium();
        public Task CubicLoading();
        public Task AgeLoading(DateTime currentYear);
        public Task ThirdPartyBasicPremium();
        public Task ComprehensiveBasic();
        public Task NoClaimDiscount();
        public Task FleetClaimDiscount();
        public Task GrossPremium();
        public Task ExcessBought();
        public Task ExtraThirdParty();
        public Task OfficeCharge();
        public Task ExtraSeat();
        public Task PremiumCalculation();
    }
}
