using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
         public decimal Salary { get; set; } 
        public string AdminRole { get; set; }
        [ForeignKey("college")]
        public int collegeId { get; set; }
        public College college {  get; set; }
        
 
    }
}
