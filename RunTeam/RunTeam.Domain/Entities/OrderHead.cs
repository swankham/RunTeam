﻿using RunTeam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Domain.Entities
{
    public class OrderHead : AuditableBaseEntity
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public int EventId { get; set; }
        public int Status { get; set; }
        public bool TaxAble { get; set; }
        public int TaxRate { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FreightCharge { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal NetTotalAmount { get; set; }
        public string Remarks { get; set; }
        public int PaymentType { get; set; }
        public int PaymentId { get; set; }
        public int PaymentStatusCode { get; set; }
        public string ShipToAddress { get; set; }
        public string ShipToContact { get; set; }
        public string ShipToContactPhone { get; set; }
    }
}
