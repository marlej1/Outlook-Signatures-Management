using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Outlook_Signatures_Management.Models
{
    public class Campaign
    {
        public int CampaignId { get; set; }
        [Required]
        [DisplayName("Campaign Name")]
        public string CampaignName { get; set; }
        [AllowHtml]
        public string Content { get; set; }
        [DisplayName("Notes")]
        public string SideNotes { get; set; }
        public bool Disabled { get; set; }
        [DisplayName("Is Always Active")]
        public bool IsAlwaysActive { get; set; }
        [Required]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public DateTime DateAdded { get; set; }
        public IEnumerable<Signature> Signatures { get; set; }

    }
}