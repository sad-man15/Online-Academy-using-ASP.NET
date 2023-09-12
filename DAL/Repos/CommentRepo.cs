using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CommentRepo : Repo, IRepo<Comment, int, bool>
    {
        public bool Delete(int id)
        {
            var data = db.Comments.Find(id);
            db.Comments.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Comment> Get()
        {
            var data = db.Comments.ToList();
            return data;
        }

        public Comment Get(int id)
        {
            var data = db.Comments.Find(id);
            return data;
        }

        public bool Insert(Comment obj)
        {
            db.Comments.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(Comment obj)
        {
            var data = db.Comments.Find(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
