using System;
using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Models
{
    public class Ticket
    {
        //keys
        [Key]
        public int id { get; set; }                //Id of the ticket

        [Required]
        public int projectId { get; set; }          //Id of the project to which the ticket is assigned

        [Required]
        public int ownerUserId { get; set; }        //Id of the User who raised the ticket

        public int assignedUserId { get; set; }        //Id of the User to whom the ticket is assigned


        //Remaining database properties of Ticket
        [Required]
        [Display(Name ="Ticket Name")]
        public string name { get; set; }

        [Required]
        [Display(Name ="Ticket Description")]
        public string description { get; set; }

        [Required]
        public DateTime createdDate { get; set; }

        [Required]
        public DateTime updatedDate { get; set; }


        [Required]
        public Project Project { get; set; }
    }
}
