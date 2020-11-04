using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTrackerV2.Enums
{
    public enum Status
    {
        Submitted,
        [Display(Name = "Under Review")]
        UnderReview,
        [Display(Name = "Client Action Required")]
        ClientActionRequired,
        Resolved,
        Rescinded
    }
}