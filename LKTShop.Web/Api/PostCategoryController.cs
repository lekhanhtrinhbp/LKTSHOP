using LKTShop.Model.Models;
using LKTShop.Service;
using LKTShop.Web.Infragstructure.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
                _postCategoryService.Save();
                HttpResponseMessage m_Response = request.CreateResponse(HttpStatusCode.Created, m_ListPostCategory);

                return m_Response;
            });

        }
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategory postCategory)
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
                    var m_PostCategory = _postCategoryService.Add(postCategory);
                    _postCategoryService.Save();
                    m_Response = request.CreateResponse(HttpStatusCode.Created, postCategory);
                }
                return m_Response;
            });

        }
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategory postCategory)
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
                    _postCategoryService.Update(postCategory);
                    _postCategoryService.Save();

                    m_Response = request.CreateResponse(HttpStatusCode.OK);
                }
                return m_Response;
            });
        }
        public HttpResponseMessage Put(HttpRequestMessage request, int id)
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
