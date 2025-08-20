using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_dotnet_core.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICatogoryRepository Category{ get; }
        IProductRepository Product{ get; }
        void Save();
    }
}
