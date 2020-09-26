using System;
using System.Collections.Generic;
using System.Text;

namespace iPremium.Models
{
    public class MotorCalModel
    {
        public int Id { get; set; }
        public string CoverType { get; set; }
        public string VehicleMake { get; set; }
        public string RegistrationNumber { get; set; }
        public int SeatCapacity { get; set; }
        public int CubicCapacity { get; set; }
        public DateTime YearOfMake { get; set; }
        public double Value { get; set; }
        public double ThirdPartyPD { get; set; }
        public double ExcessBought { get; set; }
        public double NCD { get; set; }
        public double FCD { get; set; }
    }
}
