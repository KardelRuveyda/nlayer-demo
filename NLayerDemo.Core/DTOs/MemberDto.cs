using NLayerDemo.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Core.DTOs
{
   public class MemberDto:BaseDto
    {
        public string Title { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }

    }
}
