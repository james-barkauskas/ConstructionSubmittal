using ConstructionSubmittal_API.Data;
using ConstructionSubmittal_API.Models;
using ConstructionSubmittal_API.Models.DTOs;
using ConstructionSubmittal_API.Services;
using ConstructionSubmittal_API.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>  // convert the enum integer to it's actual value.. 
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(o=>
{
    o.CreateMap<Project, ProjectCreateDTO>().ReverseMap();
    o.CreateMap<Project, ProjectUpdateDTO>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());  // tells ef core 'ignore id from the source obj'.. so don't map to the destination id
    o.CreateMap<Project, ProjectReadDTO>().ReverseMap();
    o.CreateMap<Project, Project>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());   // include for mapping in service Update method..

    o.CreateMap<Submittal, SubmittalReadDTO>().ReverseMap();
    o.CreateMap<SubmittalCreateDTO, Submittal>();   // should avoid mapping in both directions for create and update..
    o.CreateMap<SubmittalUpdateDTO, Submittal>()
        .ForMember(dest => dest.Id, opt => opt.Ignore())
        .ForMember(dest => dest.ProjectId, opt => opt.Ignore());    // tells mapper to ignore these fields when updating..
    o.CreateMap<Submittal, Submittal>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());

    o.CreateMap<Company, CompanyReadDTO>();
    o.CreateMap<CompanyUpdateDTO, Company>();
    //o.CreateMap<Company, Company>();
    o.CreateMap<CompanyCreateDTO, Company>();
});

// configure dbcontext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProjectService, ProjectService>();  // add to dependency injection container.. 'whenver a controller asks for IProjectService, give them ProjectService..
builder.Services.AddScoped<ISubmittalService, SubmittalService>();

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
