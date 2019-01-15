using NhutShop.Data.Infrastructure;
using NhutShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace NhutShop.Data.Repositories
{
    public interface IOrderDetailRepository: IRepository<OrderDetail>
    {

    }

   public class OrderDetailRepository: RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
     
    }
}
