﻿using RunTeam.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Application.Features.Products.Queries
{
    public class GetAllProductsViewModel
    {
        public int Id { get; set; }
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
        public int RegisterLimit { get; set; }
        public int EventId { get; set; }
        public int RegisterCount { get; set; }
        public int PaymentCount { get; set; }
        public string EventName { get; set; }

        public string StatusDesc
        {
            get { return (Enum.GetName(typeof(enumProductStatus), RegistrationStatus)); }
        }
    }
}
