using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class College
    {
        public int Id { get;set; }
        public string Name { get;set; }
        public string City { get; set; }
        public string Website { get; set; }
        public int CreditHoursPerTerm { get; set; } 
        public ICollection<Student> Students { get; set; }
        public ICollection<Admin> Employees { get; set; }
    }
}
