using DAL.Interface;
using DAL.Models;
using Paket.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo2<User, int, bool>,IAuth<bool>
    {
        public bool Authenticate(string name, string password)
        {
            var user = (from u in db.Users
                        where u.Name.Equals(name)
                        select u).SingleOrDefault();
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);
            if (isValidPassword) return true;
            return false;

        }

        public bool Delete(int id)
        {
            var data = db.Users.Find(id);
            db.Users.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public User Get(string name, string password)
        {

            var user = (from u in db.Users
                        where u.Name.Equals(name)
                        select u).SingleOrDefault();
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);
            if (isValidPassword) return user;
            return null;
        }

        public bool ChangePass(int id,string password, string newPassword)
        {
            var user = db.Users.Find(id);
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);
            if (isValidPassword)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool ResetPass(int id, string password)
        {
            var user = db.Users.Find(id);

            user.Password = BCrypt.Net.BCrypt.HashPassword(password);
            return db.SaveChanges() > 0;
        }



        public User ForgetPass(string gmail)
        {
            var user = (from u in db.Users
                        where u.Gmail.Equals(gmail)
                        select u).SingleOrDefault();
            Console.WriteLine(user.Gmail);
            return user;
           
        }

        public bool Insert(User obj)
        {
            obj.Password = BCrypt.Net.BCrypt.HashPassword(obj.Password);
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(User obj)
        {
            var data = db.Users.Find(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
