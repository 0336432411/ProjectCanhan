using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCaNhan.Models
{
    public class ApplicationUser
    {
        public string PasswordResetToken { get; set; }
    public DateTime? ResetTokenExpiry { get; set; }
    }
}