using Github.AdvertisementApp.Common.Enums;
using Github.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity // Buraya gönderdiğim Generic class, BaseEntity'den kalıtım almak zorundadır.
    {
        // GetAllAsync methods
        Task<List<T>> GetAllAsync(); // Bütün veriyi getirir.
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter); // Bütün veriyi sıralanmış olarak getirir.
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC); // Bütün veriyi sıralanmış olarak getirir.
        Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.DESC); // Hem filtrelenmiş hem sıralanmış olarak getirir.


        // Find methods
        Task<T> FindAsync(object id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        IQueryable<T> GetQuery();
        // Remove method
        void Remove(T Entity);
        // Create method
        Task CreateAsync(T Entity);
        // Update method
        void Update(T Entity, T unchanged);

    }
}
