using Rms.Models.Common;
using Rms.Models.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.Entities.Setup
{
    [Table("RMS_COMPLEX")]
    public class Complex: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ComplexNo { get; set; }
        public decimal RentAmount { get; set; }
        public decimal ServiceAmout { get; set; }
        public decimal MotorcycleParkingAmount { get; set; }
        public decimal CarParkingAmount { get; set; }
        public int UserId { get; set; }
        public User Users { get; set; }
    }
}
