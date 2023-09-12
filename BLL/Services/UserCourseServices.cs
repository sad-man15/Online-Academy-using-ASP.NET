using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserCourseServices
    {
        public static List<UserCourseDTO> Get()
        {
            var data = DataAccessFactory.UserCourseData().Get();

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserCourse, UserCourseDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserCourseDTO>>(data);
            return mapped;

            //return Convert(data);
        }

        public static UserCourseDTO Get(int id)
        {
            var data=DataAccessFactory.UserCourseData().Get(id);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserCourse, UserCourseDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserCourseDTO>(data);
            return mapped;
        }

        public static bool Create(UserCourseDTO StudentCourse)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserCourseDTO, UserCourse>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserCourse>(StudentCourse);

            //var data = Convert(StudentCourse);
            return DataAccessFactory.UserCourseData().Insert(mapped);
        }

        public static bool Update(UserCourseDTO StudentCourse)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserCourseDTO, UserCourse>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserCourse>(StudentCourse);

            //var data = Convert(StudentCourse);
            return DataAccessFactory.UserCourseData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.UserCourseData().Delete(id);
        }


      /*  static List<UserCourseDTO> Convert(List<UserCourse> StudentCourse)
        {
            var data = new List<UserCourseDTO>();
            foreach (var cm in StudentCourse)
            {
                data.Add(new UserCourseDTO()
                {
                    Id = cm.Id,
                    UserId = cm.UserId,
                    User = cm.User,
                    CourseId = cm.CourseId,
                    Course = cm.Course

    });
            }

            return data;
        }

        static UserCourseDTO Convert(UserCourse cm)
        {
            return new UserCourseDTO()
            {
                Id = cm.Id,
                UserId = cm.UserId,
                User = cm.User,
                CourseId = cm.CourseId,
                Course = cm.Course
            };
        }

        static UserCourse Convert(UserCourseDTO cm)
        {
            return new UserCourse()
            {
                Id = cm.Id,
                UserId = cm.UserId,
                User = cm.User,
                CourseId = cm.CourseId,
                Course = cm.Course
            };
        }*/
    }
}
