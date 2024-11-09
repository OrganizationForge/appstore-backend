using Domain.Common;
using Domain.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Customers
{
    public class Customer : AuditableBaseEntity
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public Guid? UserId { get; set; }
        public bool IsRegistered { get; set; } = false;
        public Address? Address { get; set; } 
    }
}
