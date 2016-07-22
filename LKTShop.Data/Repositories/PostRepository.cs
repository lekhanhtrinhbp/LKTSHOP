using LKTShop.Data.Infrastructure;
using LKTShop.Model.Models;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LKTShop.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllByTag(string tag, int page, int pageSize, out int totalRow);
        //IEnumerable<Post> GetAllByCategoryId(int  categoryId, int page, int pageSize, out int totalRow);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Posts join pt in DbContext.PostTags on p.ID equals pt.PostID
                        where pt.TagID == tag &&  p.Status
                        orderby p.CreatedDate
                        select p;
            //var query = DbContext.Posts.Join(DbContext.PostTags, p => p.ID, t => t.PostID, (p, c) => p).Where(e => e.Status) ;
            totalRow = query.Count();
            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return query;
        }
    }
}