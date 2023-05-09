using Github.AdvertisementApp.DataAccess.Contexts;
using Github.AdvertisementApp.DataAccess.Interfaces;
using Github.AdvertisementApp.DataAccess.Repositories;
using Github.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly AdvertisementContext _context;
        public Uow(AdvertisementContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity // İlgili repository classını getirir.
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync() // Değişiklikleri kaydeder.
        {
            await _context.SaveChangesAsync();
        }
    }
}
