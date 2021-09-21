using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int Number { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public Sex Sex { get; set; }

        [Required]
        public DateTime Birth { get; set; }

        public bool IsStaffMember { get; set; }
    }
}
