using System;

namespace TechJobsPersistentAutograded.Models
{
    //This class is for many to many relationship where jobid and skillid together will make a primary key
    public class JobSkill
    {
        public int JobId { get; set; }
        public Job Job { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }

        public JobSkill()
        {
        }
    }
}
