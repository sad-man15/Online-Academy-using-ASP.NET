using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
/*        public int TeacherId { get; set; }*/

        [Required]
        public double Price { get; set; }

        public string status { get; set; }

        public virtual ICollection<UserCourse> UserCourses { get; set; }
        public Course()
        {
            UserCourses = new List<UserCourse>();
        }

    }
}
