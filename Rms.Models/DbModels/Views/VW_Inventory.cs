using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.DbModels.Views
{
    public class VW_Inventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public float StockQty { get; set; }
        public int? Sl { get; set; }
    }
}
