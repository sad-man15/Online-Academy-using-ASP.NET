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
    public class PostServices
    {
        public static List<PostDTO> Get()
        {
            var data = DataAccessFactory.PostData().Get();

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PostDTO>>(data);
            return mapped;

            //return Convert(data);
        }

        public static PostDTO Get(int id)
        {
            var data =DataAccessFactory.PostData().Get(id);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PostDTO>(data);
            return mapped;

            
        }

        public static PostCommentDTO GetWithComment(int id)
        {
            var data = DataAccessFactory.PostData().Get(id);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Post, PostCommentDTO>();
                c.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PostCommentDTO>(data);
            return mapped;


        }

        public static bool Create(PostDTO Post)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PostDTO, Post>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Post>(Post);

            //var data = Convert(Post);
            return DataAccessFactory.PostData().Insert(mapped);
        }

        public static bool Update(PostDTO Post)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PostDTO, Post>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Post>(Post);

            //  var data = Convert(Post);
            return DataAccessFactory.PostData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.PostData().Delete(id);
        }


        /*static List<PostDTO> Convert(List<Post> Post)
        {
            var data = new List<PostDTO>();
            foreach (var cm in Post)
            {
                data.Add(new PostDTO()
                {
                    Id = cm.Id,
                    Title = cm.Title,
                    Details = cm.Details,
                    Date = cm.Date,
                    CommunityId = (int)cm.CommunityId,
                    *//*Community = cm.Community,*//*
                    UserId = (int)cm.UserId,
                   *//* Student = cm.Student,*/
                   /* TeacherId = (int)cm.TeacherId,*/
                    /*Teacher = cm.Teacher,*/
                    /*Comments=cm.Comments*//*
                });
            }

            return data;
        }

        static PostDTO Convert(Post cm)
        {
            return new PostDTO()
            {
                Id = cm.Id,
                Title = cm.Title,
                Details = cm.Details,
                Date = cm.Date,
                CommunityId = (int)cm.CommunityId,
                *//*Community = cm.Community,*//*
                UserId = (int)cm.UserId,
                *//*Student = cm.Student,*/
               /* TeacherId = (int)cm.TeacherId,*/
                /*Teacher = cm.Teacher,
                Comments = cm.Comments*//*
            };
        }

        static Post Convert(PostDTO cm)
        {
            return new Post()
            {
                Id = cm.Id,
                Title = cm.Title,
                Details = cm.Details,
                Date = cm.Date,
                CommunityId = cm.CommunityId,
                *//*Community = cm.Community,*//*
                UserId = cm.UserId,
                *//*Student = cm.Student,*/
               /* TeacherId = cm.TeacherId,*/
                /*Teacher = cm.Teacher,*/
                /*Comments = cm.Comments*//*
            };
        }*/
    }
}
