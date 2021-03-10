using RunTeam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Domain.Entities
{
    public class Product : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool EnableFlag { get; set; }
        public DateTime StartActiveDate { get; set; }
        public DateTime EndActiveDate { get; set; }
        public int CutOffTimeMin { get; set; }
        public string Segment1 { get; set; }
        public string Segment2 { get; set; }
        public string Segment3 { get; set; }
        public string Segment4 { get; set; }
        public string Segment5 { get; set; }
        public bool ShippableItemFlag { get; set; }
        public bool CustomerOrderFlag { get; set; }
        public bool ServiceItemFlag { get; set; }
        public int ItemCatalogId { get; set; }
        public decimal PricePerUnit { get; set; }
        public string PrimaryUomCode { get; set; }
        public int RegistrationStatus { get; set; }
        public int EventId { get; set; }
    }
}
