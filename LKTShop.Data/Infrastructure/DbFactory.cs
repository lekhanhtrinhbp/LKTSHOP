using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKTShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private LKTShopDbContext dbContext;

        public LKTShopDbContext Init()
        {
            return dbContext ?? (dbContext = new LKTShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
