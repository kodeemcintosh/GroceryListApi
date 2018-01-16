using GroceryList.Business;
using GroceryList.Data;
using GroceryList.Data.Map;
using GroceryList.Data.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using System.Web.Http.Cors;

namespace GroceryList
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
			services.AddTransient<IGrocery, GroceryService>();
	        services.AddTransient<IGrocery, GroceryRepository>();
	        services.AddTransient<IDataMapper, DataMapper>();
	        services.AddSingleton<GetGroceryList>();
	        services.AddSingleton<CreateGroceryItem>();
	        services.AddSingleton<UpdateGroceryList>();
	        services.AddSingleton<RemoveGroceryItem>();
	        services.AddSingleton<DeleteGroceryItem>();

			// Enables cross-origin requests
	        services.AddCors(options =>
	        {
		        options.AddPolicy("CORS_POLICY",
			        policy => policy.WithOrigins("http://localhost:4200")
						.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials());
	        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
	            app.UseCors("CORS_POLICY");
            }

            app.UseMvc();
        }
    }
}
