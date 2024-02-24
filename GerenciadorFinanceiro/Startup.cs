using GerenciadorFinanceiro.Data;
using GerenciadorFinanceiro.Repositories.Categorias;
using GerenciadorFinanceiro.Repositories.Transacoes;
using GerenciadorFinanceiro.Services.Transacoes;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorFinanceiro
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "FilmesAPI", Version = "v1" });
            });
            services.AddDbContext<AppDbContext>(opts => opts.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("GerenciaConnection")));
            services.AddControllers();
            
            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                });
            });

            ConfigureDependency(services);
        }

        private void ConfigureDependency(IServiceCollection services)
        {
            #region Transacoes
            services.AddScoped<ITransacoesService, TransacoesService>();
            services.AddScoped<ITransacoesRepository, TransacoesRepository>();
            #endregion

            #region Categorias
            services.AddScoped<ICategoriasRepository, CategoriasRepository>();
            #endregion
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Filmes Api"));
            }

            app.UseRouting();

            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

