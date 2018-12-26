using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Outlook_Signatures_Management.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]

        public string LastName { get; set; }
        [Required]
        [DisplayName("Display Name")]
        public string DisplayName { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [DisplayName("Fax Number")]
        public string FaxNumber { get; set; }
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }
        [DisplayName("Date Added")]
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