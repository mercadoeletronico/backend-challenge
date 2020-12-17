using App.Infrastructure.Contexts;
using System.Threading.Tasks;

namespace App.Infrastructure.Transactions
{
    public class Uow : IUow
    {
        private readonly ApplicationContext _context;

        public Uow(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
        }


    }
}
