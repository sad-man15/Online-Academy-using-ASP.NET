using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserCourseRepo : Repo, IRepo<UserCourse, int, bool>
    {
        public bool Delete(int id)
        {
            var data = db.UserCourses.Find(id);
            db.UserCourses.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<UserCourse> Get()
        {
            return db.UserCourses.ToList();
        }

        public UserCourse Get(int id)
        {
            return db.UserCourses.Find(id);
        }

        public bool Insert(UserCourse obj)
        {
            var uc=db.UserCourses.Add(obj);

            var com= (from c in db.Communities
                      where c.CourseId == uc.CourseId
                      select c).FirstOrDefault();

            var userCom = new UserCommunity() {
                UserId=uc.UserId,
                CommunityId=com.Id
            };

            db.UserCommunities.Add(userCom);
            return db.SaveChanges() > 0;
        }

        public bool Update(UserCourse obj)
        {
            var data = db.UserCourses.Find(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
