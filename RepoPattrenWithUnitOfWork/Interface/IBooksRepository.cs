using RepoPattrenWithUnitOfWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattrenWithUnitOfWork.Core.Interface
{
    public interface IBooksRepository : IBaseRepository<book>
    {
        IEnumerable<book> SpecialMethod();
    }
}
