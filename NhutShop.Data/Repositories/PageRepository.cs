using NhutShop.Data.Infrastructure;
using NhutShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhutShop.Data.Repositories
{
    public interface IPageRepository: IRepository<Page>
    {

    }

   public class PageRepository: RepositoryBase<Page>, IPageRepository
    {
        public PageRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }
    }
}
