using System;
using System.Collections.Generic;

namespace ATMLAB
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account> accountList = new List<Account>
            {
                new Account("Shamita", "xyz@123", 1000, false),
                new Account("Natalie", "abc@456", 5000, false),
                new Account("Khyati", "def@789",4000, false),
                new Account("James", "xyz@123", 3000, false),
                new Account("Joe", "xyt@124", 2000, false),
                new Account("Steve", "xdz@423", 5000, false),
                new Account("Matt", "xrz@121", 6000, false),
                new Account("Peter", "xkz@173",9000, false)
            };

            Console.WriteLine("Welcome to the ATM!");
            bool wantToQuit = false;
            bool wantToContinue = true;
            bool isUserLogged = false;
            int accountIndex = -1;

            while (wantToContinue)
            {
                wantToQuit = false;
                Console.WriteLine("ATM Menu:");
                ATM.DisplayMenu();

                string userChoice = ATM.GetUserInput("What menu item are you interested in?\n" +
                          "Please enter your selection:").ToLower();


                //Using switch case statements calling different methods for register, login, logout, checkbalance, deposit, withdraw or quit based on user input)
                switch (userChoice)
                {
                    case "1":
                    case "Register":
                        accountList = ATM.Register(accountList);
                        break;
                    case "2":
                    case "Login":
                        accountList = ATM.Login(accountList); 
                        break;
                    case "3":
                    case "CheckBalance":
                        accountIndex = loggedUserAccountIndex(accountList);
                        Console.WriteLine($"Your current account balance is {ATM.CheckBalance(accountList, accountIndex)}");
                        break;
                    case "4":
                    case "Deposit":
                        accountIndex = loggedUserAccountIndex(accountList);
                        List<Account> tempList = new List<Account>(ATM.Deposit(accountList, accountIndex));
                        Console.WriteLine($"Your new account balance is {tempList[accountIndex].Balance}");
                        break;
                    case "5":
                    case "Withdraw":
                        accountIndex = loggedUserAccountIndex(accountList);
                        List<Account> tempList1 = new List<Account>(ATM.Withdraw(accountList, accountIndex));
                        Console.WriteLine($"Your new account balance is {tempList1[accountIndex].Balance}");
                        break;
                    case "6":
                    case "LogOut":
                        if(isUserLoggedIn(accountList))
                        {
                            wantToQuit = true;
                            wantToContinue = false;
                        }
                        else
                        {
                            wantToContinue = true;
                        }                  
                        break;
                    default:  //Validating if you user entered valid number from 1-7 or correct menu iten name                       
                        Console.WriteLine("Invalid entry, please enter valid menu item.");
                        wantToQuit = true;
                        wantToContinue = true;
                        break;
                }

                //asking user if they want to continue
                if (!wantToQuit)
                {
                    wantToContinue = ATM.KeepGoing($"Would you like to continue (y/n)?", "n", "y");
                }


            }
            Console.WriteLine("Thank you for your time, Have a great day!");
            Console.ReadKey();
        }

        public static bool isUserLoggedIn(List<Account> accountList)
        {
            bool temp = false;

            for (int i = 0; i < accountList.Count; i++)
            {
                if (accountList[i].LoggedIn == true)
                {
                    temp = true;
                    break;
                }
            }

            return temp;
        }

        public static int loggedUserAccountIndex(List<Account> accountList)
        {
            int temp = -1;

            for (int i = 0; i < accountList.Count; i++)
            {
                if (accountList[i].LoggedIn == true)
                {
                    temp = i;
                    break;
                }
            }

            return temp;
        }
    }

        
}
