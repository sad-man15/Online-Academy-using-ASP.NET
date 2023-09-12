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
    public class CourseServices
    {
        public static List<CourseDTO> Get()
        {
            var data = DataAccessFactory.CourseData().Get();

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Course, CourseDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CourseDTO>>(data);
            return mapped;
            //return Convert(data);
        }


        public static List<CourseDTO> MyCOurses(int id)
        {
            var data = DataAccessFactory.CourseData().MyCourses(id);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Course, CourseDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CourseDTO>>(data);
            return mapped;
            //return Convert(data);
        }



        public static CourseDTO Get(int id)
        {
            var data=DataAccessFactory.CourseData().Get(id);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Course, CourseDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CourseDTO>(data);
            return mapped;
        }

        public static bool Create(CourseDTO course)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CourseDTO, Course>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Course>(course);

            //var data = Convert(Course);
            return DataAccessFactory.CourseData().Insert(mapped);
        }

        public static bool Update(CourseDTO course)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CourseDTO, Course>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Course>(course);

            //var data = Convert(Course);
            return DataAccessFactory.CourseData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.CourseData().Delete(id);
        }


        /*static List<CourseDTO> Convert(List<Course> Course)
        {
            var data = new List<CourseDTO>();
            foreach (var cm in Course)
            {
                data.Add(new CourseDTO()
                {
                    Id = cm.Id,
                    Name = cm.Name,
                    *//*TeacherId = cm.TeacherId,*//*
                    Price = cm.Price,
                    UserCourses = cm.UserCourses,

                });
            }

            return data;
        }

        static CourseDTO Convert(Course cm)
        {
            return new CourseDTO()
            {
                Id = cm.Id,
                Name = cm.Name,
                *//*TeacherId = cm.TeacherId,*//*
                Price = cm.Price,
                UserCourses = cm.UserCourses,
            };
        }

        static Course Convert(CourseDTO cm)
        {
            return new Course()
            {
                Id = cm.Id,
                Name = cm.Name,
                *//*TeacherId = cm.TeacherId,*//*
                Price = cm.Price,
                UserCourses = cm.UserCourses,
            };
        }*/
    }
}
