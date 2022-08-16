using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Core
{
    public class MemberCampaignShared : BaseEntity
    {
        public int MemberCampaignId { get; set; }
        public bool IsAll  { get; set; }
        public string SharedType { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public bool IsDemoUser { get; set; }
        public int StageId { get; set; }
    }
}
