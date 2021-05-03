using RunTeam.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Application.Features.OrderLines.Queries
{
    public class OrderLineViewModel
    {
        public int HeaderId { get; set; }
        public int LineNumber { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string UOM { get; set; }
        public int TaxRate { get; set; }
        public decimal Amount { get; set; }
        public DateTime PromiseDate { get; set; }
        public int Status { get; set; }
        public string StatusDesc
        {
            get { return (Enum.GetName(typeof(enumOrderLineStatus), Status)); }
        }
    }
}
