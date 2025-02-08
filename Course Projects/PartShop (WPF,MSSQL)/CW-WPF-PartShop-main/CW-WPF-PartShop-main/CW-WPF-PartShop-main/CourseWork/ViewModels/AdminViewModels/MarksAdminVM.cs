using CourseWork.Commands;
using CourseWork.Models;
using CourseWork.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToastNotifications.Messages;

namespace CourseWork.ViewModels.AdminViewModels
{
    public class MarksAdminVM : ViewModelBase
    {
        public ObservableCollection<Mark> Marks { get; set; }
        public ObservableCollection<Mark> deletedMarks { get; set; }
        public MarksAdminVM()
        {
            Marks = new ObservableCollection<Mark>(App.db.Marks);
            deletedMarks = new ObservableCollection<Mark>();
        }
        public string NewMark { get; set; }
        private Mark selectedMark;
        public Mark SelectedMark
        {
            get { return selectedMark; }
            set
            {
                selectedMark = value;
                OnPropertyChanged("SelectedMark");
            }
        }
        private Command deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new Command(obj =>
                  {
                      try
                      {
                          if (SelectedMark != null)
                          {
                              Mark mark = new Mark();
                              mark = selectedMark;
                              Marks.Remove(mark);
                              deletedMarks.Add(mark);
                              App.NotifyWindow(Application.Current.Windows[0]).ShowWarning("Марка авто была удалена");
                          }
                      }
                      catch(Exception e)
                      {
                          MessageBox.Show(e.Message);
                      }
                  }));
            }
        }
        private Command saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new Command(obj =>
                  {
                      try
                      {
                          // Список id записей в базе данных
                          var dbIds = App.db.Marks.Select(mark => mark.MarkId).ToList();

                          ////////////////////////////////////////////чтобы не сохранять полностью идентичные строки
                         

                          // Марки в базе данных
                          var dbMarks = App.db.Marks.ToList();

                          // Проверка наличия идентичных записей в базе данных
                          foreach (Mark newMark in Marks)
                          {
                              var matchingDbMark = dbMarks.FirstOrDefault(existingMark =>
                                  existingMark.MarkId != newMark.MarkId && // Исключаем сравнение с собой
                                  existingMark.MarkName.Equals(newMark.MarkName, StringComparison.OrdinalIgnoreCase) // Игнорируем регистр
                              );

                              if (matchingDbMark != null)
                              {
                                  App.NotifyWindow(Application.Current.Windows[0]).ShowError($"Марка с именем '{newMark.MarkName}' уже существует в базе данных");
                                  return;
                              }
                          }


                          /////////////////////////////////////////////////


                          // Идентификаторы записей в DataGrid
                          var gridIds = Marks.Select(mark => mark.MarkId).ToList();


                          // Проверка на наличие дубликатов ID в новых записях
                          if (gridIds.GroupBy(x => x).Any(g => g.Count() > 1))
                          {
                              App.NotifyWindow(Application.Current.Windows[0]).ShowError("Новые записи содержат дубликаты ID");
                              return;
                          }


                          // Идентификаторы, которые есть в DataGrid, но нет в базе данных
                          var newIds = gridIds.Except(dbIds).ToList();



                          // Новые записи, которые нужно добавить в базу данных
                          var newMarks = Marks.Where(mark => newIds.Contains(mark.MarkId)).ToList();



                          // Простая валидация перед сохранением
                          foreach (Mark newMark in newMarks)
                          {
                              if (
                                  string.IsNullOrWhiteSpace(newMark.MarkName) 
                                 
                                  )
                              {
                                  App.NotifyWindow(Application.Current.Windows[0]).ShowError("Неверные данные марки");
                                  return;
                              }


                              
                          }




                          // Обновление существующих марок
                          foreach (Mark existingMark in App.db.Marks)
                          {
                              var updatedMark = Marks.FirstOrDefault(mark => mark.MarkId == existingMark.MarkId);
                              if (updatedMark != null)
                              {
                                  // Ensure the Id remains unchanged
                                  if (existingMark.MarkId != updatedMark.MarkId)
                                  {
                                      App.NotifyWindow(Application.Current.Windows[0]).ShowWarning("Изменение ID невозможно");
                                      return;
                                  }


                                  // Проверка наличия идентичных записей в базе данных
                                  var matchingDbMark = dbMarks.FirstOrDefault(dbMark =>
                                      dbMark.MarkId != existingMark.MarkId && // Исключаем сравнение с собой
                                      dbMark.MarkName.Equals(updatedMark.MarkName, StringComparison.OrdinalIgnoreCase) // Игнорируем регистр
                                  );

                                  if (matchingDbMark != null)
                                  {
                                      App.NotifyWindow(Application.Current.Windows[0]).ShowError($"Марка с именем '{updatedMark.MarkName}' уже существует в базе данных");
                                      return;
                                  }


                                  existingMark.MarkName = updatedMark.MarkName;
                                      
                                   
                              }
                          }


                          // Добавление новых пользователей в базу данных
                          App.db.Marks.AddRange(newMarks);

                          // Удаление пользователей
                          foreach (Mark i in deletedMarks)
                          {
                              App.db.Marks.Remove(i);
                          }

                          App.db.SaveChanges();
                          deletedMarks.Clear();

                          App.NotifyWindow(Application.Current.Windows[0]).ShowSuccess("Данные были сохранены");



                      }
                      catch (Exception e)
                      {
                          MessageBox.Show(e.Message);
                      }
                  }));
            }
        }
        private Command addCommand;
        public ICommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new Command(obj =>
                  {
                      try
                      {
                          if(NewMark == null)
                          {
                              throw new Exception("Для добавления марки должно быть введено ее название");
                          }
                          Mark mark = new Mark();
                          mark.MarkName = NewMark;
                          App.db.Marks.Add(mark);
                          App.db.SaveChanges();
                          App.NotifyWindow(Application.Current.Windows[0]).ShowSuccess("Марка авто была успешно добавлена");
                      }
                      catch(Exception e)
                      {
                          App.NotifyWindow(Application.Current.Windows[0]).ShowError(e.Message);
                      }
                  }));
            }
        }
    }
}
