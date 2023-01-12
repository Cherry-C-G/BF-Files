﻿using System.ComponentModel.DataAnnotations;

namespace UserLoginApp.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
