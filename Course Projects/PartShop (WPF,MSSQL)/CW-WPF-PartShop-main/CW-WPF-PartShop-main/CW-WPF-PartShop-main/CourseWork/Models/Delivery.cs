using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }

        [Required(ErrorMessage = "Поле 'Description' обязательно для заполнения.")]
        [MinLength(6, ErrorMessage = "Поле 'Description' должно содержать минимум 6 символов.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Поле 'Description' должно содержать только латинские буквы.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле 'Price' обязательно для заполнения.")]
        [Range(0, 200, ErrorMessage = "Поле 'Price' должно быть в диапазоне от 0 до 200.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Поле 'Name' обязательно для заполнения.")]
        [MinLength(6, ErrorMessage = "Поле 'Name' должно содержать минимум 6 символов.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Поле 'Name' должно содержать только латинские буквы.")]
        public string Name { get; set; }

    }
}
