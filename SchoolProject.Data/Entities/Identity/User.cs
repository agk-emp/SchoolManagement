﻿using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Data.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string Country { get; set; }
        public string Address { get; set; }
    }
}