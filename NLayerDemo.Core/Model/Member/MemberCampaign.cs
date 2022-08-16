using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Core
{
    public class MemberCampaign : BaseEntity
    {
        public int MemberId { get; set; }
        public string CampaignType { get; set; }
        public double CampaignAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Amount { get; set; }
        public Member Member { get; set; }
    }
}
