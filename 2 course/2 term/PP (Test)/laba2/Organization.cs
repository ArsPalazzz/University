using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Organization : IStaff
    {
        public int Id { get; private set; }
        public string Name { get; protected set; }
        public string ShortName { get; protected set; }
        public string Address { get; protected set; }
        public DateTime TimeStamp { get; protected set; }

        public Organization() { }

        public Organization(string name, string shortname,string address)
        {
            Name = name;
            ShortName = shortname;
            Address = address;
        }

        public Organization(Organization org)
        {
            Id = org.Id;
        }

        public virtual void PrintInfo()
        {
            System.Console.WriteLine($"Организация: {Name} {Address}");
        }

        public List<JobVacancy> GetJobVacancies()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public List<JobTitle> GetJobTitles()
        {
            throw new NotImplementedException();
        }

        public int addJobTitle(JobTitle jobTitle)
        {
            throw new NotImplementedException();
        }

        public string printJobVacancies()
        {
            return $"Организация: {Name} {Address}";
        }

        public bool delJobTitle(int id)
        {
            throw new NotImplementedException();
        }

        public void openJobVacancy(JobVacancy jobVacancy)
        {
            throw new NotImplementedException();
        }

        public bool closeJobVacancy(int id)
        {
            throw new NotImplementedException();
        }

        public Employee recruit(JobVacancy jobVacancy, Person person)
        {
            throw new NotImplementedException();
        }

        public bool dismiss(int id, Reason reason)
        {
            throw new NotImplementedException();
        }
    }
}
