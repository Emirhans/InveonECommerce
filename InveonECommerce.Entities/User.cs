﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InveonECommerce.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
    }
}
