using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Outlook_Signatures_Management.Models
{
    public static class Extensions
    {
        public static bool IsCurrentlyActive(this Campaign campaign)
        {
            return campaign.StartDate.Date <= DateTime.Today && campaign.EndDate.Date >= DateTime.Today;
            
        }

        public static bool IsActive(this Campaign campaign)
        {
            return (campaign.StartDate.Date <= DateTime.Today && campaign.EndDate.Date >= DateTime.Today || campaign.IsAlwaysActive) && !campaign.Disabled;

        }
    }
}