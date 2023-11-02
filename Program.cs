using HotChocolate.AspNetCore;
using Personal.GraphQLDemo.API.Schema;
using Personal.GraphQLDemo.API.Schema.CourseMutation;
using Personal.GraphQLDemo.API.Services;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Personal.GraphQLDemo.API.Repository;
using Personal.GraphQLDemo.API.DataLoader;
using Microsoft.Extensions.Configuration;

internal class Program
{



    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddGraphQLServer().AddQueryType<Query>();
        builder.Services.AddGraphQLServer().AddMutationType<CourseMutation>();
        builder.Services.AddGraphQLServer().AddFiltering();
        
        // builder.Services.AddGraphQLServer().AddSubscriptionType();
        //  builder.Services.AddGraphQLServer().AddInMemorySubscriptions();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        //builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();
        //builder.Services.AddEndpointsApiExplorer();
      

        builder.Services.AddPooledDbContextFactory<CampusDBContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

        });
        builder.Services.AddScoped<CourseRepository>();
        builder.Services.AddScoped<InstructorRepository>();
        builder.Services.AddScoped<InstructorDataLayer>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI();
        //}
        //using (var scope = app.Services.CreateScope())
        //{
        //    IDbContextFactory<CampusDBContext> contextFactory =
        //        scope.ServiceProvider.GetRequiredService<IDbContextFactory<CampusDBContext>>();
        //    using(CampusDBContext context=contextFactory.CreateDbContext())
        //    {
        //        context.Database.Migrate();
        //    }
        //    //var dataContext = scope.ServiceProvider.GetRequiredService<CampusDBContext>();
        //    //dataContext.Database.Migrate();
        //}
        //app.UseHttpsRedirection();
        app.UseRouting();
        //app.UseAuthorization();
        //app.UseWebSockets();
        //app.MapControllers();
        app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });


        app.Run();
    }
}