using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Models
{
    public class Project
    {
        [Key]
        [Required]
        public int id { get; set; }

        

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Project Description")]
        public string description { get; set; }

        [Required]
        [Display(Name = "Created Date")]
        public DateTime createdDate { get; set; }

        [Display(Name = "Updated Date")]
        public DateTime? updatedDate { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }

        public Project()
        {
            Users = new HashSet<ApplicationUser>();
        }
    }
}
