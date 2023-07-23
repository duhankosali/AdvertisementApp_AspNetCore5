using Github.AdvertisementApp.Common.Enums;
using Github.AdvertisementApp.DataAccess.Contexts;
using Github.AdvertisementApp.DataAccess.Interfaces;
using Github.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Github.AdvertisementApp.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity // Buraya gönderdiğim Generic class, BaseEntity'den kalıtım almak zorundadır.
    {
        // AdvertisementContext nesnemizi oluşturuyoruz ve dependency injection işlemimizi gerçekleştiriyoruz.
        private readonly AdvertisementContext _context; 
        public Repository(AdvertisementContext context)
        {
            _context = context;
        }


        // GetAllAsync methodları
        // ***** GetAllAsync methodunun yapması gereken işlemler: 

        // Not: AsNotTracking() performans arttırımı için kullanılır. GetAllAsync methodlarında herhangi bir CRUD işlemi gerçekleştirilmeyeceği için "AsNotTracking()" kullanmamızda bir problem yoktur.

        // Bütün veriyi getirir.
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        // Bütün veriyi filtrelenmiş olarak getirir.
        public async Task<List<T>> GetAllAsync(Expression<Func<T,bool>> filter)
        {
            return await _context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }
        // Bütün veriyi sıralanmış olarak getirir.
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T,TKey>> selector, OrderByType orderByType = OrderByType.DESC) // Default olarak orderByType == DESC dir.
        {
            // OrderByType == ASC ise "OrderBy" çalışır eğer değilse (OrderByType == DESC) ise OrderByDescending çalışır.
            var list = orderByType == OrderByType.ASC? await _context.Set<T>().AsNoTracking().OrderBy(selector).ToListAsync() :
                                                       await _context.Set<T>().AsNoTracking().OrderByDescending(selector).ToListAsync();

            return list;
        }
        // Hem filtrelenmiş hem sıralanmış olarak getirir.
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            var list = orderByType == OrderByType.ASC ? await _context.Set<T>().Where(filter).AsNoTracking().OrderBy(selector).ToListAsync() :
                                                        await _context.Set<T>().Where(filter).AsNoTracking().OrderByDescending(selector).ToListAsync();

            return list;
        }


       // Find methods
        public async Task<T> FindAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            var entity = !asNoTracking ? await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter) : 
                                         await _context.Set<T>().SingleOrDefaultAsync(filter);
            return entity;
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        // Remove 
        public void Remove(T Entity)
        {
            _context.Set<T>().Remove(Entity);
        }
        // Create
        public async Task CreateAsync(T Entity)
        {
            await _context.Set<T>().AddAsync(Entity);
        }
        // Update
        public void Update(T Entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(Entity);
        }

    }
}
