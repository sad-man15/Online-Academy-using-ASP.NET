using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserCommunityRepo : Repo, IRepo<UserCommunity, int, bool>
    {
        public bool Delete(int id)
        {
            var data = db.UserCommunities.Find(id);
            db.UserCommunities.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<UserCommunity> Get()
        {
            return db.UserCommunities.ToList();
        }

        public UserCommunity Get(int id)
        {
            return db.UserCommunities.Find(id);
        }

        public bool Insert(UserCommunity obj)
        {
            db.UserCommunities.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(UserCommunity obj)
        {
            var data = db.UserCommunities.Find(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
