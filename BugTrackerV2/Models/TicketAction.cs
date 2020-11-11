using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTrackerV2.Models
{
    public class TicketAction
    {
        public int TicketActionID { get; set; }
        [Required]
        public int TicketID { get; set; }
        [Required]
        public string Field { get; set; }
        [Required]
        public Enums.Action Action { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        [Required]
        public DateTime ActionTime { get; set; }

        public virtual Ticket Ticket { get; set; } //Parent 
    }
}