using NhutShop.Data.Infrastructure;
using NhutShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhutShop.Data.Repositories
{
    public interface IMenuRepository: IRepository<Menu>
    {

    }

   public class MenuRepository: RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
