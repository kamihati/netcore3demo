﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreePage.Models;

namespace ThreePage.Services
{
    public interface IEmployeeService
    {
        Task Add(Employee employee);

        Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId);

        Task<Employee> Fire(int id);
    }
}
