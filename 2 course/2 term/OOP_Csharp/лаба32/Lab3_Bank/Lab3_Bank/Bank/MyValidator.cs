using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Bank
{
    class MyValidator
    {
        [Required(ErrorMessage = "Заполните поле \"Номер счёта\"")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Заполните поле \"ФИО\"")]
        public string FullName { get; set; }
                
        [Required(ErrorMessage = "Заполните поле \"Номер паспорта\"")]
        [NationalityValidate]
         public string PassportData { get; set; }

        [Required(ErrorMessage = "Должен быть выбран тип вклада")]
        public string ContributionType { get; set; }

        public MyValidator(string fullname, string passport, string number, string contrtype)
        {
            FullName = fullname;
            PassportData = passport;
            Number = number;
            ContributionType = contrtype;
        }

        public class NationalityValidateAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                var exp = new Regex(@"\w{2}\d{7}"); 
                if (value is string PassportData)
                {
                    try
                    {
                        if (exp.IsMatch(PassportData))
                            return true;
                        else
                            ErrorMessage = "Наш банк работает только с гражданами РБ. Пример, МР1234567";
                    }
                    catch (Exception)
                    {

                        ErrorMessage = "Наш банк работает только с гражданами РБ";
                    }
                }
                return false;
            }
        }
    }
}
