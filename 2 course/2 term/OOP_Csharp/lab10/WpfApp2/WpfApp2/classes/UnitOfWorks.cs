using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.classes;

namespace WpfApp2.classes
{
    public class UnitOfWork : IDisposable   //Паттерн Unit of Work позволяет упростить работу с различными репозиториями и дает уверенность, что все репозитории будут использовать один и тот же контекст данных.
    {
        private ApplicationContext db = new ApplicationContext();
        private AddressRepository addressRepository;
        private PassportRepository passportRepository;
        private PersonRepository personRepository;

        public AddressRepository Addresses
        {
            get
            {
                if (addressRepository == null)
                    addressRepository = new AddressRepository(db);
                return addressRepository;
            }
        }

        public PassportRepository Passports
        {
            get
            {
                if (passportRepository == null)
                    passportRepository = new PassportRepository(db);
                return passportRepository;
            }
        }
        public PersonRepository Persons
        {
            get
            {
                if (personRepository == null)
                    personRepository = new PersonRepository(db);
                return personRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing) // освобождение памяти
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // позволяет сборщику мусора знать, что финализация (Finalize) объекта уже была выполнена, и не нужно вызывать ее снова.
        }
    }
}
