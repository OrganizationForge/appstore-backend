﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public PhoneDTO Phone { get; set; }
        public IdentificationDTO Identification { get; set; }
        public AddressDTO Address { get; set; }
    }
}
