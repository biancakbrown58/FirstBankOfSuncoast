# FirstBankOfSuncoast

Transaction Class
-Checking
-Savings
-Deposit Method() //That cannot be negative
---->Adds to total
-Withdraw Method() //That cannot be negative
---->Removes from total
-Show Transaction List Method()? //That cannot be negative
---->Gets list of by looping through items in a list and printing to console
-Get totals Method()
---->Adds the totals for Checking and Savings

---Menu---
ask for a string
(deposit / withdraw / balance / view all / quit)

(Deposit)
Which account? C or S
--Checking--
if C (checking) ask for amount.
add amount to total of checking (like enclosure somehow?)
--Savings--
if S (savings) ask for amount.
add amount to total of savings (like enclosure somehow?)

(WithDraw)
Which account? C or S
--Checking--
if C (checking) ask for amount.
remove amount from total of checking (like enclosure somehow?)
--Savings--
if S (savings) ask for amount.
remove amount from total of savings (like enclosure somehow?)

(Balance)
Which account? C or S
--Checking--
if C (checking) show total of all transactions
--Savings--
if S (savings) show total of all transactions

(Transaction History)
Which account? C or S
--Checking--
if C (checking) for each transaction in transactions "date - withdraw/deposit - amount - balance???
--Savings--
if S (savings) for each transaction in transactions "date - withdraw/deposit - amount - balance???

Jordan PEDAC

Data Types

> in trans class
> -total amount
> -account type -string --Checking and savings (only evens survive example) **\*\*\*\***
> -time of transaction
> -transaction type -string --deposit and withdraw ()
> user inputs - string to be converted to and in when needed **\*\*\*\***

Algorithm

> welcome
> load transactions (csv file reader)
> display options
> show user response with accout, amount, type, timestamp
> add transaction to transaction list
> save transaction to csv file
> withdraw -filter out the deposit and sum the total of the deposit (where)
> filter out the withdra and sum the total of the withdraw (where)
> ask amout. if (diff < askingamount ) { no funds}
> transaction history - filter out checking or savings-foreach-
> balance - filter out the deposit and sum the total of the depost and withdraw
> -- diff=deposit-withdraw amt.

tried
using System;
using System.Collections.Generic;
using System.Linq;
///////////
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

    }




    class Transaction
    {
        public string AccountType { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        // Deposit
        // Withdraw
        // Show Transactions
        // Total

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
        // checking or savings account?
        static string CheckingOrSavings(string checkOrSave)
        {
            Console.Write(checkOrSave);
            var userInputCorS = Console.ReadLine().ToUpper();
            if (userInputCorS == "C")
            {
                return userInputCorS = "Checking";
            }
            else if (userInputCorS == "S")
            {
                return userInputCorS = "Savings";
            }
            else
            {
                Console.WriteLine("Invalid");
                return "Invalid";
            }
        }

        // deposit or withdraw
        static string DepositOrWithdraw(string depOrWith)
        {
            Console.Write(depOrWith);
            var userInputDorW = Console.ReadLine().ToUpper();
            if (userInputDorW == "D")
            {
                return userInputDorW = "Deposit";
            }
            else if (userInputDorW == "W")
            {
                return userInputDorW = "Withdraw";
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

            var isRunning = true;
            while (isRunning)
            {
                var transaction = new Transaction();

                transaction.TransactionType = DepositOrWithdraw("Deposit or Withdraw");


                // var choice = Console.ReadLine().ToUpper();

                // switch (choice)
                // {
                //     case "Q":
                //         isRunning = false;
                //         break;

                //     case "D":


                //         transaction = new Transaction();

                //         transaction.AccountType = CheckingOrSavings("(C)hecking or (S)avings");
                //         Console.WriteLine("got here");
                //         database.AddTransaction(transaction);


                //         break;

                //     case "W":
                //         transaction = new Transaction();
                //         transaction.AccountType = CheckingOrSavings("(C)hecking or (S)avings");

                //         database.AddTransaction(transaction);

                //         break;
                //     case "V":
                //         var allTransactions = database.GetTransactions();
                //         foreach (var transactionsToShow in allTransactions)
                //         {
                //             Console.WriteLine($"{transactionsToShow.TransactionDate} - Checking - ${transactionsToShow.AccountType}");
                //         }

                //         break;
                // }
            }
        }
    }

}
