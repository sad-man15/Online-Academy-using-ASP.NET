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
    public class UserCommunityController : ApiController
    {

        [HttpGet]
        [Route("api/UserCommunitys")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = UserCommunityServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/UserCommunitys/{id:int}")]
        public HttpResponseMessage GetM(int id)
        {
            try
            {
                var data = UserCommunityServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [AdminAcces]
        [HttpPost]
        [Route("api/UserCommunitys/add")]
        public HttpResponseMessage AddMembers(UserCommunityDTO StudentCommunity)
        {
            try
            {
                var res = UserCommunityServices.Create(StudentCommunity);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [AdminAcces]
        [HttpPost]
        [Route("api/UserCommunitys/update")]
        public HttpResponseMessage UpdateMembers(UserCommunityDTO StudentCommunity)
        {
            try
            {
                var res = UserCommunityServices.Update(StudentCommunity);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [AdminAcces]
        [HttpDelete]
        [Route("api/UserCommunitys/delete/{id:int}")]
        public HttpResponseMessage DeleteMembers(int id)
        {
            try
            {
                var res = UserCommunityServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
    }
}
