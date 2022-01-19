using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositary.core;
using Repositary.core.interfaces;
using Repositary.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoTask.Controllers
{
    public class EmployeeController : Controller
    {
        //private iBaseRepository<Employee> EmpRepo;

        private IUnitOfWork unitOfWork ;

        public EmployeeController(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Emps = unitOfWork.Employees.GetAll().ToList();
            return View(Emps);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var depts = unitOfWork.Departments.GetAll().ToList();
            ViewBag.depts = new SelectList(depts, "id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee emp)
        {
            if(ModelState.IsValid)
            {
                unitOfWork.Employees.Add(emp);
                unitOfWork.Complete();
                return RedirectToAction("GetAll");
            }
            var depts = unitOfWork.Departments.GetAll().ToList();
            ViewBag.depts = new SelectList(depts, "id", "Name");
            return View(emp);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Emp = unitOfWork.Employees.GetById(id);
            return View(Emp);
        }

        [HttpPost]
        public IActionResult Delete(Employee model)
        {
            unitOfWork.Employees.Delete(model.id);
            unitOfWork.Complete();
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Emp = unitOfWork.Employees.GetById(id);
            var depts = unitOfWork.Departments.GetAll().ToList();
            ViewBag.depts = new SelectList(depts, "id", "Name");
            return View(Emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            unitOfWork.Employees.Update(model);
            unitOfWork.Complete();
            return RedirectToAction("GetAll");
        }
    }
}
