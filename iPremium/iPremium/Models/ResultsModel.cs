using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iPremium.Models
{
    public class ResultsModel
    {
        public double BasicPremium { get; set; }
        public double AgeLoading { get; set; }
        public double CCLoading { get; set; }
        public double THirdPartyBasicPre { get; set; }
        public double ComprehemsiveBasic { get; set; }
        public double GrossPremium { get; set; }
        public double ExtraTPPd { get; set; }
        public double OfficeCharge { get; set; }
        public double ExtraSeat { get; set; }
        public Task PremiumPackage { get; set; }
        public double NCD { get; set; }
        public double FCD { get; set; }
        public double ExcessBought { get; internal set; }
    }
}
