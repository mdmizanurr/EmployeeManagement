﻿using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;



namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;

      //  public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment)

        public const string SessionKeyName = "_Name";
        private readonly ILogger<HomeController> _logger;

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment, ILogger<HomeController> logger)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;         
            _logger = logger;  
        }

        public ViewResult Index()
        {
            //var currentTime = DateTime.Now;

            //if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            //{
            //    HttpContext.Session.SetString(SessionKeyName, "Mizan");
            //}

            //var model = _employeeRepository.GetAllEmployee();
            //return View(model);
            return View();
        }

        public ViewResult Details(int? id)
        {
            Exception through = new Exception();

            Employee employee = _employeeRepository.GetEmployee(id.Value);

            if(employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }


            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Details"
            };       

            return View(homeDetailsViewModel);
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
       
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);

            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotopath = employee.PhotoPath  
            };

            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit( EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;

                if (model.Photo != null)
                {
                    if(model.ExistingPhotopath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                           "images", model.ExistingPhotopath);

                        System.IO.File.Delete(filePath);
                    }

                    employee.PhotoPath = ProcessUploadedFile(model);
                }



                _employeeRepository.Update(employee);

                return RedirectToAction("Index");
            }

            return View();
        }

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }

                

            }

            return uniqueFileName;
        }

        [HttpPost]
        public IActionResult Create([Bind(include:"Name, Email, Department, Photo")]EmployeeCreateViewModel model)
        {          
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);         

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };

                _employeeRepository.Add(newEmployee);

                return RedirectToAction( "Details", new { id = newEmployee.Id });
            }

            return View();
        }

        public ActionResult CreatePartial()
        {
            return PartialView();
        }

        public JsonResult GetEmmp()
        {
            var model = _employeeRepository.GetAllEmployee();

            return Json(model);
        }


    }
}
