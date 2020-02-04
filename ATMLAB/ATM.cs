using System;
using System.Collections.Generic;
using System.Text;

namespace ATMLAB
{
    class ATM
    {
        //Method for userInput
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        //Method to ask user if they want to continue
        public static bool KeepGoing(string message, string option1, string option2)
        {
            string keepGoing = GetUserInput(message).ToLower();
            if (keepGoing == option1)
            {
                return false;
            }
            else if (keepGoing == option2)
            {
                return true;
            }
            else
            {
                return KeepGoing("Not valid! " + message, option1, option2);
            }
        }


        //Method for displaying ATM Menu
        public static void DisplayMenu()
        {
            Console.WriteLine($"1.Register\n2.Login\n3.CheckBalance\n4.Deposit\n5.Withdraw\n6.LogOut");
        }


        //Method for registering user account
        public static List<Account> Register(List<Account> accountList)
        {
            string name = GetUserInput("Please enter your name to register:");
            string password = GetUserInput("Please enter new password to register:");

            accountList.Add(new Account { Name = name, Password = password, Balance = 0 });

            Console.WriteLine("Account Registered!");

            return accountList;
        }

        //Method for loging user
        public static List<Account> Login(List<Account> accountList)
        {
            List<Account> tempList = new List<Account>(accountList);

            string name = ATM.GetUserInput("Please enter your username for login:");
            string password = ATM.GetUserInput("Please enter your password to login:");

            for (int i = 0; i < tempList.Count; i++)
            {
                if(tempList[i].Name == name && accountList[i].Password == password)
                {
                    if(tempList[i].LoggedIn == false)
                    {
                        tempList[i].LoggedIn = true;

                    }
                }
                else
                {
                    tempList[i].LoggedIn = false;
                }

            }
            return tempList;
        }

        //Method for checking balance
        public static decimal CheckBalance(List<Account> accountList, int accountIndex)
        {
            return accountList[accountIndex].Balance;
        }

        //Method for making a deposit
        public static List<Account> Deposit(List<Account> accountList, int accountIndex)
        {
            List<Account> tempList = new List<Account>(accountList);

            decimal depositAmt = decimal.Parse(ATM.GetUserInput("Please enter the deposit amount: "));

            tempList[accountIndex].Balance = accountList[accountIndex].Balance + depositAmt;

            return tempList;
        }

        //Method for withdrawing money
        public static List<Account> Withdraw(List<Account> accountList, int accountIndex)
        {
            List<Account> tempList = new List<Account>(accountList);

            decimal withdrawAmt = accountList[accountIndex].Balance + 1;

            while (withdrawAmt > accountList[accountIndex].Balance)
            {
                withdrawAmt = decimal.Parse(ATM.GetUserInput("Please enter amount you want to withdraw: "));

                Console.WriteLine("Your have insufficent fund, please enter different amount to withdraw: ");
            }

            tempList[accountIndex].Balance = accountList[accountIndex].Balance - withdrawAmt;

            return tempList;
        }

    }
}
