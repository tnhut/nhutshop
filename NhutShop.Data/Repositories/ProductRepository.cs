using NhutShop.Data.Infrastructure;
using NhutShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhutShop.Data.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
        IEnumerable<Product> GetListProductByTag(string tagid, int page, int pageSize, out int totalRow);
    }
    public  class ProductRepository: RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }

        public IEnumerable<Product> GetListProductByTag(string tagid, int page, int pageSize, out int totalRow)
        {
            var query = from p in DbContent.Products
                        join pt in DbContent.ProductTags
                        on p.ID equals pt.ProductID
                        where pt.TagID == tagid
                        select p;
            totalRow = query.Count();
            return query.OrderByDescending(x=>x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
