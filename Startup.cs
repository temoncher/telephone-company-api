using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SqlBackend.Data;

namespace SqlBackend
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
      services.AddCors((options) => options.AddPolicy("NoPolicy", builder =>
      {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
      }));

      services.AddDbContext<SubscriberContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlBackendAPIConnection")));
      services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlBackendAPIConnection")));
      services.AddDbContext<OrganisationContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlBackendAPIConnection")));
      services.AddDbContext<TransactionTypeContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlBackendAPIConnection")));
      services.AddDbContext<TransactionContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SqlBackendAPIConnection")));

      services.AddControllers();

      services.AddScoped<ISubscriberRepository, SubscriberRepository>();
      services.AddScoped<IDatabaseRepository, DatabaseRepository>();
      services.AddScoped<IOrganisationRepository, OrganisationRepository>();
      services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
      services.AddScoped<ITransactionRepository, TransactionRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseCors("NoPolicy");

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
