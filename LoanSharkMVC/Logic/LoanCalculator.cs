using LoanSharkMVC.Models;

namespace LoanSharkMVC.Logic
{
    public static class LoanCalculator
    {
        public static LoanModel GetPayments(LoanModel loan)
        {
            loan.LoanPayment = CalculateMonthlyPayment(loan.LoanAmount, loan.LoanInterest, loan.LoanTerm);

            var balance = loan.LoanAmount;
            var totalInterest = 0.0m;
            var monthlyInterestAmount = 0.0m;
            var monthlyPrincipal = 0.0m;
            var monthlyInterestRate = CalculateMonthlyInterest(loan.LoanInterest);

            for (int month = 1; month <= loan.LoanTerm; month++)
            {
                monthlyInterestAmount = CalculateMonthlyInterestAmount(balance, monthlyInterestRate);
                totalInterest += monthlyInterestAmount;
                monthlyPrincipal = loan.LoanPayment - monthlyInterestAmount;
                balance -= monthlyPrincipal;

                LoanPaymentModel loanPayment = new();

                loanPayment.Month = month;
                loanPayment.Payment = loan.LoanPayment;
                loanPayment.MonthlyPrincipal = monthlyPrincipal;
                loanPayment.MonthlyInterest = monthlyInterestAmount;
                loanPayment.TotalInterest = totalInterest;
                loanPayment.Balance = balance;

                loan.LoanPayments.Add(loanPayment);
            }

            loan.TotalInterest = totalInterest;
            loan.TotalCost = loan.LoanAmount + totalInterest;

            return loan;
        }

        private static decimal CalculateMonthlyPayment(decimal loanAmount, decimal loanInterest, int loanTerm)
        {
            decimal monthlyLoanInterest = CalculateMonthlyInterest(loanInterest);

            double rateDouble = Convert.ToDouble(monthlyLoanInterest);
            double amountDouble = Convert.ToDouble(loanAmount);

            double paymentDouble = (amountDouble * rateDouble) / (1 - Math.Pow(1 + rateDouble, -loanTerm));

            return Convert.ToDecimal(paymentDouble);
        }

        private static decimal CalculateMonthlyInterest(decimal loanInterest)
        {
            return loanInterest / 1200;
        }

        private static decimal CalculateMonthlyInterestAmount(decimal balance, decimal monthlyInterestRate)
        {
            return balance * monthlyInterestRate;
        }
    }
}
