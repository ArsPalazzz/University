using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    public class User
    {
        private int id;

        [Key]
        [Required(ErrorMessage = "Идентификатор обязателен")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Идентификатор должен содержать только цифры")]
        public int Id
        {
            get { return id; }
            set
            {
                // Allow setting the Id only if it's not already set
                if (id == 0)
                {
                    id = value;
                }
            }
        }






        [Required(ErrorMessage = "Имя пользователя обязательно")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Имя должно быть не менее 5 и не более 20 символов")]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Логин должен состоять только из английских символов и цифр")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пароль обязателен")]
        [RegularExpression(@"^(?=.*\d).{5,}$", ErrorMessage = "Пароль должен содержать минимум 1 цифру и быть не короче 5 символов")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Поле Is_admin обязательно для заполнения")]
        public bool? Is_admin { get; set; }
  
        [RegularExpression(@"^[A-Z]{1}[a-z]{1,}$", ErrorMessage = "Имя должно начинаться с большой буквы и написано латиницей, минимум 2 символа")]
        public string FirstName { get; set; }
        [RegularExpression(@"^[A-Z]{1}[a-z]{4,}$", ErrorMessage = "Фамилия должна начинаться с большой буквы и написана латиницей, минимум 5 символов")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Электронная почта обязательна")]
        [RegularExpression(@"^([a-zA-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Неверный формат email")]
        public string Email { get; set; }

        public User()
        {
        }
        public User(int id)
        {
            Id = id;
        }


    }
}
