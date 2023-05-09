using AutoMapper;
using VkTask.Infrastructure.MapProfiles;
using VkTask.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using VkTask.Application.AppData.UserGroups.Repositories;
using VkTask.Application.AppData.UserGroups.Services;
using VkTask.Application.AppData.Users.Repositories;
using VkTask.Application.AppData.Users.Services;
using VkTask.Application.AppData.UserStates.Repositories;
using VkTask.Application.AppData.UserStates.Services;
using VkTask.Contracts.Users;
using VkTask.Infrastructure.DataAccess.DatabaseContext;
using VkTask.Infrastructure.DataAccess.UserGroups.Repository;
using VkTask.Infrastructure.DataAccess.Users.Repository;
using VkTask.Infrastructure.DataAccess.UserStates.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddSingleton<IDbContextOptionsConfigurator<VkTaskDbContext>, VkTaskDbContextConfiguration>();
        
builder.Services.AddDbContext<VkTaskDbContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
    ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<VkTaskDbContext>>()
        .Configure((DbContextOptionsBuilder<VkTaskDbContext>)dbOptions)));

builder.Services.AddScoped((Func<IServiceProvider, DbContext>) (sp => sp.GetRequiredService<VkTaskDbContext>()));

// Add automapper
builder.Services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

// Add repositories to the container.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserGroupRepository, UserGroupRepository>();
builder.Services.AddScoped<IUserStateRepository, UserStateRepository>();

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserGroupService, UserGroupService>();
builder.Services.AddScoped<IUserStateService, UserStateService>();

builder.Services.AddControllers();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "VkTask Api", Version = "V1" });
    options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory, $"{typeof(CreateUserDto).Assembly.GetName().Name}.xml")));
    options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory, "Documentation.xml")));
});

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

static MapperConfiguration GetMapperConfiguration()
{
    var configuration = new MapperConfiguration(cfg => 
    {
        cfg.AddProfile<UserProfile>();
        cfg.AddProfile<UserGroupProfile>();
        cfg.AddProfile<UserStateProfile>();
    });
    configuration.AssertConfigurationIsValid();
    return configuration;
}