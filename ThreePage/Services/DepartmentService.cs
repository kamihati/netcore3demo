using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreePage.Models;

namespace ThreePage.Services
{
    public class DepartmentService : IDepartmentService
    {

        private readonly List<Department> _deparments = new List<Department>();

        public DepartmentService()
        {
            _deparments.Add(new Department
            {
                Id = 1,
                Name = "HR",
                EmployeeCount = 16,
                Location = "BeiJing"
            });

            _deparments.Add(new Department
            {
                Id = 2,
                Name = "R&D",
                EmployeeCount = 52,
                Location = "ShangHai"
            });

            _deparments.Add(new Department
            {
                Id = 3,
                Name = "Sales",
                EmployeeCount = 200,
                Location = "China"
            });

        }

        public Task Add(Department department)
        {
            department.Id = _deparments.Max(x => x.Id) + 1;
            _deparments.Add(department);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            return Task.Run(() => _deparments.AsEnumerable());
        }

        public Task<Department> GetById(int id)
        {
            return Task.Run(() => _deparments.FirstOrDefault(x => x.Id == id));
        }

        public Task<CompanySummary> GetCompanySummary()
        {
            return Task.Run(() =>
            {
                return new CompanySummary
                {
                    EmployeeCount = _deparments.Sum(x => x.EmployeeCount),
                    AverageDepartmentEmployeeCount = (int)_deparments.Average(x => x.EmployeeCount)
                };
            });
        }
    }
}
