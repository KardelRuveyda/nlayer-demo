using NLayerDemo.Core.Model.Announcement;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Core
{
    public class Member : BaseEntity
    {
        public string Title { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Logo { get; set; }
        public MemberSetting MemberSetting { get; set; }

        public MemberCampaign MemberCampaign { get; set; }
        public MemberAnnouncement MemberAnnouncement { get; set; }

    }
}
