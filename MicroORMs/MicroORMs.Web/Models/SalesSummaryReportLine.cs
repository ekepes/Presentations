using System;

namespace MicroORMs.Web.Models
{
    public class SalesSummaryReportLine
    {
        public string StateCode { get; set; }

        public int SalesYear { get; set; }

        public int SalesMonth { get; set; }

        public decimal MonthlySales { get; set; }

        public string ReportMonth
        {
            get { return DateTime.Parse(SalesMonth.ToString() + "/1/" + SalesYear.ToString()).ToString("MMM yyyy"); }
        }
    }
}