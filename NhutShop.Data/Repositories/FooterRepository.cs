using NhutShop.Data.Infrastructure;
using NhutShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhutShop.Data.Repositories
{
    public interface IFooterRepository: IRepository<Footer>
    {

    }

   public class FooterRepository: RepositoryBase<Footer>, IFooterRepository
    {
        public FooterRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }

    }
}
