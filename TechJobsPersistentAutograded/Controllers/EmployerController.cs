using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistentAutograded.Data;
using TechJobsPersistentAutograded.Models;
using TechJobsPersistentAutograded.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistentAutograded.Controllers
{
    public class EmployerController : Controller
    {
        //1. private JobRepository variable for Create, Read, Update and Delete operations.
        private JobRepository jobs;
        
        public EmployerController(JobRepository jobs)
        {
            this.jobs = jobs;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
           //2. Passes all of the Employer objects in the database to the view.
            IEnumerable<Employer> employers = jobs.GetAllEmployers();
            return View(employers);
        }

        public IActionResult Add()
        {
            //3. an instance of AddEmployerViewModel inside of the Add() method and pass the instance into the View() return method.
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            return View(addEmployerViewModel);
        }

        //4.Add the appropriate code to ProcessAddEmployerForm() so that it will process form submissions
        [HttpPost]
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {
            if(ModelState.IsValid)
            {
                Employer employer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };
                jobs.AddNewEmployer(employer);
                jobs.SaveChanges();
                return Redirect("Index");
            }
            
            return View("Add",addEmployerViewModel);
        }


        public IActionResult About(int id)
        {
            Employer aboutEmployer = jobs.FindEmployerById(id);

            return View(aboutEmployer);
            
        }
    }
}

