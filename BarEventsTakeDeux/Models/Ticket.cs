using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BarEventsTakeDeux.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Guid BarCode { get; set; } = Guid.NewGuid();

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yy}")]
        public DateTime? DatePurchased { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double PurchasedPrice { get; set; }

        public bool WasUsed { get; set; } = false;

        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public Events TicketEvent { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order TicketOrder { get; set; }


    }
}