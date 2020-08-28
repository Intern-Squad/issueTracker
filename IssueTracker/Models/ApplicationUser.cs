using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Models
{
    public class ApplicationUser : IdentityUser

    {
        [Required]
        public string name { get; set; }

        public ICollection<Project> Projects;
        public ICollection<Ticket> Tickets;


    }
}
