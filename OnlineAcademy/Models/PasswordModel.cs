using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineAcademy.Models
{
    public class PasswordModel
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string newPassword { get; set; }
    }
}