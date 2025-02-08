using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Models
{
    public class CourseTableExtended
    {
        public int Id { get; set; }
        public int idDiscipline { get; set; }
        public int idStudent { get; set; }
        public string Name { get; set; }
        public string Lector { get; set; }
        public string Surname { get; set; }
    }
}
