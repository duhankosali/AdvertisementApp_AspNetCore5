using Github.AdvertisementApp.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.Business.DependecyResolvers.Microsoft
{
   // "Extension" metodları: "Extension" metotları, mevcut bir sınıfın işlevselliğini genişletmek için kullanılır.
   // "Extension" metotlarını tanımlamak için, "static" bir sınıf kullanılır.Örneğin, "string" veri türü için bir "Extension" metodu kullanarak, belirli bir işlemi gerçekleştirmek için mevcut bir dize verisini kullanabilirsiniz.
    public  static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local")); // appsettings.json'da bulunan "Local" isimli json data'nın ConnectionString değerini çekiyorum.
            });
        }
    }
}
