
using Microsoft.EntityFrameworkCore;

using Personal.GraphQLDemo.API.Schema.CourseMutation;
using Personal.GraphQLDemo.API.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Personal.GraphQLDemo.API;

public class Startup
{


    public Startup(IConfiguration configuration)
        => Configuration = configuration;
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {

       // var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        services.AddControllers();

       services.AddGraphQLServer().AddQueryType<Query>();
       //services.AddGraphQLServer().AddMutationType<CourseMutation>();
      // services.AddGraphQLServer().AddSubscriptionType();
     //  services.AddGraphQLServer().AddInMemorySubscriptions();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        //builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();
        //builder.Services.AddEndpointsApiExplorer();

        string? ConnectionString = Configuration.GetConnectionString("Default");
       services.AddPooledDbContextFactory<CampusDBContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

        });

       



    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
    ILogger<Startup> logger)
    {



        app.UseRouting();
        //app.UseAuthorization();
        app.UseWebSockets();
        //app.MapControllers();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGraphQL();
        });


       
    }




}
