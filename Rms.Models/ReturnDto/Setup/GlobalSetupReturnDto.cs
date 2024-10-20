using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.ReturnDto.Setup
{
    public class GlobalSetupReturnDto
    {
        public int Id { get; set; }
        public decimal ResidentialEBill { get; set; }
        public decimal CommercialEBill { get; set; }
        public decimal ResidentialMiniUnit { get; set; }
        public decimal CommercialMiniUnit { get; set; }
        public decimal DutyOnKHW { get; set; }
        public decimal DemandCharge { get; set; }
        public decimal ElectricMotorCharge { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal VAT { get; set; }
        public decimal DelayCharge { get; set; }
    }
}
