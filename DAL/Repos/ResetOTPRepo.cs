using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ResetOTPRepo : Repo, IRepo3<ResetOTP, string, bool>
    {
        public bool Delete(string id)
        {
            var data = db.ResetOTP.Find(id);
            db.ResetOTP.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<ResetOTP> Get()
        {
            var data = db.ResetOTP.ToList();
            return data;
        }

        public ResetOTP Get(string id)
        {
            var ret = (from u in db.ResetOTP
                       where u.OTP.Equals(id)
                       select u).SingleOrDefault();
            return ret;
        }

        public bool Insert(ResetOTP obj)
        {
            var resetotp=db.ResetOTP.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(ResetOTP obj)
        {

            var data = db.ResetOTP.Find(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }


        public ResetOTP SetOTP(int id, string otp)
        {
            var ret = (from u in db.ResetOTP
                        where u.OTP.Equals(otp) && u.UserId == id
                        select u).SingleOrDefault();
            return ret;
        }

    }
}
