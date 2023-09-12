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
    public class UserServices
    {
        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Get();

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<UserDTO>>(data);
            return mapped;
            //return Convert(data);
        }

        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserData().Get(id);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserDTO>(data);
            return mapped;
        }



        public static bool ChangePass(int id,string password, string newPassword)
        {
            var res = DataAccessFactory.UserData().ChangePass(id,password,newPassword);
            return res;
        }


        public static UserPostDTO GetWithPost(int id)
        {
            var data = DataAccessFactory.UserData().Get(id);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserPostDTO>();
                c.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<UserPostDTO>(data);
            return mapped;


        }




        public static bool Create(UserDTO user)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<User>(user);

            //var data = Convert(Student);
            return DataAccessFactory.UserData().Insert(mapped);
        }

        public static bool Update(UserDTO user)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<User>(user);

            //var data = Convert(Student);
            return DataAccessFactory.UserData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.UserData().Delete(id);
        }


        /*static List<UserDTO> Convert(List<User> Student)
        {
            var data = new List<UserDTO>();
            foreach (var cm in Student)
            {
                data.Add(new UserDTO()
                {
                    Id = cm.Id,
                    Name = cm.Name,
                    Age = cm.Age,
                    Phone = cm.Phone,
                    Gmail = cm.Gmail,
                    Gender = cm.Gender,
                    Role = cm.Role,
                    JoinDate = cm.JoinDate,
                    UserCommunities = cm.UserCommunities,
                    UserCourses = cm.UserCourses,
                    Posts = cm.Posts,
                    Comments = cm.Comments

    });
            }

            return data;
        }

        static UserDTO Convert(User cm)
        {
            return new UserDTO()
            {
                Id = cm.Id,
                Name = cm.Name,
                Age = cm.Age,
                Phone = cm.Phone,
                Gmail = cm.Gmail,
                Gender = cm.Gender,
                Role = cm.Role,
                JoinDate = cm.JoinDate,
                UserCommunities = cm.UserCommunities,
                UserCourses = cm.UserCourses,
                Posts = cm.Posts,
                Comments = cm.Comments
            };
        }

        static User Convert(UserDTO cm)
        {
            return new User()
            {
                Id = cm.Id,
                Name = cm.Name,
                Age = cm.Age,
                Phone = cm.Phone,
                Gmail = cm.Gmail,
                Gender = cm.Gender,
                Role = cm.Role,
                JoinDate = cm.JoinDate,
                UserCommunities = cm.UserCommunities,
                UserCourses = cm.UserCourses,
                Posts = cm.Posts,
                Comments = cm.Comments
            };
        }*/
    }
}
