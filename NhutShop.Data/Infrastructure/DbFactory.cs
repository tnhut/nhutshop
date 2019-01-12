using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhutShop.Data.Infrastructure
{
  public  class DbFactory : Disposable, IDbFactory
    {
        NhutShopDbContext dbContext;

        public NhutShopDbContext Init()
        {
            return dbContext ?? (dbContext = new NhutShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
