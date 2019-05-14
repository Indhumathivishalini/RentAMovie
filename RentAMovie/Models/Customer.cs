using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RentAMovie.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]

        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        // reference the table
        public MembershipType Membership { get; set; }

        [Display(Name="Membership Type")]
        // reference the column
        public int MembershipTypeId { get; set; }

    }
}