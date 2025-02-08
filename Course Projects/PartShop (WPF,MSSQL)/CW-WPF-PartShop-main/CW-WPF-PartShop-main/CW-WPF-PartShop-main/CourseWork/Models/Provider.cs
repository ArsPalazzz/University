using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    public class Provider
    {

        private int providerId;

        [Key]
        [Required(ErrorMessage = "Идентификатор обязателен")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Идентификатор должен содержать только цифры")]

        public int ProviderId
        {
            get { return providerId; }
            set
            {
                // Allow setting the Id only if it's not already set
                if (providerId == 0)
                {
                    providerId = value;
                }
            }
        }

        [Required(ErrorMessage = "Поле 'Name' не может быть пустым.")]
        [RegularExpression("^[a-zA-Z]{6,}$", ErrorMessage = "Поле 'Name' должно содержать только латинские буквы и быть длиной не менее 6 символов.")]
        public string Name { get; set; }
        [RegularExpression(@"^([a-zA-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Неверный формат email")]
        public string Email { get; set; }

    }
}
