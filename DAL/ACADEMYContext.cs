using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class ACADEMYContext:DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCommunity> UserCommunities { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<ResetOTP> ResetOTP { get; set; }


    }
}
