using System;
using BankTransactions;
using static System.Net.Mime.MediaTypeNames;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var account = new BankAccount("Julio Maciel", 100000);
            Console.WriteLine($"Conta nº {account.Number} foi criada para cliente {account.Owner} com saldo inicial de {account.Balance}");

            Console.WriteLine("");

            account.MakeWithdrawal(500, DateTime.Now, "Pagamento aluguel");
            Console.WriteLine($"Após retirada, o saldo atual é: R$ {account.Balance}");

            Console.WriteLine("");

            account.MakeDeposit(1000, DateTime.Now, "Valor recebido de serviços");
            Console.WriteLine($"Após valor recebido e depositado, o saldo atual é: R$ {account.Balance}");

            Console.WriteLine("");
            Console.WriteLine("");

            // BankAccount invalidAccount;
            // try
            // {
            //     invalidAccount = new BankAccount("invalid", -55);
            // }
            // catch (ArgumentOutOfRangeException e)
            // {
            //     Console.WriteLine("Exceção capturada ao criar conta com saldo negativo");
            //     Console.WriteLine(e.ToString());
            //     return;
            // }


            // try
            // {
            //     account.MakeDeposit(750, DateTime.Now, "Tentativa de overdraw");
            // }
            // catch (InvalidOperationException e)
            // {
            //     Console.WriteLine("Exceção capturada tentando overdraw");
            //     Console.WriteLine(e.ToString());
            // }


            Console.WriteLine(account.GetAccountHistory());



            Console.WriteLine("");


            Console.WriteLine("Transações da conta de Cartão Presente");

            var giftCard = new GiftCardAccount("Cartão Presente", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "Comprei um café");
            giftCard.MakeWithdrawal(50, DateTime.Now, "Comprar mantimentos");
            giftCard.PerformMonthEndTransactions();
            // Pode fazer depósitos adicionais:
            giftCard.MakeDeposit(237.50m, DateTime.Now, "Adicionar uma renda extra");
            Console.WriteLine(giftCard.GetAccountHistory());


            Console.WriteLine("");


            Console.WriteLine("Transações da conta de Juros mensais");


            var savings = new InterestEarningAccount("Conta de Juros", 10000);
            savings.MakeDeposit(750, DateTime.Now, "Day trade");
            savings.MakeDeposit(1250, DateTime.Now, "Juros adicionados");
            savings.MakeWithdrawal(250, DateTime.Now, "Necessário para pagar contas mensais");
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());


            Console.WriteLine("");


            Console.WriteLine("Transações da conta de Linha de Crédito");

            var lineofCredit = new LineOfCreditAccount("Linha de crédito", 0);
            // Quanto é muito para pedir emprestado?
            lineofCredit.MakeWithdrawal(1000m, DateTime.Now, "Retirar adiantamento mensal");
            lineofCredit.MakeDeposit(50m, DateTime.Now, "Pague uma pequena quantia");
            lineofCredit.MakeWithdrawal(5000m, DateTime.Now, "Fundo de emergência para reparos");
            lineofCredit.MakeDeposit(150m, DateTime.Now, "Restauração parcial dos reparos");
            lineofCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineofCredit.GetAccountHistory());
        }




    }
}