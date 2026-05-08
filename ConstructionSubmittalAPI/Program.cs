using ConstructionSubmittal_API.Data;
using ConstructionSubmittal_API.Models;
using ConstructionSubmittal_API.Models.DTOs;
using ConstructionSubmittal_API.Services;
using ConstructionSubmittal_API.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(o=>
{
    o.CreateMap<Project, ProjectCreateDTO>().ReverseMap();
    o.CreateMap<Project, ProjectUpdateDTO>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());  // tells ef core 'ignore id from the source obj'.. so don't map to the destination id
    o.CreateMap<Project, ProjectReadDTO>().ReverseMap();
    o.CreateMap<Project, Project>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());   // include for mapping in service Update method..
});

// configure dbcontext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProjectService, ProjectService>();  // add to dependency injection container.. 'whenver a controller asks for IProjectService, give them ProjectService..


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
