﻿using Microsoft.Extensions.DependencyInjection;
using ProductsManager.DataAccess.Context;
using ProductsManager.DataAccess.Repository;
using ProductsManager.DataAccess.Unit;

namespace ProductsManager.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection UseDataAccessLayer(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<DataContext>();
            // repositories, etc
            //serviceCollection.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
            return serviceCollection;
        }
    }
}
