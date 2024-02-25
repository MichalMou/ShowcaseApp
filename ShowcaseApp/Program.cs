using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShowcaseApp.Areas.Identity.Data;
using ShowcaseApp.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ShowcaseAppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ShowcaseAppDbContextConnection' not found.");

builder.Services.AddDbContext<ShowcaseAppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ShowcaseAppDbContext>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 9;
});

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
