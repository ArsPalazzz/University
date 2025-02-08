using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace laba2
{
    [DataContract]
    public class Owner
    {
        [DataMember]
        public string secondName;
        [DataMember]
        public string name;
        [DataMember]
        public string surname;
        [DataMember]
        public DateTime bitrhday;
        [DataMember]
        public string passpord;

        public Owner(string userSecondName, string userName, string userSurname, DateTime userBitrhday, string userPasspord)
        {
            secondName = userSecondName;
            name = userName;
            surname = userSurname;
            bitrhday = userBitrhday;
            passpord = userPasspord;
        }
    }
}
