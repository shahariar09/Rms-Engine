﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Models.DbModels.Views
{
    public class ElectricBillSummaryView
    {
        public long Id { get; set; }
        public int CustomerId { get; set; }
        public string BillNo { get; set; }
        public int EletricBillType { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal PresentReading { get; set; }
        public decimal ConsumedUnit { get; set; }
        public decimal ElectricCharge { get; set; }
        public decimal DemandCharge { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DutyOnKhw { get; set; }
        public decimal ShopServiceCharge { get; set; }
        public decimal Vat { get; set; }
        public decimal BillMonthTotal { get; set; }
        public bool BillPayStatus { get; set; }
        public DateTime? BillPayDate { get; set; }
        public decimal? PaidAmount { get; set; }

    }
}
