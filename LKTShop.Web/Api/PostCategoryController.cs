using AutoMapper;
using LKTShop.Model.Models;
using LKTShop.Service;
using LKTShop.Web.Infragstructure.Core;
using LKTShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LKTShop.Web.Infragstructure.Extensions;

namespace LKTShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;
        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var m_ListPostCategory = _postCategoryService.GetAll();
                var listCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(m_ListPostCategory);
                _postCategoryService.Save();
                HttpResponseMessage m_Response = request.CreateResponse(HttpStatusCode.Created, listCategoryVm);

                return m_Response;
            });

        }
        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage m_Response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newPostCategory = new PostCategory();
                    newPostCategory.UpdatePostCategory(postCategoryVm);
                    var m_PostCategory = _postCategoryService.Add(newPostCategory);
                    _postCategoryService.Save();
                    m_Response = request.CreateResponse(HttpStatusCode.Created, m_PostCategory);
                }
                return m_Response;
            });

        }
        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage m_Response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategoryDb = _postCategoryService.GetById(postCategoryVm.ID);
                    postCategoryDb.UpdatePostCategory(postCategoryVm);
                    _postCategoryService.Update(postCategoryDb);
                    _postCategoryService.Save();

                    m_Response = request.CreateResponse(HttpStatusCode.OK);
                }
                return m_Response;
            });
        }
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage m_Response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    m_Response = request.CreateResponse(HttpStatusCode.OK);
                }
                return m_Response;
            });
        }
    }
}
