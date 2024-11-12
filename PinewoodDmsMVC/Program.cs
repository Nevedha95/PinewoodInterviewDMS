var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddSessionStateTempDataProvider();  // For MVC (adds services for TempData, Model Binding, etc.)
builder.Services.AddRazorPages();
builder.Services.AddHttpClient("clientname", client =>
{
    client.BaseAddress = new Uri("https://localhost:5033/");  // Your API base URL
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
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
    pattern: "{controller=Dealer}/{action=Index}/{id?}");

app.Run();
