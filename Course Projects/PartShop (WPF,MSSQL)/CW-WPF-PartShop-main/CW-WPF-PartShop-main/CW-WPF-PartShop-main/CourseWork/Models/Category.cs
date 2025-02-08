using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Поле 'Name' обязательно для заполнения.")]
        [RegularExpression(@"^[a-zA-Z]{6,}$", ErrorMessage = "Поле 'Name' должно содержать минимум 6 латинских букв.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле 'Description' обязательно для заполнения.")]
        [MinLength(6, ErrorMessage = "Поле 'Description' должно содержать минимум 6 символов.")]
        public string Description { get; set; }

        [Browsable(false)]
        public List<Part> Parts { get; set; }
    }
}
