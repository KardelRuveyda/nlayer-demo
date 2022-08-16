using NLayerDemo.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Core.DTOs
{
   public class MemberAnnouncementDto : BaseDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Footer { get; set; }

    }
}
