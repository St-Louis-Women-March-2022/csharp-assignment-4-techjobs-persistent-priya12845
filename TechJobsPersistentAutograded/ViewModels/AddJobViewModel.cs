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
        public List<JobSkill> JobSkills { get; set; }
    }
}
