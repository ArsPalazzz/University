using CourseWork.Commands;
using CourseWork.Database;
using CourseWork.Models;
using CourseWork.Services;
using CourseWork.Views.AdminViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ToastNotifications.Messages;

namespace CourseWork.ViewModels.AdminViewModels
{
    public class UsersAdminVM : ViewModelBase
    {
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<User> deletedUsers { get; set; }



        private DataGrid _usersGrid;

        // Свойство, которое будет использоваться для доступа к usersGrid из UsersAdminVM
        public DataGrid UsersGrid
        {
            get { return _usersGrid; }
            set
            {
                if (_usersGrid != value)
                {
                    _usersGrid = value;
                    // Вызовите метод обновления фильтрации, если это необходимо
                    UpdateFilter();
                }
            }
        }

        // Метод обновления фильтрации
        private void UpdateFilter()
        {
            // Ваш код обновления фильтрации с использованием _usersGrid
        }

        public UsersAdminVM()
        {
            Users = new ObservableCollection<User>(App.db.Users);
            deletedUsers = new ObservableCollection<User>();
        }
        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChanged(nameof(SelectedUser));
                }
            }
        }


        private User _currentUser;

        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                if (_currentUser != value)
                {
                    _currentUser = value;
                    OnPropertyChanged(nameof(CurrentUser));
                }
            }
        }

        public Command deleteCommand;
        private Command saveCommand;
        private Command filterCommand;

        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new Command(obj =>
                  {
                      try
                      {
                          if (_selectedUser != null)
                          {
                              User user = new User();
                              user = _selectedUser;
                              Users.Remove(user);
                              deletedUsers.Add(user);
                              App.NotifyWindow(Application.Current.Windows[0]).ShowWarning("Пользователь был удален");
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
                              var dbIds = App.db.Users.Select(user => user.Id).ToList();

                          ////////////////////////////////////////////чтобы не сохранять полностью идентичные строки
                          

                          // Юзеры в базе данных
                          var dbUsers = App.db.Users.ToList();

                          // Проверка наличия идентичных записей в базе данных
                          foreach (User newUser in Users)
                          {
                              if (dbUsers.Any(existingUser =>
                                  existingUser.FirstName == newUser.FirstName &&
                                  existingUser.LastName == newUser.LastName &&
                                  existingUser.Login == newUser.Login &&
                                  existingUser.Password == SecurePassService.Hash(newUser.Password) &&
                                  existingUser.Email == newUser.Email))
                              {
                                  App.NotifyWindow(Application.Current.Windows[0]).ShowError("Нельзя добавить идентичную запись в базу данных");
                                  return;
                              }
                          }


                          /////////////////////////////////////////////////


                          // Идентификаторы записей в DataGrid
                          var gridIds = Users.Select(user => user.Id).ToList();


                          // Проверка на наличие дубликатов ID в новых записях
                          if (gridIds.GroupBy(x => x).Any(g => g.Count() > 1))
                          {
                              App.NotifyWindow(Application.Current.Windows[0]).ShowError("Новые записи содержат дубликаты ID");
                              return;
                          }

                          // Проверка наличия совпадений ID с существующими записями в базе данных
                          //var overlappingIds = gridIds.Intersect(dbIds).ToList();
                          //if (overlappingIds.Any())
                          //{
                          //    App.NotifyWindow(Application.Current.Windows[0]).ShowError($"Новые записи содержат существующие ID: {string.Join(", ", overlappingIds)}");
                          //    return;
                          //}

                          // Идентификаторы, которые есть в DataGrid, но нет в базе данных
                          var newIds = gridIds.Except(dbIds).ToList();



                              // Новые записи, которые нужно добавить в базу данных
                              var newUsers = Users.Where(user => newIds.Contains(user.Id)).ToList();


                          // Простая валидация перед сохранением
                          foreach (User newUser in newUsers)
                          {
                              if (string.IsNullOrWhiteSpace(newUser.Login) ||
                                  string.IsNullOrWhiteSpace(newUser.Password) ||
                                  string.IsNullOrWhiteSpace(newUser.FirstName) ||
                                  string.IsNullOrWhiteSpace(newUser.LastName) ||
                                  string.IsNullOrWhiteSpace(newUser.Email) ||
                                  !Regex.IsMatch(newUser.Login, @"^[A-Za-z0-9]+$") ||
                                  !Regex.IsMatch(newUser.Password, @"^[A-Za-z0-9]+$") ||
                                  !Regex.IsMatch(newUser.FirstName, @"^[A-Z]{1}[a-z]+$") ||
                                  !Regex.IsMatch(newUser.LastName, @"^[A-Z]{1}[a-z]+$") ||
                                  !Regex.IsMatch(newUser.Email, @"^([a-zA-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$"))
                              {
                                  App.NotifyWindow(Application.Current.Windows[0]).ShowError("Неверные данные пользователя");
                                  return;
                              }


                              // Flag to determine whether to hash the password
                              bool isNewUser = !dbIds.Contains(newUser.Id);

                              // Hash the password only for new users or if the password is changed
                              if (isNewUser || newUser.Password != App.db.Users.FirstOrDefault(u => u.Id == newUser.Id)?.Password)
                              {
                                  newUser.Password = SecurePassService.Hash(newUser.Password);
                              }
                          }


                          // Обновление существующих пользователей
                          foreach (User existingUser in App.db.Users)
                          {
                              var updatedUser = Users.FirstOrDefault(user => user.Id == existingUser.Id);
                              if (updatedUser != null)
                              {
                                  // Ensure the Id remains unchanged
                                  if (existingUser.Id != updatedUser.Id)
                                  {
                                      App.NotifyWindow(Application.Current.Windows[0]).ShowWarning("Изменение ID невозможно");
                                      return;
                                  }

                                  // Update other properties only if the password is changed
                                  if (existingUser.Password != updatedUser.Password)
                                  {
                                      existingUser.FirstName = updatedUser.FirstName;
                                      existingUser.LastName = updatedUser.LastName;
                                      existingUser.Login = updatedUser.Login;

                                      // Hash the password only if it is changed
                                      if (existingUser.Password != updatedUser.Password)
                                      {
                                          existingUser.Password = SecurePassService.Hash(updatedUser.Password);
                                      }

                                      existingUser.Email = updatedUser.Email;
                                      // Update other properties as needed
                                  }
                              }
                          }



                          // Удаление заказов, которые были удалены из DataGrid
                          foreach (User deletedUser in deletedUsers)
                          {
                              var userToDelete = App.db.Users.FirstOrDefault(user => user.Id == deletedUser.Id);
                              if (userToDelete != null)
                              {
                                  App.db.Users.Remove(userToDelete);
                              }
                          }

                          // Очистка коллекции удаленных заказов
                          deletedUsers.Clear();


                          // Добавление новых пользователей в базу данных
                          App.db.Users.AddRange(newUsers);

                          
                          App.db.SaveChanges();
                          App.NotifyWindow(Application.Current.Windows[0]).ShowWarning("Данные были сохранены");





                          // Добавление новых пользователей в базу данных
                          //foreach (User newUser in newUsers)
                          //        {
                          //            App.db.Users.Add(newUser);
                          //        }




                          //для удаления
                          //foreach (User i in deletedUsers)
                          //{
                          //    App.db.Users.Remove(i);
                          //}
                          //App.db.SaveChanges();
                          //deletedUsers.Clear();

                          //App.NotifyWindow(Application.Current.Windows[0]).ShowWarning("Данные были сохранены");


                      }

                      
                      catch(Exception e)
                      {
                          MessageBox.Show(e.Message);
                      }
                  }));
            }
        }

        public ICommand FilterUsersCommand
        {
            get
            {
                return filterCommand ??
                  (filterCommand = new Command(obj =>
                  {
                      try
                      {

                          FilterUsers newWind = new FilterUsers(Users);

                         


                      }


                      catch (Exception e)
                      {
                          MessageBox.Show(e.Message);
                      }
                  }));
            }
        }


        public void FilterUsers(string filterText)
        {
            // Применяем фильтр к коллекции Users
            var filteredUsers = App.db.Users.Where(user =>
                user.FirstName.Contains(filterText) ||
                user.LastName.Contains(filterText) ||
                user.Login.Contains(filterText) ||
                user.Email.Contains(filterText)).ToList();

            // Очищаем текущую коллекцию Users
            Users.Clear();

            // Добавляем отфильтрованных пользователей
            foreach (var user in filteredUsers)
            {
                Users.Add(user);
            }

            // Обновляем DataGrid
            if (UsersGrid != null)
            {
                UsersGrid.Items.Refresh();
            }
        }
    }
}
