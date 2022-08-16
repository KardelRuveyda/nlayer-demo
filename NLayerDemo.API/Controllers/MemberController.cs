using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerDemo.Core;
using NLayerDemo.Core.DTOs;
using NLayerDemo.Core.Services;
using NLayerDemo.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : CustomBaseController
    {
        private readonly IMapper _mapper;
        //private readonly IService<Member> _service;
        private readonly IMemberService _service;

        public MemberController(IMapper mapper, IMemberService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("GetMemberWithAnnouncement")]
        //"[action]"
        public async Task<IActionResult> GetMemberWithAnnouncement()
        {
            return CreateActionResult(await _service.GetMemberWithAnnouncement());
        }

        [HttpGet("GetMemberWithCampaign")]
        //"[action]"
        public async Task<IActionResult> GetMemberWithCampaign()
        {
            return CreateActionResult(await _service.GetMemberWithCampaign());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var members = await _service.GetAllAsync();
            var memberDtos = _mapper.Map<List<MemberDto>>(members.ToList());
            return CreateActionResult(GlobalResponseDto<List<MemberDto>>.Success(200, memberDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var member = await _service.GetByIdAsync(id);
            var memberDto = _mapper.Map<MemberDto>(member);
            return CreateActionResult(GlobalResponseDto<MemberDto>.Success(200, memberDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(MemberDto memberDto)
        {
            var member = await _service.AddAsync(_mapper.Map<Member>(memberDto));
            var membersDto = _mapper.Map<MemberDto>(member);
            return CreateActionResult(GlobalResponseDto<MemberDto>.Success(201, membersDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(MemberDto memberDto)
        {
            await _service.UpdateAsync(_mapper.Map<Member>(memberDto));

            return CreateActionResult(GlobalResponseDto<NoContentDto>.Success(204));
        }

        //Delete/ api/members/5
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var member = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(member);

            return CreateActionResult(GlobalResponseDto<NoContentDto>.Success(204));
        }
    }
}
