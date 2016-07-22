using LKTShop.Data.Infrastructure;
using LKTShop.Data.Repositories;
using LKTShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKTShop.Service
{
    public interface IPostCategoryService
    {
        void Add(PostCategory postCategory);
        void Update(PostCategory postCategory);
        void delete(int id);
        IEnumerable<PostCategory> GetAll(int page, int pageSize, out int totalRow);
        IEnumerable<PostCategory> GetAllByParenId(int parentId,int page, int pageSize, out int totalRow);
        PostCategory GetById(int id);
    }
    public class PostCategoryService : IPostCategoryService
    {
        IPostCategoryRepository _postCategoryRepository;
        IUnitOfWork _unitOfWork;

        public void Add(PostCategory postCategory)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostCategory> GetAll(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostCategory> GetAllByParenId(int parentId, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public PostCategory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PostCategory postCategory)
        {
            throw new NotImplementedException();
        }
    }
}
