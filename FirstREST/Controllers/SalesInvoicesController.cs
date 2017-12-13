﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;
using FirstREST.Models;


namespace FirstREST.Controllers
{
    public class DocVenda
    {
        public Models.Invoice invoice { get; set; }
        public List<Models.Line> lines { get; set; }
        public Models.DocumentTotals docs { get; set; }

        public DocVenda(Models.Invoice invoice, List<Models.Line> lines, Models.DocumentTotals docs)
        {
            this.invoice = invoice;
            this.lines = lines;
            this.docs = docs;
        }
        public DocVenda() { }
    }

    public class SaleInvoice
    {
        public Models.Invoice invoice { get; set; }
        public List<Models.Line> line { get; set; }

        public SaleInvoice(Models.Invoice invoice, List<Models.Line> line)
        {
            this.invoice = invoice;
            this.line = line;
        }
    }

    public class Sums : DocVenda
    {
        public double sumDay = 0;
        public double sumMonth = 0;
        public double sumYear = 0;
        public double sumTotal = 0;
        public Sums(double year, double month, double day, double total)
        {
            sumDay = day;
            sumMonth = month;
            sumYear = year;
            sumTotal = total;
        }
    }

    public class SalesInvoicesController : ApiController
    {
        DatabaseEntities db = new DatabaseEntities();


        public List<DocVenda> Get()
        {
            DateTime time = DateTime.Today;
            var year = time.Year;
            var month = time.Month;
            var day = time.Day;

            double sumYear = 0;
            double sumMonth = 0;
            double sumDay = 0;
            double sumTotal = 0;

            var docs = new List<DocVenda>();

            List<Models.Invoice> invoices = (from i in db.Invoice select i).ToList();
            foreach (Models.Invoice invoice in invoices)
            {
                List<Models.Line> lines = (from i in db.Invoice
                                           join l in db.Line
                                           on i.InvoiceNo equals l.InvoiceNo
                                           where i.InvoiceNo == invoice.InvoiceNo
                                           select l).ToList();

                Models.DocumentTotals doc = (from d in db.DocumentTotals
                                             where d.InvoiceNo == invoice.InvoiceNo
                                             select d).AsQueryable().First();

                docs.Add(new DocVenda(invoice, lines, doc));
                DateTime de = DateTime.Parse(invoice.InvoiceDate);
                sumTotal += doc.GrossTotal;
                if (de.Year >= year-1)
                {
                    sumYear += doc.GrossTotal;
                    if (de.Month >= month)
                    {
                        sumMonth += doc.GrossTotal;
                        if (de.Day == day)
                        {
                            sumDay += doc.GrossTotal;
                        }
                    }
                }
            }
            docs.Add(new Sums(sumYear, sumMonth, sumDay, sumTotal));
            //docs = docs.OrderByDescending(x => x.Data).ToList();
            
            return docs;
        }


        [Route("api/DocVenda/get?id={id*}")]
        public DocVenda Get(string id)
        {
            try
            {
                Models.Invoice invoice = (from i in db.Invoice
                                          where i.InvoiceNo == id
                                          select i).AsQueryable().First();

                List<Models.Line> lines = (from i in db.Invoice
                                           join l in db.Line
                                           on i.InvoiceNo equals l.InvoiceNo
                                           where i.InvoiceNo == invoice.InvoiceNo
                                           select l).ToList();

                Models.DocumentTotals doc = (from d in db.DocumentTotals
                                             where d.InvoiceNo == invoice.InvoiceNo
                                             select d).AsQueryable().First();

                return new DocVenda(invoice, lines, doc);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
        }

        public List<SaleInvoice> GetByProduct(string id)
        {
            try
            {
                List<SaleInvoice> list = new List<SaleInvoice>();

                List<Models.Invoice> invoices = (from i in db.Invoice
                                                join l in db.Line
                                                on i.InvoiceNo equals l.InvoiceNo
                                                where l.ProductCode == id
                                                select i).ToList();

                foreach (var invoice in invoices)
                {
                    List<Models.Line> lines = (from i in db.Line
                                               where i.InvoiceNo == invoice.InvoiceNo
                                               && i.ProductCode == id
                                               select i).ToList();

                    if (list.Find(x => x.invoice == invoice) == null)
                    {
                        list.Add(new SaleInvoice(invoice, lines));
                    }
                }

                return list;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
        }

        public List<SaleInvoice> GetByClient(string id)
        {
            try
            {
                List<SaleInvoice> list = new List<SaleInvoice>();

                List<Models.Invoice> invoices = (from i in db.Invoice
                                                 where i.CustomerID == id
                                                 select i).ToList();

                foreach (var invoice in invoices)
                {
                    List<Models.Line> lines = (from i in db.Line
                                               where i.InvoiceNo == invoice.InvoiceNo
                                               select i).ToList();

                    list.Add(new SaleInvoice(invoice, lines));
                }

                return list;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
        }
    }
}
