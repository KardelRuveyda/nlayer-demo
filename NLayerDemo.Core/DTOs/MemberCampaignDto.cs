using NLayerDemo.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Core.DTOs
{
    public class MemberCampaignDto:BaseDto
    {
        public string CampaignType { get; set; }
        public double CampaignAmount { get; set; }
        public double Amount { get; set; }
    }
}
