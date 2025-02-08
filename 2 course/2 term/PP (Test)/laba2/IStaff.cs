using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public interface IStaff
    {
        List<JobVacancy> GetJobVacancies();
        List<Employee> GetEmployees();
        List<JobTitle> GetJobTitles();
        int addJobTitle(JobTitle jobTitle);
        string printJobVacancies();
        bool delJobTitle(int id);
        void openJobVacancy(JobVacancy jobVacancy);
        bool closeJobVacancy(int id);
        Employee recruit(JobVacancy jobVacancy, Person person);
        bool dismiss(int id, Reason reason);
    }
}
