using LKTShop.Model.Models;
using LKTShop.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LKTShop.Web.Infragstructure.Core
{
    public class ApiControllerBase : ApiController
    {
        private IErrorService _errorService;
        public ApiControllerBase(IErrorService errorService)
        {
            this._errorService = errorService;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage m_RespondMessage = null;
            try
            {
                m_RespondMessage = function.Invoke();

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var eve in dbEx.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                this.LogError(dbEx);
                m_RespondMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.Message);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
                m_RespondMessage = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return m_RespondMessage;
        }

        private void LogError(Exception ex)
        {
            try
            {
                Error m_Error = new Error()
                {
                    Message = ex.Message,
                    CreatedDate = DateTime.Now,
                    StackTrace = ex.StackTrace,
                };
                _errorService.Add(m_Error);
                _errorService.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
