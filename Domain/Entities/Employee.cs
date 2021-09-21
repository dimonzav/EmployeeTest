using Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        public int FullName { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birth { get; set; }
        public bool IsStaffMember { get; set; }
    }
}
