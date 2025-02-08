using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }


        [Required(ErrorMessage = "Поле 'OrderDate' обязательно для заполнения.")]
        [DataType(DataType.DateTime, ErrorMessage = "Некорректный формат даты.")]
        public DateTime OrderDate { get; set; }

        [Browsable(false)]
        public List<OrderedParts> Parts { get; set; }

        [Required(ErrorMessage = "Поле 'OrderState' обязательно для заполнения.")]
        [RegularExpression("^(Accepted|Canceled|Waiting for confirmation)$", ErrorMessage = "Недопустимое значение для 'OrderState'.")]
        public string OrderState { get; set; }
        public int UserId { get; set; }

        [Browsable(false)]
        public User User { get; set; }
        public int DeliveryId { get; set; }

        [Browsable(false)]
        public Delivery Delivery { get; set; }
        //--ToDo: Добавить класс Delivery и создать навигационное свойство
    }
}
