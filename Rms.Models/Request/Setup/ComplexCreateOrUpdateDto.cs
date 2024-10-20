using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Request.Setup
{
    public class ComplexCreateOrUpdateDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? ComplexNo { get; set; }
        public decimal? RentAmount { get; set; }
        public decimal? ServiceAmout { get; set; }
        public decimal? MotorcycleParkingAmount { get; set; }
        public decimal? CarParkingAmount { get; set; }
        public int? UserId { get; set; }
    }
}
