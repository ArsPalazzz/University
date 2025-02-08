using CourseWork.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    public class Part : ViewModelBase
    {
        [Key]
        public int PartId { get; set; }
        [Required(ErrorMessage = "Поле 'Name' обязательно для заполнения.")]
        [RegularExpression(@"^[a-zA-Z]{6,}$", ErrorMessage = "Поле 'Name' должно содержать минимум 6 латинских букв.")]
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = "Значение поля 'Quantity' должно быть в диапазоне от 1 до 100.")]
        public int Quantity { get; set; }
        public int ProviderId { get; set; }

        [Range(1, 4000, ErrorMessage = "Значение поля 'Price' должно быть в диапазоне от 1 до 4000.")]
        public double Price { get; set; }


        [Required(ErrorMessage = "Поле 'Description' обязательно для заполнения.")]
        [RegularExpression("^[a-zA-Z]{6,}$", ErrorMessage = "Поле 'Description' должно содержать минимум 6 латинских букв.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле 'FullDescription' обязательно для заполнения.")]
        [RegularExpression("^[a-zA-Z]{12,}$", ErrorMessage = "Поле 'FullDescription' должно содержать минимум 12 латинских букв.")]
        public string FullDescription { get; set; }


        [RegularExpression(@"^[a-zA-Z]:\\[^*|<>?""/:\\]*$", ErrorMessage = "Некорректный путь к файлу.")]
        public string ImageLink { get; set; }
        public int MarkId { get; set; }

        [Browsable(false)]
        public Mark Mark { get; set; }
        public int CategoryId { get; set; }

        [Browsable(false)]
        public Category Category { get; set; }

        [Browsable(false)]
        public Provider Provider { get; set; }
        [NotMapped]

        [Browsable(false)]
        public int Amount {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }
        [NotMapped]
        private int amount;
    }
}
