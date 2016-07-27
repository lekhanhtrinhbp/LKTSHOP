using LKTShop.Data.Infrastructure;
using LKTShop.Data.Repositories;
using LKTShop.Model.Models;
using LKTShop.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKTShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> listPostCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object); //Lấy ra đối tượng giả
            listPostCategory = new List<PostCategory>()
            {
                new PostCategory() {ID = 1, Name ="ABC" , Status = true},
                new PostCategory() {ID = 2, Name ="DEF" , Status = true},
                new PostCategory() {ID = 3, Name ="LMN" , Status = true},
            }
            ;

        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //Set up method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(listPostCategory);

            //call action
            var m_Result = _categoryService.GetAll() as List<PostCategory>;

            //compare
            Assert.IsNotNull(m_Result);
            Assert.AreEqual(3, m_Result.Count);
        }
        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory m_PostCategory = new PostCategory()
            {
                ID = 1,
                Name = "Test",
                Alias = "test",
                Status = true,

            };
            _mockRepository.Setup(m => m.Add(m_PostCategory)).Returns((PostCategory p) =>
             {
                 p.ID = 1;
                 return p;
             });
            var m_Result = _categoryService.Add(m_PostCategory);
            Assert.IsNotNull(m_Result);
            Assert.AreEqual(1, m_Result.ID);
        }

    }
}
