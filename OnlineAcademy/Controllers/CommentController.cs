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
    [EnableCors("*","*","*")]
    [Logged]
    public class CommentController : ApiController
    {

        [HttpGet]
        [Route("api/comments")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = CommentServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/comments/{id:int}")]
        public HttpResponseMessage GetM(int id)
        {
            try
            {
                var data = CommentServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }


        [HttpPost]
        [Route("api/comments/add")]
        public HttpResponseMessage AddMembers(CommentDTO comment)
        {
            try
            {
                var res = CommentServices.Create(comment);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.InnerException.InnerException.Message);
                
            }
        }


        [HttpPost]
        [Route("api/comments/update")]
        public HttpResponseMessage UpdateMembers(CommentDTO comment)
        {
            try
            {
                var res = CommentServices.Update(comment);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.InnerException.InnerException.Message);
            }
        }


        [HttpDelete]
        [Route("api/comments/delete/{id:int}")]
        public HttpResponseMessage DeleteMembers(int id)
        {
            try
            {
                var res = CommentServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
    }
}
