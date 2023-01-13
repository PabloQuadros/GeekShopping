using GeekShopping.web.Services.IServices;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IProductService, ProductService>(c=> c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ProductAPI"]));
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options => 
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";

})
    .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = builder.Configuration["ServiceUrls:IdentityServer"];
        options.GetClaimsFromUserInfoEndpoint = true;
        options.ClientId = "geek_shopping";
        options.ClientSecret = "my_super_secret";
        options.ResponseType = "code";
        options.ClaimActions.MapJsonKey("role","role","role");
        options.ClaimActions.MapJsonKey("sub","sub","sup");
        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.RoleClaimType = "role";
        options.Scope.Add("geek_shopping");
        options.SaveTokens = true;
    });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://localhost:4440;http://localhost:4441;https://localhost:4435;http://localhost:4436").AllowAnyHeader().AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();