using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCaNhan.Models
{
    public class OTP
    {
        [Key]

        public string id { get; set; }
        public string Otp { get; set; }
        public string Email { get; set; }
        public DateTime ExpirationTime { get; set; }


    }
}