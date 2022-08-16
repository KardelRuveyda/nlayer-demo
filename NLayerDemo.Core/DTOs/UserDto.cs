using NLayerDemo.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Core.DTOs
{
   public class UserDto:BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

    }
}
