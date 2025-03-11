using Dachy.DataAccess.Data;
using Dachy.DataAccess.Repository.IRepository;
using Dachy.Models;

namespace Dachy.DataAccess.Repository
{
    public class CategoryRepository : Repository <Category>, ICategoryRepository 
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
