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
    public class CommunityController : ApiController
    {
    
        [HttpGet]
        [Route("api/community")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = CommunityServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/community/{id:int}")]
        public HttpResponseMessage GetM(int id)
        {
            try
            {
                var data = CommunityServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }


        [HttpGet]
        [Route("api/Community/MyCommunity/{id:int}")]
        public HttpResponseMessage MyCommunity(int id)
        {
            try
            {
                var data = CommunityServices.MyCommunity(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }



        [AdminAcces]
        [HttpPost]
        [Route("api/community/add")]
        public HttpResponseMessage AddMembers(CommunityDTO comment)
        {
            try
            {
                var res = CommunityServices.Create(comment);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Authorize(Roles = "TeacherAccess,AdminAcces")]
        [HttpPost]
        [Route("api/community/update")]
        public HttpResponseMessage UpdateMembers(CommunityDTO comment)
        {
            try
            {
                var res = CommunityServices.Update(comment);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [AdminAcces]
        [HttpDelete]
        [Route("api/community/delete/{id:int}")]
        public HttpResponseMessage DeleteMembers(int id)
        {
            try
            {
                var res = CommunityServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
    }
}
