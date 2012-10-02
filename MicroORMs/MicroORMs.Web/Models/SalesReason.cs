using System;

namespace MicroORMs.Web.Models
{
    [PetaPoco.TableName("Sales.SalesReason")]
    [PetaPoco.PrimaryKey("SalesReasonID")]
    public class SalesReason
    {
        public int SalesReasonId { get; set; }

        public string Name { get; set; }

        public string ReasonType { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}