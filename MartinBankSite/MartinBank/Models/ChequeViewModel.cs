using System.ComponentModel.DataAnnotations;

namespace MartinBank.Web.Models
{
    public class ChequeViewModel
    {
        public string BankName { get; set; }

        [Display(Name = "Pay To")]
        public string PayTo { get; set; }

        [Display(Name = "Date")]
        public string DateAsString { get; set; }

        [Display(Name = "Amount ($)")]
        public double Amount { get; set; }

        [Display(Name = "Amount in words")]
        public string AmountInWords { get; set; }

        [Display(Name = "e-Signed")]
        public string ESignature { get; set; }
    }
}