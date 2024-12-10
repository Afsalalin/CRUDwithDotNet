using CRUDwithADONet.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register Employee_DAL as a scoped service.
builder.Services.AddScoped<Employee_DAL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Use Developer Exception Page to display detailed error information during development
    app.UseDeveloperExceptionPage();
}
else
{
    // In non-development environments, use a generic error handler
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Apply HSTS for security in production
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseRouting();          // Enable routing

app.UseAuthorization();    // Use authorization middleware

// Map static assets (e.g., CSS, JS, images)
app.MapStaticAssets();

// Map the default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();


