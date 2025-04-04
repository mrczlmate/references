using DAL6QM_HFT_2023241.Models;
using System.Linq;

namespace DAL6QM_HFT_2023241.Repository
{
    public class PublisherRepository : Repository<Publisher>, IRepository<Publisher>
    {
        public PublisherRepository(BookDbContext ctx) : base(ctx)
        {
        }

        public override Publisher Read(int id)
        {
            return ctx.Publishers.FirstOrDefault(p => p.PublisherId == id);
        }

        public override void Update(Publisher item)
        {
            var old = Read(item.PublisherId);
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
