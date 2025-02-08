using System;

namespace Bank
{
    public class Account
    {
        public string Number { get; set; }
        public string OpeningDate { get; set; }       
        public int Balance { get; set; }
        public string ContributionType { get; set; }


        public Account()
        {
        }

        public Account(string _number, DateTime _openingDate, int _balance, string _contributionType)
        {
            Number = _number;
            OpeningDate = _openingDate.ToString();
            Balance = _balance;
            ContributionType = _contributionType;
        }
    }
}
