using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetCare_BackEnd.Models.Dtos
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }         // Email del usuario para identificar la cuenta
    }
}
