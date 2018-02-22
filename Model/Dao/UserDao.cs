using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class UserDao
    {
        ABCApplicationDbContext db = null;
        public UserDao()
        {
            db = new ABCApplicationDbContext();
        }
        public int Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public IEnumerable<User> ListAllPaging(int page, int pageSize)
        {
            return db.Users.OrderBy(x=>x.Name).ToPagedList(page, pageSize);
        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Name = entity.Name;
                user.Email = entity.Email;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }          
        }

        public User GetById(string username)
        {
            return db.Users.SingleOrDefault(x => x.UserName == username);
        }
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }

        public bool Login(string username, string password)
        {
            var result = db.Users.Count(x => x.UserName == username && x.Password == password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }       
        }
    }
}
