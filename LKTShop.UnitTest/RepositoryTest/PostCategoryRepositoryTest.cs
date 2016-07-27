using LKTShop.Data.Infrastructure;
using LKTShop.Data.Repositories;
using LKTShop.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKTShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFatory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;
        [TestInitialize]
        public void Initialize()
        {
            dbFatory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFatory);
            unitOfWork = new UnitOfWork(dbFatory);

        }
        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var m_List = this.objRepository.GetAll();
            Assert.AreEqual(3, m_List.ToList());
        }
        [TestMethod]
         public void PostCategory_Repository_Create()
        {
            PostCategory m_Category = new PostCategory()
            {
                Name = "Test",
                Alias = "Test-PostCategory",
                Status = true
            };
            var m_Result = this.objRepository.Add(m_Category);
            unitOfWork.Commit();
            Assert.IsNotNull(m_Result);
            Assert.AreEqual(4,m_Result.ID);
            
        }
    }
}
