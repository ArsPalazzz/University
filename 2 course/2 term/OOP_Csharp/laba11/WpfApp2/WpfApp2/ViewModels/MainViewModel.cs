using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DISCIPLINE> _discipline;
        private ObservableCollection<Student> _student;
        private ObservableCollection<CourseTable> _courses;
        private ICommand _addToStudentCommand;
        private ICommand _removeFromStudentCommand;
        private ICommand _removeFromDisciplineCommand; 
        private ICommand _RemoveStudentCommand;
        public ICommand AddDiscCommand { get; private set; }
        public ICommand AddStudentCommand { get; private set; }
        public List<CourseTableExtended> _CourseTableExtended;
        //public ICommand RemoveDiscCommand { get; private set; }

        public ObservableCollection<DISCIPLINE> Disciplines
        {
            get => _discipline;
            set
            {
                _discipline = value;
                OnPropertyChanged(nameof(Disciplines));
            }
        }
        
        public ObservableCollection<Student> Student
        {
            get => _student;
            set
            {
                _student = value;
                OnPropertyChanged(nameof(Student));
            }
        }

        public ObservableCollection<CourseTable> CourseTable
        {
            get => _courses;
            set
            {
                _courses = value;
                OnPropertyChanged(nameof(CourseTable));
            }
        }

        public ICommand AddToStudentCommand
        {
            get
            {
                if (_addToStudentCommand == null)
                {
                    _addToStudentCommand = new RelayCommand(
                        param =>
                        {
                            var tuple = param as Tuple<DISCIPLINE, Student>;
                            var discipline = tuple.Item1;
                            var student = tuple.Item2;

                            AddStudentToCourse(discipline, student);
                        });
                }

                return _addToStudentCommand;
            }
        }

        public ICommand RemoveFromStudentCommand
        {
            get
            {
                if (_removeFromStudentCommand == null)
                {
                    _removeFromStudentCommand = new RelayCommand(
                         param =>
                         {
                             RemoveStudentToCourse(param as CourseTable);
                         });
                }

                return _removeFromStudentCommand;
            }
        }


        public ICommand RemoveFromDisciplineCommand
        {
            get
            {
                if (_removeFromDisciplineCommand == null)
                {
                    _removeFromDisciplineCommand = new RelayCommand(
                        param => RemoveFromDiscipline(param as DISCIPLINE));
                }

                return _removeFromDisciplineCommand;
            }
        }
        public ICommand RemoveStudentCommand
        {
            get
            {
                if (_RemoveStudentCommand == null)
                {
                    _RemoveStudentCommand = new RelayCommand(
                        param => RemoveStudentClick(param as Student));
                }

                return _RemoveStudentCommand;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            using (var db = new CourseContext())
            {
                Disciplines = new ObservableCollection<DISCIPLINE>(db.DISCIPLINE.ToList());
                Student = new ObservableCollection<Student>(db.Student.ToList());
                CourseTable = new ObservableCollection<CourseTable>(db.CourseTable.ToList());
                //_CourseTableExtended = new List<CourseTableExtended>(db.CourseTable.ToList());
                //CourseTable = new ObservableCollection<CourseTable>();
            }

            AddDiscCommand = new RelayCommand(AddDisc_Click);
            AddStudentCommand = new RelayCommand(AddStudent_Click);
            //RemoveDiscCommand = new RelayCommand(RemoveDisc_Click);
        }


        private void AddDisc_Click(object parameter)
        {
            AddItem window = new AddItem(Disciplines);
            window.ShowDialog();
            using (var db = new CourseContext())
            {
                Disciplines = new ObservableCollection<DISCIPLINE>(db.DISCIPLINE.ToList());
            }

        }
        private void AddStudent_Click(object parameter)
        {
            AddStudent window = new AddStudent();
            window.ShowDialog();
            using (var db = new CourseContext())
            {
                Student = new ObservableCollection<Student>(db.Student.ToList());
            }

        }
        
        private void RemoveStudentClick(Student student)
        {
            if (student == null)
            {
                return;
            }
            
            
            using (var db = new CourseContext())
            {
                db.Student.Remove(student);
                db.SaveChanges();
                Student = new ObservableCollection<Student>(db.Student.ToList());
            }
            

        }
        private void RemoveFromDiscipline(DISCIPLINE product)
        {
            if (product == null)
            {
                return;
            }
            product.IsSelected = false;
            Disciplines.Remove(product);
            using (var db = new CourseContext())
            {
                db.DISCIPLINE.Remove(product);
                db.SaveChanges();
            }

        }
        public bool CanRemoveFromDiscipline(DISCIPLINE product)
        {
            return product != null && product.IsSelected;
        }

        public void AddStudentToCourse(DISCIPLINE discipline, Student student)
        {
            bool ishere = false;
            if (discipline == null || student == null)
            {
                MessageBox.Show("Выделите предмет и студента!");
            }
            else
            {
                //MessageBox.Show(discipline.Id.ToString() + " " + student.Id.ToString());
                if (discipline == null || student == null)
                {
                    return;
                }
                using (var db = new CourseContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        foreach (var item in CourseTable)
                        {
                            if (item.idDiscipline == discipline.Id && item.idStudent == student.Id)
                            {
                                ishere = true;
                            }
                        }

                        if (!ishere)
                        {
                            //CourseTable.Add(new CourseTable
                            //{
                            //    idDiscipline = discipline.Id,
                            //    idStudent = student.Id,
                            //    Name = discipline.Name,
                            //    Lector = discipline.Lector,
                            //    Surname = student.Surname
                            //});
                            db.CourseTable.Add(new CourseTable
                            {
                                idDiscipline = discipline.Id,
                                idStudent = student.Id,
                                Name = discipline.Name,
                                Lector = discipline.Lector,
                                Surname = student.Surname
                            });
                            db.SaveChanges();
                            transaction.Commit();
                            CourseTable = new ObservableCollection<CourseTable>(db.CourseTable.ToList());
                        }
                        else
                        {
                            MessageBox.Show("Этот студент уже записан на эту дисциплину!");
                        }
                    }
                }
            }
                
           
        }


        public void RemoveStudentToCourse(CourseTable courseElem)
        {
            bool ishere = false;
            if (courseElem == null)
            {
                MessageBox.Show("Пожалуйста, выделите запись на курс!");
            }
            else
            {

                using (var db = new CourseContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        foreach (var item in CourseTable)
                        {
                            if (item.Id == courseElem.Id)
                            {
                                ishere = true;
                            }
                        }

                        if (ishere)
                        {
                            CourseTable.Remove(courseElem);
                            db.CourseTable.Remove(courseElem);
                        }
                        else
                        {
                            MessageBox.Show("Такой записи на предмет такого студента нету!");
                        }
                        db.SaveChanges();
                        transaction.Commit();
                    }
                }
            }

        }
            //public void RemoveStudentToCourse(DISCIPLINE discipline, Student student)
            //{
            //    if (discipline == null || student == null)
            //    {
            //        MessageBox.Show("Таких предметов или студентов нету!");
            //    }
            //    else
            //    {
            //        MessageBox.Show(discipline.Id.ToString() + " " + student.Id.ToString());
            //        if (discipline == null || student == null)
            //        {
            //            return;
            //        }
            //        using (var db = new CourseContext())
            //        {
            //            using (var transaction = db.Database.BeginTransaction())
            //            {
            //                foreach (var item in CourseTable)
            //                {
            //                    if (item.idDiscipline == discipline.Id && item.idStudent == student.Id)
            //                    {
            //                        CourseTable.Remove(item);
            //                        db.CourseTable.Remove(item);
            //                        if (CourseTable.Count == 0)
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //                db.SaveChanges();
            //                transaction.Commit();
            //            }
            //        }
            //    }


            //}


            //public void AddToStudent(DISCIPLINE product)
            //{
            //    if (product == null)
            //    {
            //        return;
            //    }
            //    product.IsSelected = true;
            //    Student.Add(product);
            //    using (var db = new CourseContext())
            //    {
            //        using (var transaction = db.Database.BeginTransaction())
            //        {
            //            DISCIPLINE student = new DISCIPLINE
            //            {
            //                Name = product.Name,
            //                QuantityHours = product.QuantityHours,
            //                Lector = product.Lector,
            //                Quantity = product.Quantity,
            //            };
            //            db.Student.Add(student);
            //            db.SaveChanges();
            //        }
            //    }
            //    //OnPropertyChanged(nameof(TotalDisciplines));
            //}

            //public void RemoveStudentToCourse(DISCIPLINE discipline, Student student)
            //{
            //    if (discipline == null || student == null)
            //    {
            //        MessageBox.Show("Таких предметов или студентов нету!");
            //    }
            //    else
            //    {
            //        MessageBox.Show(discipline.Id.ToString() + " " + student.Id.ToString());
            //        if (discipline == null || student == null)
            //        {
            //            return;
            //        }
            //        using (var db = new CourseContext())
            //        {
            //            using (var transaction = db.Database.BeginTransaction())
            //            {
            //                foreach (var item in CourseTable)
            //                {
            //                    if (item.idDiscipline == discipline.Id && item.idStudent == student.Id)
            //                    {
            //                        CourseTable.Remove(item);
            //                        db.CourseTable.Remove(item);
            //                        if (CourseTable.Count == 0)
            //                        {
            //                            break;
            //                        }
            //                    }
            //                }
            //                db.SaveChanges();
            //                transaction.Commit();
            //            }
            //        }
            //    }


            //}


            //public void AddToStudent(DISCIPLINE product)
            //{
            //    if (product == null)
            //    {
            //        return;
            //    }
            //    product.IsSelected = true;
            //    Student.Add(product);
            //    using (var db = new CourseContext())
            //    {
            //        using (var transaction = db.Database.BeginTransaction())
            //        {
            //            DISCIPLINE student = new DISCIPLINE
            //            {
            //                Name = product.Name,
            //                QuantityHours = product.QuantityHours,
            //                Lector = product.Lector,
            //                Quantity = product.Quantity,
            //            };
            //            db.Student.Add(student);
            //            db.SaveChanges();
            //        }
            //    }
            //    //OnPropertyChanged(nameof(TotalDisciplines));
            //}

            public bool CanAddToStudent(DISCIPLINE product)
        {
            return product != null && !product.IsSelected;
        }

        //public void RemoveFromStudent(DISCIPLINE product)
        //{
        //    if (product == null)
        //    {
        //        return;
        //    }
        //    product.IsSelected = false;
        //    Student.Remove(product);
        //    using (var db = new CourseContext())
        //    {
        //        db.Student.Remove(product);
        //        db.SaveChanges();
        //    }
        //    //OnPropertyChanged(nameof(TotalDisciplines));
        //}

        public bool CanRemoveFromStudent(DISCIPLINE product)
        {
            return product != null && product.IsSelected;
        }

        //public decimal GetTotalDisciplines()
        //{
        //    return Student.Count();
        //}
    }
}
