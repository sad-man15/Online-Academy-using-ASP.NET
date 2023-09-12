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
    public class CommunityServices
    {
        public static List<CommunityDTO> Get()
        {
            var data = DataAccessFactory.CommunityData().Get();

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Community, CommunityDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CommunityDTO>>(data);

            return mapped;


            //return Convert(data);
        }

        public static CommunityDTO Get(int id)
        {
            var data= DataAccessFactory.CommunityData().Get(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Community, CommunityDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CommunityDTO>(data);

            return mapped;

        }





        public static List<CommunityDTO> MyCommunity(int id)
        {
            var data = DataAccessFactory.CommunityData().MyCommunity(id);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Community, CommunityDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CommunityDTO>>(data);
            return mapped;
            //return Convert(data);
        }






        public static bool Create(CommunityDTO community)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CommunityDTO, Community>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Community>(community);

            //var data = Convert(community);
            return DataAccessFactory.CommunityData().Insert(mapped);
        }

        public static bool Update(CommunityDTO community)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CommunityDTO, Community>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Community>(community);

            //var data = Convert(community);
            return DataAccessFactory.CommunityData().Update(mapped);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.CommunityData().Delete(id);
        }


        /*static List<CommunityDTO> Convert(List<Community> community)
        {
            var data = new List<CommunityDTO>();
            foreach (var cm in community)
            {
                data.Add(new CommunityDTO()
                {
                    Id = cm.Id,
                    Name = cm.Name,
                    UserCommunities = cm.UserCommunities,
                    CourseId = cm.CourseId,
                    Posts = cm.Posts,
                    Course=cm.Course

                });
            }

            return data;
        }

        static CommunityDTO Convert(Community cm)
        {
            return new CommunityDTO()
            {
                Id = cm.Id,
                Name = cm.Name,
                UserCommunities = cm.UserCommunities,
                CourseId = cm.CourseId,
                Posts = cm.Posts,
                Course = cm.Course
            };
        }

        static Community Convert(CommunityDTO cm)
        {
            return new Community()
            {
                Id = cm.Id,
                Name = cm.Name,
                UserCommunities = cm.UserCommunities,
                CourseId = cm.CourseId,
                Posts = cm.Posts,
                Course = cm.Course
            };
        }*/

    }
}
