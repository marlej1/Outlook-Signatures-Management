using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Outlook_Signatures_Management.Models
{
    public class Campaign
    {
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string Content { get; set; }
        public string SideNotes { get; set; }
        public bool Enabled { get; set; }
        public bool IsAlwaysActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public DateTime DateAdded { get; set; }
        public IEnumerable<Signature> Signatures { get; set; }

    }
}