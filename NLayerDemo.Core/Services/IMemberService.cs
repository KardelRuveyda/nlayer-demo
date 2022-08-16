using NLayerDemo.Core;
using NLayerDemo.Core.DTOs;
using NLayerDemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDemo.Service.Services
{
    public interface IMemberService:IService<Member>
    {
        Task<GlobalResponseDto<List<MemberWithAnnouncementDto>>> GetMemberWithAnnouncement();
        Task<GlobalResponseDto<List<MemberWithCampaignDto>>> GetMemberWithCampaign();
    }
}
