using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class User 
    {
        public int Id { get; set; }
        public string Username { get; set; }  
        public string Email { get; set; }  
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int PaidLeave { get; set; }
        public int UnpaidLeave { get; set; }
        public bool isManager { get; set; }
    } 
}
