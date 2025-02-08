using CourseWork.Commands;
using CourseWork.Models;
using CourseWork.Views.AdminViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToastNotifications.Messages;

namespace CourseWork.ViewModels.AdminViewModels
{
    public class PartsAdminVM : ViewModelBase
    {
        public ObservableCollection<Part> Parts { get; set; }
        public ObservableCollection<Part> deletedParts { get; set; }
        public PartsAdminVM()
        {
            Parts = new ObservableCollection<Part>(App.db.Parts);
            deletedParts = new ObservableCollection<Part>();
        }
        private Command saveCommand;
        private Part selectedPart;
        public Part SelectedPart
        {
            get { return selectedPart; }
            set
            {
                selectedPart = value;
                OnPropertyChanged("SelectedPart");
            }
        }







        private Command changeImagePathCommand;
        private Command searchImageCommand;

        public ICommand ChangeImagePathCommand
        {
            get
            {
                return changeImagePathCommand ??
                    (changeImagePathCommand = new Command(obj =>
                    {
                        try
                        {
                            if (selectedPart != null)
                            {
                                // Открываем диалоговое окно выбора файла
                                var openFileDialog = new Microsoft.Win32.OpenFileDialog();
                                openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif;*.bmp";
                                if (openFileDialog.ShowDialog() == true)
                                {
                                    // Обновляем свойство ImageLink
                                    selectedPart.ImageLink = openFileDialog.FileName;
                                    OnPropertyChanged(nameof(selectedPart));
                                }
                            }
                        }
                        catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                        {
                            foreach (var validationErrors in ex.EntityValidationErrors)
                            {
                                foreach (var validationError in validationErrors.ValidationErrors)
                                {
                                    MessageBox.Show($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                                }
                            }
                            // Обработка ошибок валидации
                            App.NotifyWindow(Application.Current.Windows[0]).ShowError("Ошибка валидации данных. Проверьте правильность заполнения полей.");
                        }
                        catch (Exception e)
                        {
                            // Обработка других исключений
                            MessageBox.Show(e.Message);
                        }
                    }));
            }
        }

        //public ICommand SearchImageCommand
        //{
        //    get
        //    {
        //        return searchImageCommand ??
        //            (searchImageCommand = new Command(obj =>
        //            {
        //                try
        //                {
        //                    if (selectedPart != null)
        //                    {
        //                        // Здесь может быть логика вызова внешнего сервиса для поиска изображения
        //                        // Пока просто присвоим какое-то тестовое значение
        //                        selectedPart.ImageLink = "https://example.com/test-image.jpg";
        //                        OnPropertyChanged(nameof(selectedPart));
        //                    }
        //                }
        //                catch (Exception e)
        //                {
        //                    MessageBox.Show($"Ошибка: {e.Message}");
        //                }
        //            }));
        //    }
        //}










        public Command deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new Command(obj =>
                  {
                      try
                      {
                          if (selectedPart != null)
                          {
                              Part part = new Part();
                              part = selectedPart;
                              Parts.Remove(part);
                              deletedParts.Add(part);
                              App.NotifyWindow(Application.Current.Windows[0]).ShowWarning("Товар был удален");
                          }
                      }
                      catch(Exception e)
                      {
                          MessageBox.Show(e.Message);
                      }
                  }
                ));
            }
        }



        //public ICommand SavePartsCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(SaveParts_Click);
        //    }
        //}

        //private void SaveParts_Click(object obj)
        //{
        //    // Ваша логика обработки события SaveParts_Click
        //    try
        //    {
        //        MessageBox.Show("SaveParts_Click");
        //        foreach (Part i in deletedParts)
        //        {
        //            App.db.Parts.Remove(i);
        //        }
        //        App.db.SaveChanges();
        //        deletedParts.Clear();
        //    }
        //    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
        //    {
        //        foreach (var validationErrors in ex.EntityValidationErrors)
        //        {
        //            foreach (var validationError in validationErrors.ValidationErrors)
        //            {
        //                MessageBox.Show($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
        //            }
        //        }
        //        // Обработка ошибок валидации
        //        App.NotifyWindow(Application.Current.Windows[0]).ShowError("Ошибка валидации данных. Проверьте правильность заполнения полей.");
        //    }
        //    catch (Exception e)
        //    {
        //        // Обработка других исключений
        //        MessageBox.Show(e.Message);
        //    }
        //}



       


        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new Command(obj =>
                  {
                      try
                      {
                         


                          foreach (Part i in deletedParts)
                          {
                              App.db.Parts.Remove(i);
                          }
                          App.db.SaveChanges();
                          deletedParts.Clear();
                      }
                      catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                      {
                          foreach (var validationErrors in ex.EntityValidationErrors)
                          {
                              foreach (var validationError in validationErrors.ValidationErrors)
                              {
                                  MessageBox.Show($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                              }
                          }
                          // Обработка ошибок валидации
                          App.NotifyWindow(Application.Current.Windows[0]).ShowError("Ошибка валидации данных. Проверьте правильность заполнения полей.");
                      }
                      catch (Exception e)
                      {
                          // Обработка других исключений
                          MessageBox.Show(e.Message);
                      }
                  }));
            }
        }
        private Command addPart;
        public ICommand AddPart
        {
            get
            {
                return addPart ??
                  (addPart = new Command(obj =>
                  {
                      AddPartWindow window = new AddPartWindow();
                      window.ShowDialog();
                  }));
            }
        }
    }
}
