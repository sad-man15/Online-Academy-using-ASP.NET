using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PostRepo : Repo, IRepo<Post, int, bool>
    {
        public bool Delete(int id)
        {
            var data = db.Posts.Find(id);
            db.Posts.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Post> Get()
        {
            var data = db.Posts.ToList();
            return data;

        }

        public Post Get(int id)
        {
            var data = db.Posts.Find(id);
            return data;
        }



        public bool Insert(Post obj)
        {
            db.Posts.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(Post obj)
        {
            var data = db.Posts.Find(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
