using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Outlook_Signatures_Management.Models
{
    public class Signature
    {
        public int SignatureId { get; set; }
        public string SignatureName { get; set; }
        public bool IsForwardReply { get; set; }
        public string Body { get; set; }
        public bool IsDefault { get; set; }
        public bool IsOptional { get; set; }
        public string Notes { get; set; }
        public DateTime DateAdded { get; set; }

    }
}