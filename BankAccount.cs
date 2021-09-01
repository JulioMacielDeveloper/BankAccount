using System.Collections.Generic;


namespace BankTransactions
{
    public class BankAccount
    {
        private static int accountNumerSeed = 0000000001;
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }



        private readonly decimal minimumBalance;

        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
        {

        }


        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            this.Number = accountNumerSeed.ToString();
            accountNumerSeed++;

            this.Owner = name;
            this.minimumBalance = minimumBalance;
            if (initialBalance > 0)
            {
                MakeDeposit(initialBalance, DateTime.Now, "Saldo Inicial");
            }
        }

        private List<Transaction> allTransactions = new List<Transaction>();





        // Regra para o valor de depósito ser positivo
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "O valor de depósito deve ser positivo");
            }

            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }



        // Regra para o valor de saque ser positivo
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "O valor da retirada deve ser positivo");
            }
            var overdraftTransaction = CheckWithdrawalLimit(Balance - amount < minimumBalance);
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
            if (overdraftTransaction != null)
                allTransactions.Add(overdraftTransaction);
        }

        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Sem saldo suficiente para saque");
            }
            else
            {
                return default;
            }
        }






        public virtual void PerformMonthEndTransactions() // Conceito de Polimorfismo
        {

        }










        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }


    }
}