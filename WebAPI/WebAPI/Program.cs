using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Data;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebAPIContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeAppCon")));

//Enable CORS
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", opts => opts
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

});

//JSON Serializer

builder.Services.AddControllersWithViews().AddNewtonsoftJson(opt=>
                                        opt.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                                        .AddNewtonsoftJson(op=>op.SerializerSettings.ContractResolver=
                                            new DefaultContractResolver());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

//Enables CORS
app.UseCors(opts => opts.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(),"Photos")),
                    RequestPath="/Photos"
});

app.UseAuthorization();
app.MapControllers();


app.Run();
