using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        [ForeignKey("student")]
        public string studentId { get; set; }
        public Student student { get; set; }

        [ForeignKey("course")]
        public int courseId { get; set; }
        public Course course { get; set; }
    }
}
