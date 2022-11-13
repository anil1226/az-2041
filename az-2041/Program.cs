using az_2041.Services;
using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

var constring = "Endpoint=https://az204conf.azconfig.io;Id=XxOU-li-s0:neO7tm7s7cy61EkNcwgR;Secret=IB1BZ3s7KzllKu3kW/O0MAFDqMu2Px+ghoT+ay88Ggk=";

builder.Host.ConfigureAppConfiguration(builder =>
{
    builder.AddAzureAppConfiguration(Options=>Options.Connect(constring).UseFeatureFlags());
});

builder.Services.AddTransient<IProductService,ProductService>();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddFeatureManagement();

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
