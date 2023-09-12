using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Community
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<UserCommunity> UserCommunities { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public Community()
        {
            UserCommunities = new List<UserCommunity>();
            Posts = new List<Post>();
        }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

    }
}
