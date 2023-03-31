using Autofac.Extensions.DependencyInjection;
using Autofac;
using BusinessLayer.Mapping;
using BusinessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitOfWorks;
using EntityLayer.Repositories;
using EntityLayer.Services;
using EntityLayer.UnitOfWorks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieRecommendation.API.Filter;
using MovieRecommendation.BusinessLayer.Services;
using MovieRecommendation.BusinessLayer.Validations;
using MovieRecommendation.DataAccessLayer.Repositories;
using MovieRecommendation.EntityLayer.Repositories;
using MovieRecommendation.EntityLayer.Services;
using MovieRecommendation.ScheduleLayer;
using Quartz;
using System.Reflection;
using System.Text;
using MovieRecommendation.API.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Token:Issuer"],
            ValidAudience = builder.Configuration["Token:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            ClockSkew = TimeSpan.Zero
        };

    });

builder.Services.AddControllers();

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<MovieScoreDtoValidator>());
builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UserCreateDtoValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(
                                                                       new RepositoryServiceModule()));
//builder.Services.AddQuartz(q =>
//{
//    q.UseMicrosoftDependencyInjectionScopedJobFactory();
//    var jobKey = new JobKey("GetMoviesDaily");
//    q.AddJob<GetMoviesDaily>(opts => opts.WithIdentity(jobKey));

//    q.AddTrigger(opts => opts
//        .ForJob(jobKey)
//        .WithIdentity("GetMoviesDaily-trigger")
//        .WithCronSchedule("0 0/1 * 1/1 * ? *")); //günlük gece saat 4 de getiren => 0 0 4 1/1 * ? *
//    //.WithCronSchedule("0 0/1 * 1/1 * ? *")); test etmek için 1 dk arayla olanı deneyebilirsiniz.
//    //Ancak daha kısa olmasın çünkü daha kısa olursa quartz hızlı çalıştığı için aynı data çoklanıyor.

//});
//builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
