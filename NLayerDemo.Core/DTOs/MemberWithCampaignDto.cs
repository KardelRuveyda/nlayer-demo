using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Core.DTOs
{
    public class MemberWithCampaignDto:MemberDto
    {
        public MemberCampaignDto MemberCampaign { get; set; }
    }
}
