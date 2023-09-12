using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ResetOTPDTO
    {
        public int Id { get; set; }
        public string OTP { get; set; }
        public DateTime createdTime { get; set; }
        public int UserId { get; set; }
    }
}
