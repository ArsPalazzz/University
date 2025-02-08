using CourseWork.Commands;
using CourseWork.Database;
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
using System.Windows.Controls;
using System.Windows.Input;
using ToastNotifications.Messages;

namespace CourseWork.ViewModels.AdminViewModels
{
    public class OrdersAdminVM : ViewModelBase
    {
        public ObservableCollection<Order> Orders { get; set; }
        public ObservableCollection<Order> deletedOrders { get; set; }

        private Order _selectedOrder;
        private Order _currentOrder;

        private DataGrid _ordersGrid;


        public DataGrid OrdersGrid
        {
            get { return _ordersGrid; }
            set
            {
                if (_ordersGrid != value)
                {
                    _ordersGrid = value;
                    // Вызовите метод обновления фильтрации, если это необходимо
                    //UpdateFilter();
                }
            }
        }

        public Order SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                if (_selectedOrder != value)
                {
                    _selectedOrder = value;
                    OnPropertyChanged(nameof(SelectedOrder));
                    //CurrentOrder = _selectedOrder;
                }
            }
        }


        public Order CurrentOrder
        {
            get { return _currentOrder; }
            set
            {
                if (_currentOrder != value)
                {
                    _currentOrder = value;
                    OnPropertyChanged(nameof(CurrentOrder));
                }
            }
        }


        public OrdersAdminVM()
        {
            Orders = new ObservableCollection<Order>(App.db.Orders);
            deletedOrders = new ObservableCollection<Order>();
        }
        private Command saveCommand;
        //private Order selectedOrder;
        //public Order SelectedOrder
        //{
        //    get { return selectedOrder; }
        //    set
        //    {
        //        selectedOrder = value;
        //        OnPropertyChanged("SelectedOrder");
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
                          if (_selectedOrder != null)
                          {
                              Order order = new Order();
                              order = _selectedOrder;
                              Orders.Remove(order);
                              deletedOrders.Add(order);
                              App.NotifyWindow(Application.Current.Windows[0]).ShowWarning("Заказ был удален");
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
                          var dbIds = App.db.Orders.Select(order => order.OrderId).ToList();

                          ////////////////////////////////////////////чтобы не сохранять полностью идентичные строки


                          // Юзеры в базе данных
                          var dbOrders = App.db.Orders.ToList();

                          //List<Order> dbOrders2;

                          //using (PartShopDbContext dbPartShopDbContext = new PartShopDbContext())
                          //{
                          //    dbOrders2 = dbPartShopDbContext.Orders.ToList();
                          //}

                          //foreach (Order newOrder in Orders)
                          //{
                          //    MessageBox.Show(newOrder.OrderState);
                          //}

                          // Проверка наличия идентичных записей в базе данных
                          // Проверка наличия идентичных записей в базе данных
                          //foreach (Order newOrder in Orders)
                          //{
                          //    if (dbOrders2.Any(existingOrder =>
                          //        existingOrder.OrderId == newOrder.OrderId &&
                          //        existingOrder.OrderDate == newOrder.OrderDate &&
                          //        existingOrder.OrderState == newOrder.OrderState &&
                          //        existingOrder.UserId == newOrder.UserId &&
                          //        existingOrder.DeliveryId == newOrder.DeliveryId))
                          //    {
                          //        App.NotifyWindow(Application.Current.Windows[0]).ShowError("Нельзя добавить идентичную запись в базу данных");
                          //        return;
                          //    }
                          //    else
                          //    {
                          //        MessageBox.Show("Все строки уникальны");
                          //    }
                          //}



                          /////////////////////////////////////////////////


                          // Идентификаторы записей в DataGrid
                          var gridIds = Orders.Select(order => order.OrderId).ToList();


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
                          var newOrders = Orders.Where(order => newIds.Contains(order.OrderId)).ToList();


                          // Простая валидация перед сохранением
                          foreach (Order newOrder in newOrders)
                          {
                              if (string.IsNullOrWhiteSpace(newOrder.OrderId.ToString()) ||
                                !DateTime.TryParse(newOrder.OrderDate.ToString(), out _) ||
                                string.IsNullOrWhiteSpace(newOrder.OrderState) ||
                                newOrder.UserId <= 0 || // Assuming UserId should be a positive integer
                                newOrder.DeliveryId <= 0 || // Assuming DeliveryId should be a positive integer
                                !Regex.IsMatch(newOrder.OrderState, @"^(Accepted|Canceled|Waiting for confirmation)$"))
                              {
                                  App.NotifyWindow(Application.Current.Windows[0]).ShowError("Неверные данные пользователя");
                                  return;
                              }


                              // Flag to determine whether to hash the password
                              //bool isNewUser = !dbIds.Contains(newUser.Id);

                              //// Hash the password only for new users or if the password is changed
                              //if (isNewUser || newUser.Password != App.db.Users.FirstOrDefault(u => u.Id == newUser.Id)?.Password)
                              //{
                              //    newUser.Password = SecurePassService.Hash(newUser.Password);
                              //}
                          }


                          // Обновление существующих записей
                          foreach (Order existingOrder in App.db.Orders)
                          {
                              var updatedOrder = Orders.FirstOrDefault(order => order.OrderId == existingOrder.OrderId);
                              if (updatedOrder != null)
                              {
                                  // Ensure the OrderId remains unchanged
                                  if (existingOrder.OrderId != updatedOrder.OrderId)
                                  {
                                      App.NotifyWindow(Application.Current.Windows[0]).ShowWarning("Изменение OrderId невозможно");
                                      return;
                                  }

                                  // Update other properties only if the password is changed
                                  if (existingOrder.OrderState != updatedOrder.OrderState)
                                  {
                                      existingOrder.OrderDate = updatedOrder.OrderDate;
                                      existingOrder.OrderState = updatedOrder.OrderState;
                                      existingOrder.UserId = updatedOrder.UserId;
                                      existingOrder.DeliveryId = updatedOrder.DeliveryId;

                                      // Update other properties as needed
                                  }
                              }
                          }

                          // Удаление заказов, которые были удалены из DataGrid
                          foreach (Order deletedOrder in deletedOrders)
                          {
                              var orderToDelete = App.db.Orders.FirstOrDefault(order => order.OrderId == deletedOrder.OrderId);
                              if (orderToDelete != null)
                              {
                                  App.db.Orders.Remove(orderToDelete);
                              }
                          }

                          // Очистка коллекции удаленных заказов
                          deletedOrders.Clear();




                          // Добавление новых пользователей в базу данных
                          App.db.Orders.AddRange(newOrders);


                          App.db.SaveChanges();
                          App.NotifyWindow(Application.Current.Windows[0]).ShowWarning("Данные были сохранены");

                      }
                      catch (Exception e)
                      {
                          MessageBox.Show(e.Message);
                      }
                  }));
            }
        }
    }
}
