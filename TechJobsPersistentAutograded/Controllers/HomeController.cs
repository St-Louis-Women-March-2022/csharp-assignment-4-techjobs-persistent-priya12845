using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistentAutograded.Models;
using TechJobsPersistentAutograded.ViewModels;
using TechJobsPersistentAutograded.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistentAutograded.Controllers
{

    public class HomeController : Controller

    {
        private JobRepository _repo;

        public HomeController(JobRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()

        {
            IEnumerable<Job> jobs = _repo.GetAllJobs();

            return View(jobs);
        }


        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            List<Employer> employers = _repo.GetAllEmployers().ToList();
            List<Skill> skills = _repo.GetAllSkills().ToList();
            //3. an instance of AddEmployerViewModel inside of the Add() method and pass the instance into the View() return method.
            
            AddJobViewModel addJobViewModel = new AddJobViewModel(employers,skills);
            return View(addJobViewModel);
        }

        //4.Add the appropriate code to ProcessAddJobForm() so that it will process form submissions
        //Second argument for list skill I added because of the test case.
        [HttpPost]
        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
        {
            if (ModelState.IsValid)
            {
                Employer theEmployer =  _repo.FindEmployerById(addJobViewModel.EmployerId);
                //Skill theSkill = _repo.FindJobSkillsById(addJobViewModel.SkillId);
                Job job = new Job
                {
                    Name = addJobViewModel.Name,
                    EmployerId = theEmployer.Id
                    
                };

                
                for(int i = 0; i < selectedSkills.Length; i++)
                {
                    JobSkill jobSkill = new JobSkill
                    {
                        JobId = job.Id,
                        Job = job,
                        SkillId = int.Parse(selectedSkills[i]),
                    };
                _repo.AddNewJobSkill(jobSkill);
                }
                
                
                _repo.AddNewJob(job);
                
                _repo.SaveChanges();
                return Redirect("Index");
            }

            return View("AddJob", addJobViewModel);
        }


        public IActionResult Detail(int id)
        {
            Job theJob = _repo.FindJobById(id);

            List<JobSkill> jobSkills = _repo.FindSkillsForJob(id).ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }

    }

}


