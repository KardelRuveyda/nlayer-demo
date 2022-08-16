using AutoMapper;
using NLayerDemo.Core;
using NLayerDemo.Core.DTOs;
using NLayerDemo.Core.Repositories;
using NLayerDemo.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDemo.Service.Services
{
    public class MemberService : Service<Member>, IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        public MemberService(IGenericRepository<Member> repository, IUnitOfWork unitOfWork, IMemberRepository memberRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<GlobalResponseDto<List<MemberWithAnnouncementDto>>> GetMemberWithAnnouncement()
        {
            var members = await _memberRepository.GetMemberWithAnnouncement();
            var membersDto = _mapper.Map<List<MemberWithAnnouncementDto>>(members);
            return GlobalResponseDto<List<MemberWithAnnouncementDto>>.Success(200,membersDto);
        }

        public async Task<GlobalResponseDto<List<MemberWithCampaignDto>>> GetMemberWithCampaign()
        {
            var members = await _memberRepository.GetMemberWithCampaign();
            var membersDto = _mapper.Map<List<MemberWithCampaignDto>>(members);
            return GlobalResponseDto<List<MemberWithCampaignDto>>.Success(200,membersDto);
        }
    }
}
