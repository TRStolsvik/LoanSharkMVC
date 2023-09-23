namespace LoanSharkMVC.Models
{
    public class LoanModel
    {
        public double LoanAmount { get; set; }
        public double LoanTerm { get; set; }
        public double LoanInterest { get; set; }
        public double TotalInterest { get; set; }
        public double MonthlyInteres { get; set; }
        public double InterestRate { get; set; }
        public double MonthlyPayment { get; set; }
        public double MonthlyPrincipal { get; set; }
        public double CurrentMonth { get; set; }
        public double CurrentBalance { get; set; }
    }
}
