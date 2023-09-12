using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourseRepo : Repo, IRepo4<Course, int, bool>
    {
        public bool Delete(int id)
        {
            var data = db.Courses.Find(id);
            db.Courses.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Course> Get()
        {
            return db.Courses.ToList();
        }


/*        public List<Course> FinishedCourses(int id)
        {
            var u = (from us in db.UserCourses
                     where us.User.Id == id
                     select us).ToList();

            var courseList = new List<Course>();

            foreach (var i in u)
            {
                courseList.Add((from c in db.Courses
                                where c.UserCourses.Any(uc => uc.UserId == id)
                                select c).FirstOrDefault());
            }
            return courseList;

        }*/


        //All courses
        public List<Course> MyCourses(int id)
        {
            var u = (from us in db.UserCourses
                     where us.User.Id == id
                     select us).ToList();

            var courseList = new List<Course>();

            foreach(var i in u)
            {
                courseList.Add((from c in db.Courses
                            where c.UserCourses.Any(uc => uc.UserId == id)
                                select c).FirstOrDefault());
            }
            return courseList;
           
        }


        public Course Get(int id)
        {
            return db.Courses.Find(id);
        }



/*        public Course Get(string name, string password)
        {
            throw new NotImplementedException();
        }*/

        public bool Insert(Course obj)
        {
            var c=db.Courses.Add(obj);


            var courseCom = new Community()
            {
                CourseId=c.Id,
                Name=c.Name,
            };
            db.Communities.Add(courseCom);

            return db.SaveChanges() > 0;
        }

        public bool Update(Course obj)
        {
            var data = db.Courses.Find(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
