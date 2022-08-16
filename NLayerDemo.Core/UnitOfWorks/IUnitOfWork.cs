using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDemo.Core.UnitOfWorks
{
   public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
