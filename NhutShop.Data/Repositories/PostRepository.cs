using NhutShop.Data.Infrastructure;
using NhutShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhutShop.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {

    }
    public class PostRepository: RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }
    }
}
