using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Student : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirthday { get; set; }

        [ForeignKey("department")]
        public int? departmentId { get; set; }
        public Department? department { get; set; }
        public ICollection<Grade>? Grades { get; set; }
    }
}
