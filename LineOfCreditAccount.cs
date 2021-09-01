namespace BankTransactions
{
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {
        }

        public override void PerformMonthEndTransactions()
        {
            // Negue o saldo para obter uma cobrança de juros positiva:
            var interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.Now, "Cobrar juros mensais");
        }
    }
}