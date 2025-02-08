using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    abstract class OwnerDecorator : Owner
    {
        protected Owner owner;

        public OwnerDecorator(Owner _owner, Account _account, string _fullName, DateTime _birthday, string _passportDate, bool _smsConnect, bool _netBankingConnect) : base(_account, _fullName, _birthday, _passportDate, _smsConnect, _netBankingConnect)
        {
            owner = _owner;
        }
    }
    class SMSServOwner : OwnerDecorator
    {
        public SMSServOwner(Owner _owner) : base(_owner, _owner.Account, _owner.FullName, _owner.Birthday, _owner.PassportData, _owner.SmsConnect, _owner.NetBankingConnect)
        {

        }
        public override string AdditionalServices()
        {
            var str = owner.AdditionalServices();
            return str + $"\t {owner.SmsInfo}";
        }
    }
    class NetServOwner : OwnerDecorator
    {
        public NetServOwner(Owner _owner) : base(_owner, _owner.Account, _owner.FullName, _owner.Birthday, _owner.PassportData, _owner.SmsConnect, _owner.NetBankingConnect)
        {

        }
        public override string AdditionalServices()
        {
            var str = owner.AdditionalServices();
            return str + $"\t {owner.NetBankInfo}";
        }
    }
}
