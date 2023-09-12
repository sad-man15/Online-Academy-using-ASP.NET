using BLL.DTOs;
using BLL.Services;
using OnlineAcademy.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OnlineAcademy.Controllers
{
    [EnableCors("*", "*", "*")]
    [Logged]
    public class PostController : ApiController
    {
        /*[AdminAcces]*/
        [HttpGet]
        [Route("api/Posts")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = PostServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        
        [HttpGet]
        [Route("api/Posts/{id:int}")]
        public HttpResponseMessage GetM(int id)
        {
            try
            {
                var data = PostServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/Posts/{id:int}/comments")]
        public HttpResponseMessage GetWithComment(int id)
        {
            try
            {
                var data = PostServices.GetWithComment(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }


        [HttpPost]
        [Route("api/Posts/add")]
        public HttpResponseMessage AddMembers(PostDTO Post)
        {
            try
            {
                var res = PostServices.Create(Post);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.InnerException.InnerException.Message);
            }
        }

        [HttpPost]
        [Route("api/Posts/update")]
        public HttpResponseMessage UpdateMembers(PostDTO Post)
        {
            try
            {
                var res = PostServices.Update(Post);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [HttpDelete]
        [Route("api/Posts/delete/{id:int}")]
        public HttpResponseMessage DeleteMembers(int id)
        {
            try
            {
                var res = PostServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
    }
}
