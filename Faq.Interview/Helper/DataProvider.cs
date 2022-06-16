using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAQ.Interview.Helper
{
    public class DataProvider
    {
        public List<AutocompleteListItem> Autocomplete()
        {
            return new List<AutocompleteListItem>
            {
                new AutocompleteListItem {Id = 131, Name = "Auckland"},
                new AutocompleteListItem {Id = 133, Name = "Canterbury"},
                new AutocompleteListItem {Id = 134, Name = "Gisborne"},
                new AutocompleteListItem {Id = 135, Name = "Hawkes Bay"},
                new AutocompleteListItem {Id = 136, Name = "Hawke's Bay"},
                new AutocompleteListItem {Id = 137, Name = "Manawatu-Wanganui"},
                new AutocompleteListItem {Id = 138, Name = "Marlborough"},
                new AutocompleteListItem {Id = 139, Name = "Nelson"},
                new AutocompleteListItem {Id = 140, Name = "Northland"},
                new AutocompleteListItem {Id = 141, Name = "Otago"},
                new AutocompleteListItem {Id = 142, Name = "Southland"},
                new AutocompleteListItem {Id = 143, Name = "Taranaki"},
                new AutocompleteListItem {Id = 144, Name = "Tasman"},
                new AutocompleteListItem {Id = 145, Name = "Waikato"},
                new AutocompleteListItem {Id = 146, Name = "Wellington"},
                new AutocompleteListItem {Id = 147, Name = "West Coast"},
                new AutocompleteListItem {Id = 148, Name = "Whangarei"},
                new AutocompleteListItem {Id = 2, Name = "New South Wales"},
                new AutocompleteListItem {Id = 3, Name = "Australian Capital Territory"},
                new AutocompleteListItem {Id = 5, Name = "South Australia"},
                new AutocompleteListItem {Id = 4, Name = "Victoria"},
                new AutocompleteListItem {Id = 6, Name = "Queensland"},
                new AutocompleteListItem {Id = 7, Name = "Western Australia"},
                new AutocompleteListItem {Id = 8, Name = "Northern Territory"},
                new AutocompleteListItem {Id = 9, Name = "Tasmania"}
            };
        }


        public List<Employee> Report(int? month)
        {
            var employees = new List<Employee>
            {
                new Employee {Id = 1, Name = "Jeni"},
                new Employee {Id = 2, Name = "Adam"},
                new Employee {Id = 3, Name = "Carlos"},
                new Employee {Id = 4, Name = "Smith"},
                new Employee {Id = 5, Name = "Lara"},
                new Employee {Id = 6, Name = "Jimi"},
                new Employee {Id = 7, Name = "Laura"},
                new Employee {Id = 8, Name = "John"}
            };

            if (month == null)
                return employees;

            var random = new Random();
            foreach (var employee in employees)
            {
                var salaries = new List<Salary>();

                salaries.AddRange(Salaries(employee.Id, month ?? 0, random));

                employee.Salaries.AddRange(salaries);
            }

            return employees;
        }

        private List<Salary> Salaries(int employeeId,int month, Random random)
        {
            var salaries = new List<Salary>();
            var year = DateTime.Now.Year;
            var monthStart = new DateTime(year, month, 1);
            var monthEnd = monthStart.AddMonths(1);

            var conunter = random.Next(1, 20);
            
            for (int i = 0; i < conunter; i++)
            {
                var addDays = random.Next(1, (monthEnd - monthStart).Days);
                var date = monthStart.AddDays(addDays);
                salaries.Add(new Salary
                {
                    EmployeeId = employeeId,
                    Amount = random.Next(50, 100),
                    Date = date
                });
            }

            return salaries;
        }

    }
}