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
    
    public partial class SaleInvoice
    {
        public SaleInvoice()
        {
            this.SaleInvoiceLine = new HashSet<SaleInvoiceLine>();
        }
    
        public string InvoiceNo { get; set; }
        public string InvoiceStatus { get; set; }
        public string Period { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<System.DateTime> SystemEntryDate { get; set; }
        public string CustomerID { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<SaleInvoiceLine> SaleInvoiceLine { get; set; }
        public virtual SaleInvoiceTotal SaleInvoiceTotal { get; set; }
    }
}