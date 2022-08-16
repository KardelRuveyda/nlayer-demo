using NLayerDemo.Core.Model.Announcement;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Core.DTOs
{
    public class MemberWithAnnouncementDto:MemberDto
    {
        public MemberAnnouncementDto MemberAnnouncement { get; set; } 
    }
}
