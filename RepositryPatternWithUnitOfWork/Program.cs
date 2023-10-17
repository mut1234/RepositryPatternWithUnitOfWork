using MediatR;
using Microsoft.EntityFrameworkCore;
using RepoPattrenWithUnitOfWork.Core;
using RepoPattrenWithUnitOfWork.Core.CQRS.Querys.Author;
using RepoPattrenWithUnitOfWork.Core.Interface;
using RepoPattrenWithUnitOfWork.Core.Interface.Service;
using RepoPattrenWithUnitOfWork.Core.Service;
using RepoPattrenWithUnitOfWork.EF;
using RepoPattrenWithUnitOfWork.EF.Reposiories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(o =>
o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
b=>b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


//builder.Services.AddTransient(typeof(IBaseRepository<>),typeof(BaseRepository<>));//register to baserepo inside api
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IAuthorService, AuthorService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(Assembly.GetAssembly(typeof(GetByIdAuthorQuery)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
