using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using MVCDemo.Models;
using MVCDemo.Services;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
///  Register 
builder.Services.AddScoped<IScopedProductService, ScopedProductService>();
builder.Services.AddSingleton<ISingleToneProductService, SingleToneProductService>();
builder.Services.AddTransient<ItransantProductService, transantProductService>();

//.Services.AddDbContext<ApplicationContext>(a => { a.UseSqlServer(""); }, ServiceLifetime.Scoped); ; ; ;
// Container 
//builder.Services.AddScoped<IProductService,ScopedProduct2Service>();
//builder.Services.AddSingleton<IProductService, SingleToneProduct2Service>();
//builder.Services.AddTransient<IProductService, transantProduct2Service>();

builder.Services.AddFluentValidation(f =>
{
    f.RegisterValidatorsFromAssemblyContaining<Program>(); 
});







builder.Services.AddDbContext<ApplicationContext>(ServiceLifetime.Singleton); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();
app.UseHttpsRedirection();  //  http >>  https 

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(@"D:\images\"),
    RequestPath = "/avatars"
});



app.UseAuthorization();




app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
