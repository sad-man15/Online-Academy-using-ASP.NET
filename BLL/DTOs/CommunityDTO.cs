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
    public class CommunityDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
/*        public virtual ICollection<UserCommunity> UserCommunities { get; set; }
        public virtual ICollection<Post> Posts { get; set; }*/

        public int CourseId { get; set; }

    }
}
