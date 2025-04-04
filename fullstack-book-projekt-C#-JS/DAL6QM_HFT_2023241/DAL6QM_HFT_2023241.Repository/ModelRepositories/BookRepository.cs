using DAL6QM_HFT_2023241.Models;
using System.Linq;

namespace DAL6QM_HFT_2023241.Repository
{
    public class BookRepository : Repository<Book>, IRepository<Book>
    {
        public BookRepository(BookDbContext ctx) : base(ctx)
        {
        }

        public override Book Read(int id)
        {
            return ctx.Books.FirstOrDefault(b => b.BookId == id);
        }

        public override void Update(Book item)
        {
            var old = Read(item.BookId);
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
