using BugTrackerV2.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTrackerV2.Models
{
    public class TicketDetailViewModel
    {

        public int TicketID { get; set; }
        public string SubmitterID { get; set; }
        public string? OwnerID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Enums.Environment Environment { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime SubmitDate { get; set; }
        public virtual ApplicationUser Submitter { get; set; }
        public virtual ApplicationUser Owner { get; set; }
        public virtual ICollection<TicketComment> TicketComments { get; set; }
        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }
        public int TicketCommentID { get; set; }
        [Required]
        [StringLength(2500, MinimumLength = 10)]
        public string CommentDescription { get; set; }
        public DateTime PostDate { get; set; }
        public string UserID { get; set; }
    }
}