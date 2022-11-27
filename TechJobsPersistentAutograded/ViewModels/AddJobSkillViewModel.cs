using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobsPersistentAutograded.Models;

namespace TechJobsPersistentAutograded.ViewModels
{
    public class AddJobSkillViewModel
    {
        [Required(ErrorMessage = "Job is required")]
        public int JobId { get; set; } 

        public Job Job { get; set; }

        [Required(ErrorMessage = "Skill is required")]
        public int SkillId { get; set; }

        public List<SelectListItem> Skills { get; set; } //List of available skills.

        public AddJobSkillViewModel(Job theJob, List<Skill> possibleSkills)
        {
            Skills = new List<SelectListItem>();

            foreach (var skill in possibleSkills)
            {
                Skills.Add(new SelectListItem
                {
                    Value = skill.Id.ToString(),
                    Text = skill.Name
                });
            }

            Job = theJob; //this will get passed into the view too
        }

        public AddJobSkillViewModel()
        {
        }
    }
}

