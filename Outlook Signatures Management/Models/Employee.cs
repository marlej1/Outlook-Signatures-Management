using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Outlook_Signatures_Management.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string JobTitle { get; set; }
        public DateTime DateAdded { get; set; }
        public int? DepartmentId { get; set; }
        public virtual  Department Department { get; set; }
        public string Company { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        
        public int? DefaultSignatureId { get; set; }
        [ForeignKey("DefaultSignatureId")]
        public Signature DefaultSignature { get; set; }

        public int? ForwardReplySignatureId { get; set; }
        [ForeignKey("ForwardReplySignatureId")]
        public Signature ForwardReplySignature { get; set; }

        public bool HasIndividualDefaultSignature { get; set; }
        public bool HasIndividualForwardReplySignature { get; set; }

        public string State { get; set; }
        public string Zip { get; set; }
        public string WebSite { get; set; }
    }
}