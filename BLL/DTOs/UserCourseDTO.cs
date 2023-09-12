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
    public class UserCourseDTO
    {

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }


    }
}
