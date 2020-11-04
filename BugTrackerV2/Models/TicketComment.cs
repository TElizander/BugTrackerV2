using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTrackerV2.Models
{
    public class TicketComment
    {
        //Keys

        public int TicketCommentID { get; set; }
        [Required]
        public int TicketID { get; set; }

        //Properties

        [Required]
        [StringLength(2500, MinimumLength = 10)]
        public string CommentDescription { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt} ", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Posted")]
        public DateTime PostDate { get; set; }
        public string UserID { get; set; }

        //Navigation Properties

        public virtual ApplicationUser User { get; set; }     //Child

        public virtual Ticket Ticket { get; set; } //Parent 
    }
}