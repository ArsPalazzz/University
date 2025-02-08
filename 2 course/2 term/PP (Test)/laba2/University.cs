using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class University : Organization, IStaff
    {
        protected List<Faculty> faculties= new List<Faculty>();

        public University() { }
        public University(University un)
        {
          faculties = un.faculties;
        }

        public University(string name, string shortname, string address)
        {
            ShortName = name;
            ShortName= shortname;
            Address = address;
        }

        public int addFaculty(Faculty faculty)
        {
            try
            {
                faculties.Add(faculty);
                return 1;
            }
            catch
            {
                return -1;
            }
        }

        public bool delFaculty(int id)
        {
            try
            {
                faculties.RemoveAt(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updFaculty(Faculty faculty, int id)
        {
            try
            {
                faculties[id - 1] = faculty;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool verFaculty(int id)
        {
            try
            {
                faculties.Contains(faculties[id - 1]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Университет: {Name} {Address}");
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
            return $"Университет: {Name} {Address}";
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
