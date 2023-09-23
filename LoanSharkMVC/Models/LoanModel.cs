namespace LoanSharkMVC.Models
{
    public class LoanModel
    {
        public decimal LoanAmount { get; set; }
        public decimal LoanInterest { get; set; }
        public int LoanTerm { get; set; }
        public decimal LoanPayment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalCost { get; set; }

        public List<LoanPaymentModel> LoanPayments { get; set; } = new();
    }
}
