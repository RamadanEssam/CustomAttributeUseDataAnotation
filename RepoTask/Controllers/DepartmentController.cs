using Microsoft.AspNetCore.Mvc;
using Repositary.core;
using Repositary.core.interfaces;
using Repositary.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoTask.Controllers
{
    public class DepartmentController : Controller
    {
        
        private IUnitOfWork unitOfWork;

        public DepartmentController(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var depts = unitOfWork.Departments.GetAll().ToList();
            return View(depts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department dept)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Departments.Add(dept);
                unitOfWork.Complete();

                return RedirectToAction("GetAll");
            }
            else
            {
                return View(dept);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dep = unitOfWork.Departments.GetById(id);
            return View(dep);
        }

        [HttpPost]
        public IActionResult Delete(Department model)
        {
            unitOfWork.Departments.Delete(model.id);
            unitOfWork.Complete();
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dep = unitOfWork.Departments.GetById(id);
            return View(dep);
        }

        [HttpPost]
        public IActionResult Edit(Department model)
        {
            unitOfWork.Departments.Update(model);
            unitOfWork.Complete();
            return RedirectToAction("GetAll");
        }
    }
}
