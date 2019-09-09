using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        
        public int Id { get; set; }
        [Display(Name ="Employee First Name")]
        public string firstName { get; set; }
        [Display(Name = "Employee Last Name")]
        public string lastName { get; set; }
        [Display(Name ="Employee Zipcode")]
        public string zipCode { get; set; }

        [ForeignKey("ApplicationUser")]
        [Display(Name = "UserID")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}