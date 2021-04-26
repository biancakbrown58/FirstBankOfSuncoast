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
