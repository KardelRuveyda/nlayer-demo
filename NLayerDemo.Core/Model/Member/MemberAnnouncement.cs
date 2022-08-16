using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Core.Model.Announcement
{
    public class MemberAnnouncement
    {
        public int MemberId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Footer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Member Member { get; set; }
    }
}
