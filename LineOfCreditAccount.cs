namespace BankTransactions
{
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimet) : base(name, initialBalance, -creditLimet)
        {
        }

        public override void PerformMonthEndTransactions()
        {
            // Negue o saldo para obter uma cobrança de juros positiva:
            var interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.Now, "Cobrar juros mensais");
        }



        // Método usa override para sobreescrever
        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
         isOverdrawn
         ? new Transaction(-20, DateTime.Now, "Aplicar taxa de cheque especial")
         : default;

    }
}