using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobsPersistentAutograded.Models;

namespace TechJobsPersistentAutograded.ViewModels
{
    public class AddJobViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")] //Added this for the validation
        public string Name { get; set; }
        // public Employer Employer { get; set; }
        [Required(ErrorMessage = "Employer Id is required")] //Added this for the validation
        public int EmployerId { get; set; }
        public List<SelectListItem> Employer { get; set; }
        public List<SelectListItem> JobSkills { get; set; }
        public int SkillId { get; set; }
        public AddJobViewModel(List<Employer> employers,List<Skill> skills)
        {
            
            Employer = new List<SelectListItem>();

            foreach (Employer employerItem in employers)
            {
                Employer.Add(new SelectListItem
                {
                    Value = employerItem.Id.ToString(),
                    Text = employerItem.Name

                });
            }

            JobSkills = new List<SelectListItem>();

            foreach (Skill skillItem in skills)
            {
                JobSkills.Add(new SelectListItem
                {
                    Value = skillItem.Id.ToString(),
                    Text = skillItem.Name

                });
            }



        }
        public AddJobViewModel()
        {

        }
    }
}
