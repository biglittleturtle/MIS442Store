using MIS442Store.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.Repositories
{
    public class ProductCachingRepository : LINQProductRepository
    {
        

        public override List<Product> GetList()
        {
            List<Product> cachedList = new List<Product>();
            HttpRuntime.Cache["cachedList"] = cachedList;
            if (cachedList == null)
            {
                cachedList = base.GetList();
                HttpRuntime.Cache["cachedList"] = cachedList;
            }
            return cachedList;
        }

        public override Product Get(int id)
        {
            return base.Get(id);
        }

        public override void Save(Product p)
        {
            base.Save(p);
            HttpRuntime.Cache["cachedList"] = null;
        }
    }
}