using MIS442Store.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIS442Store.DataLayer.DataModels;
using System.Data.Linq;

namespace MIS442Store.DataLayer.Repositories
{
    public class LINQProductRepository : IProductRepository
    {
        private MIS442DBDataContext _DataContext = new MIS442DBDataContext();

        public virtual Product Get(int id)
        {
            Product p = null;
            ProductDO pDO = _DataContext.spProduct_Get(id).SingleOrDefault();
            if (pDO != null)
            {
                p = new Product();
                p.ProductID = pDO.ProductID;
                p.ProductCode = pDO.ProductCode;
                p.ProductName = pDO.ProductName;
                p.ProductVersion = pDO.ProductVersion;
                p.ProductReleaseDate = pDO.ProductReleaseDate;
            }                                                    
            return p;
        }

        public virtual List<Product> GetList()
        {
            List<Product> list = new List<Product>();
            ISingleResult<ProductDO> pDO = _DataContext.spGet_List();
            foreach (var _p in pDO)
            {
                Product p = new Product();
                p.ProductID = _p.ProductID;
                p.ProductCode = _p.ProductCode;
                p.ProductName = _p.ProductName;
                p.ProductVersion = _p.ProductVersion;
                p.ProductReleaseDate = _p.ProductReleaseDate;
                list.Add(p);
            }
            return list;
        }

        public virtual void Save(Product product)
        {
            if (product.ProductID == 0)
            {
                _DataContext.spInsert_Update(null, product.ProductCode, product.ProductName, product.ProductVersion, product.ProductReleaseDate);
            }
            else
            {
                _DataContext.spInsert_Update(product.ProductID, product.ProductCode, product.ProductName, product.ProductVersion, product.ProductReleaseDate);
            }
        }
    }
}