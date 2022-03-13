using Addressbook.GenericRepository;
using Addressbook.Models;
using Addressbook.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AddressBookContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<IStateRepository, StateRepository>();
builder.Services.AddTransient<ICityRepository, CityRepository>();
builder.Services.AddTransient<IContactCategoryRepository, ContactCategoryRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient(typeof(ICRUDRepository<>), typeof(CRUDRepository<>));

/*
 * builder.Services.AddTransient<ICountryRepository, CountryRepository>();
 * Transient objects are always different; a new instance is provided to every controller and every service.

 * builder.Services.AddScoped<ICountryRepository, CountryRepository>();
 * Scoped objects are the same within a request, but different across different requests.

 * builder.Services.AddSingleton<ICountryRepository, CountryRepository>();
 * Singleton objects are the same for every object and every request.
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
