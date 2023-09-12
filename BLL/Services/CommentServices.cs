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
    public class CommentServices
    {
        public static List<CommentDTO> Get()
        {
            var data = DataAccessFactory.CommentData().Get();
            var cfg = new MapperConfiguration(c=>
            {
                c.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CommentDTO>>(data);

            return mapped;
            /*return Convert(data);*/
        }

        public static CommentDTO Get(int id)
        {
            var data = DataAccessFactory.CommentData().Get(id);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CommentDTO>(data);

            return mapped; 
            

        }

        public static bool Create(CommentDTO member)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CommentDTO, Comment>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Comment>(member);

            /*var data = Convert(member);*/
            return DataAccessFactory.CommentData().Insert(mapped);
        }

        public static bool Update(CommentDTO member)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CommentDTO, Comment>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Comment>(member);
            /*var data = Convert(member);*/
            return DataAccessFactory.CommentData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.CommentData().Delete(id);
        }


       /* static List<CommentDTO> Convert(List<Comment> comment)
        {
            var data = new List<CommentDTO>();
            foreach (var cm in comment)
            {
                data.Add(new CommentDTO()
                {
                    Id = cm.Id,
                    Text = cm.Text,
                    Date = cm.Date,
                    UserId = (int)cm.UserId,
                    *//*Student=cm.Student,*/
                    /*TeacherId= (int)cm.TeacherId,*/
                    /* Teacher=cm.Teacher,*//*
                    PostId = (int)cm.PostId,
                    *//*Post=cm.Post*//*
                    
                });
            }

            return data;
        }

        static CommentDTO Convert(Comment cm)
        {
            return new CommentDTO()
            {
                Id = cm.Id,
                Text = cm.Text,
                Date = cm.Date,
                UserId = (int)cm.UserId,
                *//*Student = cm.Student,*/
               /* TeacherId = (int)cm.TeacherId,*/
               /* Teacher = cm.Teacher,*//*
                PostId = (int)cm.PostId,
                *//*Post = cm.Post*//*
            };
        }

        static Comment Convert(CommentDTO cm)
        {
            return new Comment()
            {
                Id = cm.Id,
                Text = cm.Text,
                Date = cm.Date,
                UserId = cm.UserId,
                *//*Student = cm.Student,*/
                /*TeacherId = cm.TeacherId,*/
                /*Teacher = cm.Teacher,*//*
                PostId = cm.PostId,
                *//*Post = cm.Post*//*
            };
        }*/


    }
}
