using Microsoft.AspNetCore.Authentication.Cookies;
using Spotify_Api.Builder;
using Spotify_Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Spotify", policy =>
    {
        policy.AuthenticationSchemes.Add("Spotify");
        policy.RequireAuthenticatedUser();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IArtistService, ArtistService>();
builder.Services.AddSingleton<ISpotifyClientBuilder, SpotifyClientBuilder>();
builder.Services
    .AddAuthentication(options => { options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; })
    .AddCookie(options => { options.ExpireTimeSpan = TimeSpan.FromMinutes(50); })
    .AddSpotify(options =>
    {
        options.ClientId = builder.Configuration["Spotify:SPOTIFY_CLIENT_ID"];
        options.ClientSecret = builder.Configuration["Spotify:SPOTIFY_CLIENT_SECRET"];
        options.CallbackPath = "/Auth/callback";
        options.SaveTokens = true;

        var scopes = new List<string>
        {
            "playlist-read-private", "playlist-read-collaborative", "user-top-read"
        };
        options.Scope.Add(string.Join(",", scopes));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();