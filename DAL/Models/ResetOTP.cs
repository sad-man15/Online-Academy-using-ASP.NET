﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ResetOTP
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string OTP { get; set; }
        [Required]
        public DateTime createdTime { get; set; }

        public DateTime DeletedTime { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
