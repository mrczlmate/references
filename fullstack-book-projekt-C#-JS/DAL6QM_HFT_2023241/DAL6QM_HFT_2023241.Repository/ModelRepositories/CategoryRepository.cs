using DAL6QM_HFT_2023241.Models;
using System.Linq;

namespace DAL6QM_HFT_2023241.Repository
{
    public class CategoryRepository : Repository<Category>, IRepository<Category>
    {
        public CategoryRepository(BookDbContext ctx) : base(ctx)
        {
        }

        public override Category Read(int id)
        {
            return ctx.Categories.FirstOrDefault(p => p.CategoryId == id);
        }

        public override void Update(Category item)
        {
            var old = Read(item.CategoryId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
