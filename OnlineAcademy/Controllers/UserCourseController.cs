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
    public class UserCourseController : ApiController
    {
        /*[Authorize(Roles = "TeacherAccess,AdminAcces")]*/
        [AdminAcces]
        [HttpGet]
        [Route("api/UserCourses")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = UserCourseServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/UserCourses/{id:int}")]
        public HttpResponseMessage GetM(int id)
        {
            try
            {
                var data = UserCourseServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpPost]
        [Route("api/UserCourses/add")]
        public HttpResponseMessage AddMembers(UserCourseDTO StudentCourse)
        {
            try
            {
                var res = UserCourseServices.Create(StudentCourse);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/UserCourses/update")]
        public HttpResponseMessage UpdateMembers(UserCourseDTO StudentCourse)
        {
            try
            {
                var res = UserCourseServices.Update(StudentCourse);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Authorize(Roles = "TeacherAccess,AdminAcces")]
        [HttpDelete]
        [Route("api/UserCourses/delete/{id:int}")]
        public HttpResponseMessage DeleteMembers(int id)
        {
            try
            {
                var res = UserCourseServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
    }
}
