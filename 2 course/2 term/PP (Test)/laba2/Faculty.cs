using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Faculty : Organization, IStaff
    {
        protected List<Department> departments = new List<Department>();

        public Faculty() { }
        public Faculty(Faculty faculty)
        {
            departments = faculty.departments;
        }

        public Faculty(string name, string shortname, string adress)
        {
            Name= name;
            ShortName= shortname;
            Address= adress;
        }

        public int adddepartment(Department department)
        {
            try
            {
                departments.Add(department);
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
                departments.RemoveAt(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updFaculty(Department department, int id)
        {
            try
            {
                departments[id - 1] = department;
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
                departments.Contains(departments[id - 1]);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Факультет: {Name} {Address}");
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
            return $"Факультет: {Name} {Address}";
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
