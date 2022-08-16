using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Core
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool IsAdmin { get; set; }
    }
}
