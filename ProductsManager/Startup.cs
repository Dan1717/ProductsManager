using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ProductsManager.DataAccess;
using ProductsManager.Models;
using AutoMapper;
using ProductsManager.Services.Interfaces;
using ProductsManager.Services.Managers;
using ProductsManager.DataAccess.Unit;
using ProductsManager.DataAccess.Repository;
using ProductsManager.DataAccess.Context;
using Swashbuckle.AspNetCore.Swagger;

namespace ProductsManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions();
            services.Configure<DatabaseOptions>(Configuration.GetSection("DefaultConnection"));
            services.UseDataAccessLayer();

			//services.AddDbContext<DataContext>();
			// repositories, etc
			//services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
			//  services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
			});

			//services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper();

            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<IProductManager, ProductManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
	        app.UseSwagger();
	        app.UseSwaggerUI(c =>
	        {
		        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
	        });

			app.UseMvc();
        }
    }

   
}
