using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthServices
    {
        public static TokenDTO Authenticate(string name, string password)
        {
            var res = DataAccessFactory.AuthData().Authenticate(name, password);

            if (res)
            {

                var user = DataAccessFactory.UserData().Get(name,password);
                var token = new Token();
                token.UserId = user.Id;
                token.CreatedAt = DateTime.Now;
                token.TKey = Guid.NewGuid().ToString();
                var ret = DataAccessFactory.TokenData().Insert(token);
                if(ret != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    var mapped = mapper.Map<TokenDTO>(ret);
                    return mapped;
                }
               
            }
            return null;

        }


        public static ResetOTPDTO ResetPass(string gmail)
        {
            var res = DataAccessFactory.UserData().ForgetPass(gmail);

            if (res != null)
            {
                Random r = new Random();
                var otp = new ResetOTP();
                otp.OTP = r.Next(1000, 9999).ToString();
                otp.createdTime= DateTime.Now;
                otp.DeletedTime=otp.createdTime.AddHours(2);
                otp.UserId = res.Id;
                var ret = DataAccessFactory.ResetOTPData().Insert(otp);
                if (ret)
                {
                    var retotp = DataAccessFactory.ResetOTPData().Get(otp.OTP);

                    //Sending Otp to the user
                    var client = new SmtpClient();
                    
                        client.Host = "smtp.gmail.com";
                        client.Port = 587;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential("hw733029@gmail.com", "tiasqnrurjbohfor");
                        using (var message = new MailMessage(
                            from: new MailAddress("hw733029@gmail.com", "Hello World"),
                            to: new MailAddress(res.Gmail, res.Name)
                            ))
                        {

                            message.Subject = "Reset Your Password";
                            message.Body = "Your OTP: "+retotp.OTP+". Don't share it with anyone. Thank You!";

                            client.Send(message);
                        }
                    
                    ///


                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<ResetOTP, ResetOTPDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    var mapped = mapper.Map<ResetOTPDTO>(retotp);
                    return mapped;
                }

            }
            return null;

        }

        public static bool SetPassword(int id, string otp,string password)
        {
            var ret = DataAccessFactory.ResetOTPData().SetOTP(id, otp);

            if (ret != null && DateTime.Compare(ret.DeletedTime, DateTime.Now)>=0)
            {
                var user = DataAccessFactory.UserData().ResetPass(id,password);
                return true;
            }
            return false;
        }


        public static bool IsTokenValid(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            if (extk != null && extk.DestryedAt == null)
            {
                return true;
            }
            return false;
        }
        public static bool Logout(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            extk.DestryedAt = DateTime.Now;
            if (DataAccessFactory.TokenData().Update(extk) != null)
            {
                return true;
            }
            return false;


        }
        public static bool IsAdmin(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            if (IsTokenValid(tkey) && extk.User.Role.Equals("Admin"))
            {
                return true;
            }
            return false;
        }

        public static bool IsStudent(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            if (IsTokenValid(tkey) && extk.User.Role.Equals("Student"))
            {
                return true;
            }
            return false;
        }

        public static bool IsTeacher(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            if (IsTokenValid(tkey) && extk.User.Role.Equals("Teacher"))
            {
                return true;
            }
            return false;
        }
    }
}
