using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }


/*        [ForeignKey("Teacher")]
        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }*/


        [ForeignKey("Post")]
        public int? PostId { get; set; }
        public virtual Post Post { get; set; }



    }
}
