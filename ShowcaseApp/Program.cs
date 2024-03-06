using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ShowcaseApp.Areas.Identity.Data;
using ShowcaseApp.Data;
using ShowcaseApp.Data.Model;
using ShowcaseApp.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ShowcaseAppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ShowcaseAppDbContextConnection' not found.");

builder.Services.AddDbContext<ShowcaseAppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ShowcaseAppDbContext>();

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapRazorPages(); // Maps Razor Pages
	endpoints.MapControllerRoute( // Maps controller actions
		name: "default",
		pattern: "{controller=Client}/{action=MyIndex}");
});

app.Run();
