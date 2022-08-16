using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDemo.Core.Repositories
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        Task<List<Member>> GetMemberWithAnnouncement();
        Task<List<Member>> GetMemberWithCampaign();
    }
}
