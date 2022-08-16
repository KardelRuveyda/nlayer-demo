using Microsoft.EntityFrameworkCore;
using NLayerDemo.Core;
using NLayerDemo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDemo.Repository.Repositories
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Member>> GetMemberWithAnnouncement()
        {
            //Eager Loading: Member'a bağlı duyuruları dirke çekiyorum 
            //Lazy Loading : Member'a bağlı duyuruları sonra çekersek bu olacaktı. 
            return await _context.Member.Include(x => x.MemberAnnouncement).ToListAsync();
        }

        public async Task<List<Member>> GetMemberWithCampaign()
        {
            return await _context.Member.Include(x => x.MemberCampaign).ToListAsync();
        }
    }
}
