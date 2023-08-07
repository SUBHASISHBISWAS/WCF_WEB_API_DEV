using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(configure =>
        configure.JsonSerializerOptions.PropertyNamingPolicy = null);

// create an HttpClient used for accessing the API
builder.Services.AddHttpClient("APIClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ImageGalleryAPIRoot"]);
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
});

builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme).
AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, option =>
{
    option.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

    option.Authority = "https://localhost:5001/";
    option.ClientId = "imagegalleryclient";
    option.ClientSecret = "secret";
    option.ResponseType = "code";
    option.Scope.Add("openid");
    option.Scope.Add("profile");
    option.CallbackPath = new PathString("/signin-oidc");
    option.SaveTokens = true;
    // SignedOutCallbackPath: default = host :port/signout-callback-oidc.
    // Must match with the post logout redirect URI at IDP client config if 
    // you want to automatically return to the application after logging out of IdentityServer.
    // To change, set SignedOutCallbackPath
    // eg: SignedOutCallbackPath = "pathaftersignout"
    //option.SignedOutCallbackPath()
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Gallery}/{action=Index}/{id?}");

app.Run();
