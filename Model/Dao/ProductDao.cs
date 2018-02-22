using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    class ProductDao
    {
        ABCApplicationDbContext db = null;
        public ProductDao()
        {
            db = new ABCApplicationDbContext();
        }
        public int Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public Product GetById(string productName)
        {
            return db.Products.SingleOrDefault(x => x.Name == productName);
        }
        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
