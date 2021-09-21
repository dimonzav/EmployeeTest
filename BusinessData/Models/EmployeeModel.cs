using Domain.Enums;
using System;

namespace BusinessData.Models
{
    public class EmployeeModel
    {
        public int Number { get; set; }
        public string FullName { get; set; }
        public Sex Sex { get; set; }
        public DateTime Birth { get; set; }
        public string StaffMember { get; set; }
        public bool IsStaffMember { get; set; }
    }
}
