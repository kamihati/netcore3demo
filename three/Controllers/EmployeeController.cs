﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Three.Models;
using Three.Services;

namespace Three.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
        }

        /// <summary>
        /// 列出部门下所有员工
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(int departmentId)
        {
            var department = await _departmentService.GetById(departmentId);
            ViewBag.Title = $"Employee of {department.Name}";
            ViewBag.DepartmentId = department.Id;
            var employees = await _employeeService.GetByDepartmentId(departmentId);
            return View(employees);
        }

        public IActionResult Add(int departmentId)
        {
            ViewBag.Title = "Add Employee";
            return View(new Employee
            {
                DepartmentId = departmentId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.Add(model);
            }
            return RedirectToAction(nameof(Index), new { departmentId = model.DepartmentId });
        }

        public async Task<IActionResult> Fire(int employeeId)
        {
            var employee = await _employeeService.Fire(employeeId);
            return RedirectToAction(nameof(Index), new { departmentId=employee.DepartmentId});
        }
    }
}