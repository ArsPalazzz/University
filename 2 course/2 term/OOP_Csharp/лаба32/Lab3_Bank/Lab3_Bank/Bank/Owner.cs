using System;

namespace Bank
{
    public class Owner
    {
        public Account Account { get; set; }
        public HistoryOperations HistoryOperations { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string PassportData { get; set; }
        public bool SmsConnect { get; set; }
        public bool NetBankingConnect { get; set; }
        public string SmsInfo  { get; set; }
        public string NetBankInfo { get; set; }

        public Owner()
        {
        }

        public Owner(Account _account, string _fullName, DateTime _birthday, string _passportDate, bool _smsConnect, bool _netBankingConnect)
        {
            Account = _account;
            this.FullName = _fullName;
            Birthday = _birthday;
            PassportData = _passportDate;
            SmsConnect = _smsConnect;
            NetBankingConnect = _netBankingConnect;
            SmsInfo = SmsConnect ? "SMS-оповещения подключены" : "SMS-оповещения не подключены";
            NetBankInfo = NetBankingConnect ? "Интернет банкинг подключен" : "Интернет банкинг не подключен";
        }

        virtual public string AdditionalServices()
        {
            string addServ = $"Осуществлена подписка на...\n";
            return addServ;
        }

        public string ShowOwnerInfo()
        {
            string ownerInfo = $"Номер счёта: {Account.Number} \n" +
                $"ФИО: {FullName}\n" +
                $"Дата рождения: {Birthday} \n" +
                $"Дата открытия счёта: {Account.OpeningDate} \n" +
                $"Подписка на дополнительные услуги: \n{SmsInfo} \n{NetBankInfo} \n" +
                $"Баланс: {Account.Balance} \n" +
                $"Тип вклада: {Account.ContributionType}\n\n";
            return ownerInfo;
        }
    }
}
