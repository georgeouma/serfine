using Microsoft.OpenApi.Models;
using Serfine.PublicAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
// Configure AppSetting
builder.ConfigureAppSettings();
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo()
        {
            Title = builder.Configuration["Swagger:Title"],
            Description = builder.Configuration["Swagger:Description"],
            Version = builder.Configuration["Swagger:Version"],
            Contact = new OpenApiContact()
            {
                Name = builder.Configuration["Swagger:Contact:Name"],
                Email = builder.Configuration["Swagger:Contact:Email"]
            }
        });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below. 
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
    c.EnableAnnotations();
});
builder.Services.ConfigureSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerExtension();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();