using Microsoft.EntityFrameworkCore;
using SupermarketAPI.Data;
using SupermarketAPI.Repositories;
using SupermarketAPI.Services;

namespace SupermarketAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SupermarketContext>(options =>
                options.UseMySql("Server=localhost;Database=supermarket;User=root;Password=D@viguabiraba2;",
                new MySqlServerVersion(new Version(8, 0, 21))));

            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
