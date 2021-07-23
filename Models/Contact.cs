﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactWebApi.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Status { get; set; }
    }
}