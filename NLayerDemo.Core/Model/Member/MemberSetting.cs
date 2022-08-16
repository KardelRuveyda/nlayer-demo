using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Core
{
    public class MemberSetting : BaseEntity
    {
        public int MemberId { get; set; }
        public string ContactType { get; set; }
        public bool IsSendMail { get; set; }
        public bool IsSendSms { get; set; }
        public Member Member { get; set; }
    }
}
