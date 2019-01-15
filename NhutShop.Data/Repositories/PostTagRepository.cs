using NhutShop.Data.Infrastructure;
using NhutShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhutShop.Data.Repositories
{
    public interface IPostTagRepository : IRepository<PostTag>
    {

    }
    public class PostTagRepository: RepositoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }
    }
}
