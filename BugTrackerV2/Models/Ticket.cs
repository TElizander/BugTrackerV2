using BugTrackerV2.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Environment = BugTrackerV2.Enums.Environment;

namespace BugTrackerV2.Models
{
    public class Ticket
    {
        //Keys

        [Display(Name = "Ticket Number")]
        public int TicketID { get; set; }       //Primary
        public string SubmitterID { get; set; }    //Foreign, User
        public string? OwnerID { get; set; }       //Foreign, User

        //Properties

        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Subject { get; set; }
        [Required]
        [StringLength(2500, MinimumLength = 10)]
        public string Description { get; set; }
        [Required]
        public Environment Environment { get; set; }
        [Required]
        public Priority Priority { get; set; }
        [Required]
        public Status Status { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt} ", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Submitted")]
        public DateTime SubmitDate { get; set; }

        public bool Edited { get; set; }

        //Navigation Properties

        public virtual ApplicationUser Submitter { get; set; }                                             //Child
        public virtual ApplicationUser Owner { get; set; }                                                 //Child
        public virtual ICollection<TicketComment> TicketComments { get; set; }                  //Child
        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }            //Child
    }
}