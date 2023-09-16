using Microsoft.EntityFrameworkCore;
using PawPoint.API.Mapper;
using PawPoint.Domain;
using PawPoint.Domain.Interfaces;
using PawPoint.Infraestructure;
using PawPoint.Infraestructure.Context;
using PawPoint.Infraestructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserInfraestructure, UserInfraestructure>();
builder.Services.AddScoped<IUserDomain, UserDomain>();

builder.Services.AddScoped<IVeterinaryInfraestructure, VeterinaryInfraestructure>();
builder.Services.AddScoped<IVeterinaryDomain, VeterinaryDomain>();

builder.Services.AddScoped<IPetInfraestructure, PetInfraestructure>();
builder.Services.AddScoped<IPetDomain, PetDomain>();

builder.Services.AddScoped<IMeetingInfraestructure, MeetingInfraestructure>();
builder.Services.AddScoped<IMeetingDomain, MeetingDomain>();

builder.Services.AddScoped<IProductInfraestructure, ProductInfraestructure>();
builder.Services.AddScoped<IProductDomain, ProductDomain>();

builder.Services.AddScoped<IReviewInfraestructure, ReviewInfraestructure>();
builder.Services.AddScoped<IReviewDomain, ReviewDomain>();

builder.Services.AddScoped<IServiceInfraestructure, ServiceInfraestructure>();
builder.Services.AddScoped<IServiceDomain, ServiceDomain>();


//Conexion a sql
var connectionString = builder.Configuration.GetConnectionString("VetDB");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddAutoMapper(
    typeof(ModelToResponse),
    typeof(InputToModel));

builder.Services.AddDbContext<VetDbContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<VetDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();