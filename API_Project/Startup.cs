using API_Project.Services;

namespace API_Project
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddScoped<IClubData, Data>();
			services.AddScoped<ILocationData, Data>();
			services.AddScoped<IPlayerData, Data>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseFileServer();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute("default", "{controller=Location}/{action=Index}");
			});
		}
	}
}
