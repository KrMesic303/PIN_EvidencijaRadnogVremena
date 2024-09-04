using EvidencijaRadnogVremena.Data.Repositories.Interfaces;

namespace EvidencijaRadnogVremena.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        Task IUnitOfWork.CommitAsync()
        {
            throw new NotImplementedException();
        }

        Task IUnitOfWork.RollbackAsync()
        {
            throw new NotImplementedException();
        }

        //private IGenericRepository<Actor> _actors;

        //public IGenericRepository<Actor> Actors => _actors ??= new GenericRepository<Actor>(_context);
        //Generički repo je onaj sa standardim CRUD operacijama prema bazi, ovdje proslijeđujemo isti _context svima te unit of work odrađuje posao...
    }
}
