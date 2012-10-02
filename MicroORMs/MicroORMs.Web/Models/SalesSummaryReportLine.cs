namespace MicroORMs.Web.Models
{
    public class SalesSummaryReportLine
    {
        public string StateCode { get; set; }

        public int SalesYear { get; set; }

        public int SalesMonth { get; set; }

        public decimal MonthlySales { get; set; }
    }
}