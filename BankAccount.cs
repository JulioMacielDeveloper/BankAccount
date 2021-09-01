namespace BankTransactions
{
    public class BankAccount
    {
        public BankAccount(string number, string owner, decimal balance)
        {
            this.Number = number;
            this.Owner = owner;
            this.Balance = balance;

        }
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { get; }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
        }
    }
}