using System.Net.Http.Headers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
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

      services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

      services.AddDbContext<SubscriberContext>((serviceProvider, options) =>
      {
        var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
        options.UseSqlServer(Configuration.GetConnectionString(GetConnection(httpContext)));
      });
      services.AddDbContext<DatabaseContext>((serviceProvider, options) =>
      {
        var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
        options.UseSqlServer(Configuration.GetConnectionString(GetConnection(httpContext)));
      });
      services.AddDbContext<OrganisationContext>((serviceProvider, options) =>
      {
        var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
        options.UseSqlServer(Configuration.GetConnectionString(GetConnection(httpContext)));
      });
      services.AddDbContext<TransactionTypeContext>((serviceProvider, options) =>
      {
        var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
        options.UseSqlServer(Configuration.GetConnectionString(GetConnection(httpContext)));
      });
      services.AddDbContext<TransactionContext>((serviceProvider, options) =>
      {
        var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
        options.UseSqlServer(Configuration.GetConnectionString(GetConnection(httpContext)));
      });
      services.AddDbContext<DaytimeContext>((serviceProvider, options) =>
      {
        var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
        options.UseSqlServer(Configuration.GetConnectionString(GetConnection(httpContext)));
      });
      services.AddDbContext<LocalityContext>((serviceProvider, options) =>
      {
        var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
        options.UseSqlServer(Configuration.GetConnectionString(GetConnection(httpContext)));
      });
      services.AddDbContext<PriceContext>((serviceProvider, options) =>
      {
        var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
        options.UseSqlServer(Configuration.GetConnectionString(GetConnection(httpContext)));
      });
      services.AddDbContext<DaytimePriceContext>((serviceProvider, options) =>
      {
        var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
        options.UseSqlServer(Configuration.GetConnectionString(GetConnection(httpContext)));
      });
      services.AddDbContext<CallContext>((serviceProvider, options) =>
      {
        var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
        options.UseSqlServer(Configuration.GetConnectionString(GetConnection(httpContext)));
      });
      services.AddDbContext<AccountContext>((serviceProvider, options) =>
      {
        var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
        options.UseSqlServer(Configuration.GetConnectionString(GetConnection(httpContext)));
      });

      services.AddControllers();

      services.AddScoped<ISubscriberRepository, SubscriberRepository>();
      services.AddScoped<IDatabaseRepository, DatabaseRepository>();
      services.AddScoped<IOrganisationRepository, OrganisationRepository>();
      services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
      services.AddScoped<ITransactionRepository, TransactionRepository>();
      services.AddScoped<IDaytimeRepository, DaytimeRepository>();
      services.AddScoped<ILocalityRepository, LocalityRepository>();
      services.AddScoped<IPriceRepository, PriceRepository>();
      services.AddScoped<IDaytimePriceRepository, DaytimePriceRepository>();
      services.AddScoped<ICallRepository, CallRepository>();
      services.AddScoped<IAccountRepository, AccountRepository>();
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

    private string GetConnection(HttpContext httpContext)
    {
      var httpRequest = httpContext.Request;
      string connectionName = "ManagerConnection";
      try
      {
        var auth = AuthenticationHeaderValue.Parse(httpRequest.Headers[HeaderNames.Authorization]);

        if (auth.Parameter == "Super")
        {
          connectionName = "SqlBackendAPIConnection";
        }

        if (auth.Parameter == "Admin")
        {
          connectionName = "AdminConnection";
        }
      }
      catch { }

      return connectionName;
    }
  }
}
