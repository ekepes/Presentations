using System;

namespace MicroORMs.Web.Models
{
    public class SalesReason
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ReasonType { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}