using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;
using IdentityModel;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Rental_House_Backend.Data;
using Rental_House_Backend.Models;
using Rental_House_Backend.Services;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("RentalHousesDatabase");
builder.Services.AddDbContext<RentalHouseDbContext>(options =>

    options.UseSqlServer(connectionString));


builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<RentalHouseDbContext>();

builder.Services.AddIdentityServer()


    .AddApiAuthorization<ApplicationUser, RentalHouseDbContext>()
    .AddDeveloperSigningCredential()
    .AddInMemoryApiScopes(MyApiResourceProvider.ApiScopes)
     .AddInMemoryApiResources(MyApiResourceProvider.ApiResources)
     .AddInMemoryClients(new[]
        {
        new Duende.IdentityServer.Models.Client
        {
            ClientId = "myClient",
            ClientName = "My Custom Client",
            AccessTokenLifetime = 60 * 60 * 24,
              ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },
            AllowedGrantTypes = new string[]{GrantType.Implicit },
            RequireClientSecret = false,
              AllowedScopes =
            {
                "myAPIs"
            }
        }})
     .AddTestUsers(new List<Duende.IdentityServer.Test.TestUser> { new Duende.IdentityServer.Test.TestUser {
                        SubjectId = "1",
                        Username = "alice",
                        Password = "alice",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Alice Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Alice"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(new
                {
                    street_address = "One Hacker Way",
                    locality = "Heidelberg",
                    postal_code = 69118,
                    country = "Germany"
                }), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    },})
     ;




builder.Services.AddAuthentication()
    .AddIdentityServerJwt();
builder.Services.Configure<JwtBearerOptions>(
    IdentityServerJwtConstants.IdentityServerJwtBearerScheme,
    options =>
    {
        var onTokenValidated = options.Events.OnTokenValidated;

        options.Events.OnTokenValidated = async context =>
        {
            await onTokenValidated(context);
        };
    });


builder.Services.AddCors(options =>
{
    // this defines a CORS policy called "default"
    options.AddPolicy("default", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<IRequestRepairService, RequestRepairService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddSingleton<IClientStore, CustomClientStore>();
builder.Services.AddScoped<IAccountService, AccountService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("default");
app.UseIdentityServer();


app.UseAuthorization();


app.MapControllers();
app.MapRazorPages();

app.Run();


