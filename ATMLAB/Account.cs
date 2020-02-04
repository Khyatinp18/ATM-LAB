using System;
using System.Collections.Generic;
using System.Text;

namespace ATMLAB
{
    class Account
    {//Fields
        private string name;
        private string password;
        private decimal balance;
        private bool loggedIn;


        //Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public bool LoggedIn
        {
            get { return loggedIn; }
            set { loggedIn = value; }
        }

        //Constructors
        public Account()
        {

        }

        //Overloaded constructor
        public Account(string _name, string _password, decimal _balance, bool _loggedIn)
        {
            Name = _name;
            Password = _password;
            Balance = _balance;
            LoggedIn = _loggedIn;
        }
            






    }
}
