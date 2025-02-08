using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Номер карты должен состоять из 16 цифр")]
        public string CardNumber { get; set; }

        public int UserId { get; set; }

        [Browsable(false)]
        public User User { get; set; }

        [Range(0, 4999, ErrorMessage = "Баланс не может быть отрицательным")]
        public double Balance { get; set; }
        [RegularExpression(@"^\d{3}$", ErrorMessage = "CVV код должен состоят из 3-ех цифр")]
        public int CvvCode { get; set; }

    }
}
