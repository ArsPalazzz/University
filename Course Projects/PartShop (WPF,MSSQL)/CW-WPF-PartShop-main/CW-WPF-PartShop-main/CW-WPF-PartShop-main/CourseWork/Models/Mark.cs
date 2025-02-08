using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    public class Mark
    {
        [Key]
        public int MarkId { get; set; }

        [Required(ErrorMessage = "Поле 'MarkName' обязательно для заполнения.")]
        [MinLength(6, ErrorMessage = "Поле 'MarkName' должно содержать минимум 6 символов.")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Поле 'MarkName' должно содержать только латинские буквы.")]
        public string MarkName { get; set; }

        [Browsable(false)]
        public List<Part> Parts { get; set; } 
    }
}
