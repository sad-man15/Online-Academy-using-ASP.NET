using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CourseDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

/*        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User user { get; set; }*/

        [Required]
        public double Price { get; set; }

        public string status { get; set; }

        public virtual ICollection<UserCourse> UserCourses { get; set; }

    }
}
