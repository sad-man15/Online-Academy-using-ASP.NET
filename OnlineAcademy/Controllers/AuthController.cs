﻿using BLL.Services;
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
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginModel login)
        {
            try
            {
                var res = AuthServices.Authenticate(login.name, login.Password);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        [Logged]
        [HttpGet]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            var token = Request.Headers.Authorization.ToString();
            try
            {
                var res = AuthServices.Logout(token);
                return Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }

        }
    }
}
