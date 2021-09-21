using Domain.Enums;
using System;

namespace MetinvestTest.Models
{
    public class EmployeeModel
    {
        public int Number { get; set; }
        public string FullName { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birth { get; set; }
        public string IsStaffMember { get; set; }
    }
}
