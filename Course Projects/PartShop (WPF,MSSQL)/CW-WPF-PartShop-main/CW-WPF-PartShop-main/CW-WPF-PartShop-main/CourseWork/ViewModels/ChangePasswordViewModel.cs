using CourseWork.Commands;
using CourseWork.Properties;
using CourseWork.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToastNotifications.Messages;

namespace CourseWork.ViewModels
{
    public class ChangePasswordViewModel : ViewModelBase
    {
        public string newPassword { get; set; }
        public string repeatPassword { get; set; }
        public int code;
        public int codeFromView { get; set; }

        public ChangePasswordViewModel()
        {

        }
        private Command generteCode;
        public ICommand GenerateCode
        {
            get
            {
                return generteCode ??
                  (generteCode = new Command(obj =>
                  {
                      try
                      {
                          Random random = new Random();
                          code = random.Next(99999);
                         
                          EmailSenderService.SendCodeRefactor(Settings.Default.UserMail, code, "Код для смены пароля", "Никому не сообщайте данный пароль!\nКод для смены пароля: ").GetAwaiter();
                      }
                      catch(Exception e)
                      {
                          MessageBox.Show(e.Message);
                      }
                  }));
            }
        }
        private Command confirmChange;
        public ICommand ConfirmChange
        {
            get
            {
                return confirmChange ??
                  (confirmChange = new Command(obj =>
                  {
                      try
                      {
                          if (newPassword == repeatPassword & code == codeFromView)
                          {
                              App.db.Users.Where(x => x.Id == Settings.Default.UserId).FirstOrDefault().Password = SecurePassService.Hash(newPassword);
                              App.db.SaveChanges();
                              App.NotifyWindow(Application.Current.Windows[0]).ShowSuccess("Пароль был успешно изменен");
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
    }
}
