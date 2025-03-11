using Dachy.DataAccess.Data;
using Dachy.DataAccess.Repository.IRepository;
using Dachy.Models;

namespace Dachy.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.ProductId == obj.ProductId);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.Producent = obj.Producent;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Price300 = obj.Price300;
                objFromDb.Price500 = obj.Price500;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.ProductImages = obj.ProductImages;

            }
        }
    }
}
