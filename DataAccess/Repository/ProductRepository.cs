using learn_dotnet_core.DataAccess.Data;
using learn_dotnet_core.DataAccess.Repository;
using learn_dotnet_core.DataAccess.Repository.IRepository;
using learn_dotnet_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;   
        }


        public void Update(Product product)
        {
            _db.Products.Update(product);
        }
    }
}
