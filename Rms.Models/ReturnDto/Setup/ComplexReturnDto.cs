using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.ReturnDto.Setup
{
    public class ComplexReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ComplexNo { get; set; }
        public decimal RentAmount { get; set; }
        public decimal ServiceAmout { get; set; }
        public decimal MotorcycleParkingAmount { get; set; }
        public decimal CarParkingAmount { get; set; }
        public int UserId { get; set; }
        public string? UsersFullName { get; set; }
        public int Sl { get; set; }
    }
}
