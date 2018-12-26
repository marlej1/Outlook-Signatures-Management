using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Outlook_Signatures_Management.Models
{
    public class Signature
    {
        public int SignatureId { get; set; }
        [Required]
        [DisplayName("Signature Name")]
        public string SignatureName { get; set; }
        [DisplayName("Is Forward/Reply")]
        public bool IsForwardReply { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        [DisplayName("Is Default")]
        public bool IsDefault { get; set; }
        public bool IsOptional { get; set; }
        public string Notes { get; set; }
        public DateTime DateAdded { get; set; }

    }
}