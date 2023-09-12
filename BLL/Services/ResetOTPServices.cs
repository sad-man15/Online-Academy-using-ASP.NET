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
    public class ResetOTPServices
    {
        public static List<ResetOTPDTO> Get()
        {
            var data = DataAccessFactory.ResetOTPData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ResetOTP, ResetOTPDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ResetOTPDTO>>(data);

            return mapped;
        }

        public static ResetOTPDTO Get(string otp)
        {
            var data = DataAccessFactory.ResetOTPData().Get(otp);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ResetOTP, ResetOTPDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ResetOTPDTO>(data);

            return mapped;


        }

        public static bool Create(ResetOTPDTO member)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ResetOTPDTO, ResetOTP>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ResetOTP>(member);

            return DataAccessFactory.ResetOTPData().Insert(mapped);
        }

        public static bool Update(ResetOTPDTO member)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ResetOTPDTO, ResetOTP>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ResetOTP>(member);
            return DataAccessFactory.ResetOTPData().Update(mapped);
        }

        public static bool Delete(string otp)
        {
            return DataAccessFactory.ResetOTPData().Delete(otp);
        }

    }
}
