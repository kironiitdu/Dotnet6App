namespace SwaggerWebAPIApp.Models
{
    public class Invoices
    {
        public int ID { get; set; }

        public string BillToName { get; set; }

        public string ClientName { get; set; }

        public string ClientCode { get; set; }

        public string InvoiceNumber { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public DateTime? InvoiceDueDate { get; set; }

        public string AmountDue { get; set; }

        public string OFFC { get; set; }

        public DateTime? DateImported { get; set; }

        public int? DaysFromDueDate { get; set; }
    }
}
