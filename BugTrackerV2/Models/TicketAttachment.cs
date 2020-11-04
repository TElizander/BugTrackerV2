using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTrackerV2.Models
{
    public class TicketAttachment
    {
        //Keys

        public int TicketAttachmentID { get; set; }
        [Required]
        public int TicketID { get; set; }
        public string UserID { get; set; }

        //Properties

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FileName { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string FileLocation { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt} ", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Attached")]
        public DateTime AttachedDate { get; set; }

        //Navigation Properties

        public virtual ApplicationUser User { get; set; }     //Child
        public virtual Ticket Ticket { get; set; } //Parent 
    }
}