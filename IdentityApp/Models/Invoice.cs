using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityApp.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Invoice Amount")]
       
        public double InvoiceAmount { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Invoice Month")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MMMM yy }", ApplyFormatInEditMode = true)]

        public string InvoiceMonth { get; set; }
       

        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Invoice Owner")]
        [MaxLength(12, ErrorMessage = "Maximum 12 characters only.")]

        public string InvoiceOwner { get; set; }
        public string CreatorId { get; set; }
        public InvoiceStatus Status { get; set; }
    }

    public enum InvoiceStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
