using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="First Name")]
        
        public string firstName { get; set; }
        [Display(Name ="Last Name")]
        
        public string lastName { get; set; }

        [Display(Name = "Street Address")]
        
        public string address { get; set; }

        [Display(Name = "City")]
        
        public string city { get; set; }

        [Display(Name ="ZipCode")]
        
        public string zipCode { get; set; }

        [Display(Name ="Day of the week for Trash Pick Up")]
        
        public string dayOfTheWeekForPickUp { get; set;}

        [Display(Name = "One Time Pick UP")]
        [DataType(DataType.Date)]
        public string oneTimePickUp { get; set; }

        
        [Display(Name = "The Amount Owed")]        
        public double amountOwed { get; set; }

        [Display(Name = "Start and End Date to Temporarily Suspend Pick ")]
        [DataType(DataType.Date)]
        public string startAndEndDateForSuspendDate { get; set; }


        [ForeignKey ("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public enum DayOfWeeK { };
    }
}