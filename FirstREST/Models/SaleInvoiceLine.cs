//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FirstREST.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SaleInvoiceLine
    {
        public int LineNumber { get; set; }
        public string SaleInvoiceNo { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public double UnitPrice { get; set; }
        public Nullable<System.DateTime> TaxPointDate { get; set; }
        public Nullable<double> CreditAmount { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual SaleInvoice SaleInvoice { get; set; }
    }
}
