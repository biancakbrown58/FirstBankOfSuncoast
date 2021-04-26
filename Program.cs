using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace FirstBankOfSuncoast
{
    class TransactionDatabase
    {
        private List<Transaction> transactions = new List<Transaction>();

        // Add a Transaction to the Transaction List
        public void AddTransaction(Transaction newTransaction)
        {
            transactions.Add(newTransaction);
        }
        // Get all Transactions
        public List<Transaction> GetTransactions()
        {
            var viewTransactions = transactions.OrderBy(transactions => transactions.TransactionDate).ToList();
            return viewTransactions;
        }
        public void LoadTransactionsFromCSV()
        {
            var fileReader = new StreamReader("transactions.csv");
            var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
            transactions = csvReader.GetRecords<Transaction>().ToList();
        }

        public void SaveTransactionToCSV()
        {
            var fileWriter = new StreamWriter("transactions.csv");
            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(transactions);
            fileWriter.Close();
        }
    }

    class Transaction
    {
        public void WithdrawChecking(Transaction transaction, int amountToWithdraw)
        {
            transaction.Amount = transaction.Amount - amountToWithdraw;
        }
        public void WithdrawSavings(Transaction transaction, int amountToWithdraw)
        {
            transaction.Amount = transaction.Amount - amountToWithdraw;
        }
        public string AccountType { get; set; }
        public int Amount { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public int Withdraw()
        {
            var negNumber = 0;
            var newTotal = Amount - negNumber;
            return newTotal;
        }
    }

    class Program
    {
        // Greeting User
        static void DisplayGreeting()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("    Welcome to First Bank of Suncoast!    ");
            Console.WriteLine("------------------------------------------");
        }

        // Getting string input from user
        static string AskForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }

        // Getting integer input from user
        static int AskForInteger(string prompt)
        {
            Console.WriteLine(prompt);
            int userInput;
            userInput = int.Parse(Console.ReadLine());
            if (userInput > 0)
            {
                return userInput;
            }
            else if (userInput < 0)
            {
                Console.WriteLine("Invalid Entry");
                return 0;
            }
            else
            {
                return 0;
            }
        }

        // deposit or withdraw
        static string DepositOrWithdraw(string depOrWith)
        {
            Console.Write(depOrWith);
            var userInputDorW = Console.ReadLine().ToUpper();
            if (userInputDorW == "D")
            {
                Console.WriteLine("Deposit");
                return userInputDorW = "Deposit";
            }
            else if (userInputDorW == "W")
            {
                Console.WriteLine("Withdraw");
                return userInputDorW = "Withdraw";
            }
            else
            {
                Console.WriteLine("Invalid");
                return "Invalid";
            }
        }
        static string AskCheckingOrSavings(string depOrWith)
        {
            Console.Write(depOrWith);
            var userInputDorW = Console.ReadLine().ToUpper();
            if (userInputDorW == "C")
            {
                Console.WriteLine("Checking");
                return userInputDorW = "Checking";
            }
            else if (userInputDorW == "S")
            {
                Console.WriteLine("Savings");
                return userInputDorW = "Savings";
            }
            else
            {
                Console.WriteLine("Invalid");
                return "Invalid";
            }
        }
        static void Main(string[] args)
        {
            DisplayGreeting();
            var database = new TransactionDatabase();
            database.LoadTransactionsFromCSV();

            var isRunning = true;
            while (isRunning)
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.Write("(D)eposit -- (W)ithdraw -- (V)iew Transactions -- (B)alance -- (Q)uit: ");
                var transaction = new Transaction();
                var askDepositOrWithdraw = Console.ReadLine().ToUpper();
                switch (askDepositOrWithdraw)
                {
                    // Quit
                    case "Q":
                        isRunning = false;
                        break;

                    // Deposit
                    case "D":
                        Console.WriteLine("Deposit to checking or savings? (C) (S) ");
                        var askUserCheckingOrSavings = Console.ReadLine().ToUpper();

                        //Checking
                        if (askUserCheckingOrSavings == "C")
                        {
                            transaction.AccountType = "Checking";
                            transaction.TransactionType = "Deposit";
                            transaction.Amount = AskForInteger("How much?: ");
                            Console.WriteLine("You're transaction will reflect in your account in 3-5 days");
                            database.AddTransaction(transaction);
                            database.SaveTransactionToCSV();
                        }
                        //Savings
                        else
                        {
                            Console.WriteLine("Depositing to Savings: ");
                            transaction.TransactionType = "Deposit";
                            transaction.AccountType = "Savings";
                            transaction.Amount = AskForInteger("How much?: ");
                            Console.WriteLine("You're transaction will reflect in your account in 3-5 days");
                            database.AddTransaction(transaction);
                            database.SaveTransactionToCSV();
                        }
                        break;

                    // Withdraw
                    case "W":
                        Console.WriteLine("Withdraw from which account? (C)hecking or (S)avings");
                        askUserCheckingOrSavings = Console.ReadLine().ToUpper();


                        var checkIfEnoughFundsS = database.GetTransactions();
                        var accountCheckIfFundsS = checkIfEnoughFundsS.Where(transaction => transaction.AccountType == "Savings");
                        var countIfFundsS = accountCheckIfFundsS.Select(transaction => transaction.Amount);
                        var getSumSaving = countIfFundsS.Sum();

                        //Checking
                        if (askUserCheckingOrSavings == "C")
                        {
                            Console.WriteLine("Withdrawing from Checking: ");
                            transaction.TransactionType = "Withdraw";
                            transaction.AccountType = "Checking";
                            Console.WriteLine("How much: ");
                            var amountToWithdraw = int.Parse(Console.ReadLine());
                            var checkIfEnoughFundsC = database.GetTransactions();
                            var accountCheckIfFundsC = checkIfEnoughFundsC.Where(transaction => transaction.AccountType == "Checking");
                            var countIfFundsC = accountCheckIfFundsC.Select(transaction => transaction.Amount);
                            var getSum = countIfFundsC.Sum();

                            if (getSum < amountToWithdraw)
                            {
                                Console.WriteLine("You do not have enough funds to withdraw");
                            }
                            else
                            {
                                // Console.WriteLine($"{getSum}");
                                transaction.WithdrawChecking(transaction, amountToWithdraw);
                                Console.WriteLine("You're transaction will reflect in your account in 3-5 days");
                                database.AddTransaction(transaction);
                                database.SaveTransactionToCSV();
                                Console.WriteLine($"{transaction.Amount}");
                            }
                        }
                        //Savings
                        else
                        {
                            Console.WriteLine("Withdrawing from Savings: ");
                            transaction.TransactionType = "Withdraw";
                            transaction.AccountType = "Savings";

                            var amountToWithdraw = int.Parse(Console.ReadLine());
                            if (getSumSaving < amountToWithdraw)
                            {
                                Console.WriteLine("You do not have enough funds to withdraw");
                            }
                            else
                            {
                                Console.WriteLine("How much: ");
                                transaction.WithdrawSavings(transaction, amountToWithdraw);
                                Console.WriteLine("You're transaction will reflect in your account in 3-5 days");
                                database.AddTransaction(transaction);
                                database.SaveTransactionToCSV();
                                Console.WriteLine($"{transaction.Amount}");
                            }
                        }
                        break;

                    // View Transactions
                    case "V":
                        var allTransactions = database.GetTransactions();
                        Console.WriteLine("View which account? (C)hecking or (S)avings");
                        askUserCheckingOrSavings = Console.ReadLine().ToUpper();

                        // Checking
                        if (askUserCheckingOrSavings == "C")
                        {
                            var viewChecking = allTransactions.Where(transaction => transaction.AccountType == "Checking");
                            foreach (var transactionsToShow in viewChecking)
                            {
                                Console.WriteLine($"{transactionsToShow.TransactionDate} - {transactionsToShow.TransactionType} - {transactionsToShow.AccountType} - ${transactionsToShow.Amount}");
                            }
                        }
                        // Savings
                        else
                        {
                            var viewSavings = allTransactions.Where(transaction => transaction.AccountType == "Savings");
                            foreach (var transactionsToShow in viewSavings)
                            {
                                Console.WriteLine($"{transactionsToShow.TransactionDate} - {transactionsToShow.TransactionType} - {transactionsToShow.AccountType} - ${transactionsToShow.Amount}");
                            }
                        }
                        break;

                    // Balance
                    case "B":
                        var balanceOfAccounts = database.GetTransactions();
                        Console.WriteLine("View balance for which account? (C)hecking or (S)avings ");
                        askUserCheckingOrSavings = Console.ReadLine().ToUpper();

                        // Checking
                        if (askUserCheckingOrSavings == "C")
                        {
                            var totalCheckingBalance = balanceOfAccounts.Where(transaction => transaction.AccountType == "Checking");
                            var countChecking = totalCheckingBalance.Select(transaction => transaction.Amount).Sum();
                            Console.WriteLine($"Checking Balance: {countChecking}");
                        }
                        // Savings
                        else
                        {
                            var totalSavingsBalance = balanceOfAccounts.Where(transaction => transaction.AccountType == "Savings");
                            var countSavings = totalSavingsBalance.Select(transaction => transaction.Amount).Sum();
                            Console.WriteLine($"Savings Balance: {countSavings}");
                        }
                        break;
                }
            }
        }
    }
}
