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
        PostCategory Add(PostCategory postCategory);
        void Update(PostCategory postCategory);
        PostCategory Delete(int id);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllByParenId(int parentId,int page, int pageSize, out int totalRow);
        PostCategory GetById(int id);
        void Save();
    }
    public class PostCategoryService : IPostCategoryService
    {
        IPostCategoryRepository _postCategoryRepository;
        IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }
        public PostCategory Add(PostCategory postCategory)
        {
            return this._postCategoryRepository.Add(postCategory);
        }

        public PostCategory Delete(int id)
        {
            return this._postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return this._postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParenId(int parentId, int page, int pageSize, out int totalRow)
        {
            return this._postCategoryRepository.GetMultiPaging( x => x.Status && x.ParentID == parentId,out totalRow, page, pageSize );
        }

        public PostCategory GetById(int id)
        {
            return this._postCategoryRepository.GetSingleById(id);
        }

        public void Save()
        {
            this._unitOfWork.Commit();
        }

        public void Update(PostCategory postCategory)
        {
            this._postCategoryRepository.Update(postCategory);
        }
    }
}
