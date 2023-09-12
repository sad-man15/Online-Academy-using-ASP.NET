using BLL.DTOs;
using BLL.Services;
using OnlineAcademy.Auth;
using OnlineAcademy.Models;
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
    
    public class UserController : ApiController
    {

        [AdminAcces]
        [HttpGet]
        [Route("api/Users")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = UserServices.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [Logged]
        [HttpGet]
        [Route("api/Users/{id:int}")]
        public HttpResponseMessage GetM(int id)
        {
            try
            {
                var data = UserServices.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }


        [Logged]
        [HttpPost]
        [Route("api/Users/Change/{id:int}")]
        public HttpResponseMessage ChangePass(int id,PasswordModel pm)
        {
            try
            {
                var data = UserServices.ChangePass(id,pm.Password,pm.newPassword);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }



        [Logged]
        [HttpGet]
        [Route("api/Users/reset/{gmail}")]
        public HttpResponseMessage ResetPass(string gmail)
        {
            try
            {
                var data = AuthServices.ResetPass(gmail);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [Logged]
        [HttpPost]
        [Route("api/Users/set/{id:int}")]
        public HttpResponseMessage SetPassword(int id,SetPassModel spm)
        {
            try
            {
                var data = AuthServices.SetPassword(id,spm.Otp,spm.Password);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [AdminAcces]
        [Logged]
        [HttpGet]
        [Route("api/Users/{id:int}/post")]
        public HttpResponseMessage GetWithPost(int id)
        {
            try
            {
                var data = UserServices.GetWithPost(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }



        [HttpPost]
        [Route("api/Users/add")]
        public HttpResponseMessage AddMembers(UserDTO Student)
        {
            try
            {
                var res = UserServices.Create(Student);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
        }

        [Logged]
        [HttpPost]
        [Route("api/Users/update")]
        public HttpResponseMessage UpdateMembers(UserDTO Student)
        {
            try
            {
                var res = UserServices.Update(Student);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Logged]
        [AdminAcces]
        [HttpDelete]
        [Route("api/Users/delete/{id:int}")]
        public HttpResponseMessage DeleteMembers(int id)
        {
            try
            {
                var res = UserServices.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.InnerException.InnerException.Message);
            }

        }
    }
}
