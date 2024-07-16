using ApiCrudTest.Data;
using ApiCrudTest.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

//SQL CX
builder.Services.AddSingleton<IDbContextFactory, DbContextFactory>();

//INTERFACES
builder.Services.AddSingleton<IStoreRepository, StoreRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IStoreProductMappingRepository, StoreProductMappingRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
