
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using R1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();

builder.Services.AddDbContextPool<R1DbContext>(options =>
options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("R1DbContext")));

builder.Services.AddScoped<IRestaurantData, SqlRestaurantData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();
app.UseHttpsRedirection();
app.UseNodeModules();
app.UseCookiePolicy();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath,"node_modules")),
    RequestPath = "/node_modules"
});

