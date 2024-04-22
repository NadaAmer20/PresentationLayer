using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseCode { get; set; }
        public int CreditHours { get;set; }
        [ForeignKey("department")]
        public int departmentId {  get; set; }   
        public Department department { get; set; }
        public ICollection<Grade> grades { get; set; }
        public ICollection<Enrollment> enrollments { get; set; }
    }
}
