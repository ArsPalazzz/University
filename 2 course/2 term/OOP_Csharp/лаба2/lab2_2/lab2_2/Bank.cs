using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace laba2
{
    [DataContract]
    public class Bank
    {
        [DataMember]
        public int Number;
        [DataMember]
        public int Balance;
        [DataMember]
        public DateTime OpeningDate;
        [DataMember]
        public string Owner;

        [DataMember]
        public string DepostiteType;
        [DataMember]
        public string SMS;
        [DataMember]
        public string Internet;
        
        public Owner UserOwner;

        public Bank(int userNumber, int userBalance, DateTime userOpeningDate, string userOwner, 
            string userDepositeType, string userSMS, string userInternet, Owner owner)
        {
            Number = userNumber;
            Balance = userBalance;
            OpeningDate = userOpeningDate;
            Owner = userOwner;
            DepostiteType = userDepositeType;
            SMS = userSMS;
            Internet = userInternet;
            UserOwner = owner;
        }
    }
}
