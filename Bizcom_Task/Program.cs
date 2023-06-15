using Bizcom_Task;
using Bizcom_Task.Extensions;
using Entities.DTO.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseSqlite("Data Source = APPDB").UseLazyLoadingProxies();
    });

builder.Services.ConfigurationRepository();
builder.Services.ConfigurationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Description = "Enter like this: Bearer mkdfmlkmdflmdklfmdklfmkdfmdfdf",
        Name = "Authorization",
        Scheme = "Bearer",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        { new OpenApiSecurityScheme()
        {
            Reference = new OpenApiReference()
            {
                Id = "Bearer",
                Type = ReferenceType.SecurityScheme,
            },
        },
      Array.Empty<string>()
        }
    });
}
);


//JWT
IConfiguration appsettings = builder.Configuration.GetSection("Appsettings");
builder.Services.Configure<AppSettings>(appsettings);
AppSettings settings = appsettings.Get<AppSettings>();
var secretkey = System.Text.Encoding.UTF8.GetBytes(settings.SecretKey);

builder.Services.AddAuthentication(
    x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.SaveToken = true;
        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(secretkey),
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuer = false,
        };
    }


    // x.RequireHttpsMetadata = true  request https dan yuboroilsagina qabul qiladi
    );
//**********************************

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
