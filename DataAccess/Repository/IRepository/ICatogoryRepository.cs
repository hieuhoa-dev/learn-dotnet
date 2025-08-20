using learn_dotnet_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn_dotnet_core.DataAccess.Repository.IRepository
{
    public interface ICatogoryRepository : IRepository<Category>
    {
        void Update(Category category);
        // This method is used to update a category entity.
    }
}
