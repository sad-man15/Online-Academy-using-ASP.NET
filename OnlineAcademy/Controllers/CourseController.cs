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
    public class CourseController : ApiController
    {

        [HttpGet]
        [Route("api/Courses")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = CourseServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/Courses/{id:int}")]
        public HttpResponseMessage GetM(int id)
        {
            try
            {
                var data = CourseServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet]
        [Route("api/Courses/MyCourses/{id:int}")]
        public HttpResponseMessage MyCourses(int id)
        {
            try
            {
                var data = CourseServices.MyCOurses(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }



        [AdminAcces]
        [HttpPost]
        [Route("api/Courses/add")]
        public HttpResponseMessage AddMembers(CourseDTO Course)
        {
            try
            {
                var res = CourseServices.Create(Course);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [AdminAcces]
        [HttpPost]
        [Route("api/Courses/update")]
        public HttpResponseMessage UpdateMembers(CourseDTO Course)
        {
            try
            {
                var res = CourseServices.Update(Course);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [AdminAcces]
        [HttpDelete]
        [Route("api/Courses/delete/{id:int}")]
        public HttpResponseMessage DeleteMembers(int id)
        {
            try
            {
                var res = CourseServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
    }
}
