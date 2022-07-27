using GlobalTicket.TicketManagement.Api.Middleware;
using GlobalTicket.TicketManagement.Api.Services;
using GlobalTicket.TicketManagement.Api.Utility;
using GlobalTicket.TicketManagement.Application;
using GlobalTicket.TicketManagement.Application.Contracts;
using GlobalTicket.TicketManagement.Identity;
using GlobalTicket.TicketManagement.Infraestructure;
using GlobalTicket.TicketManagement.Persistence;
using Microsoft.OpenApi.Models;
using Serilog;

//var config = new ConfigurationBinder()
//    .AddJsonFile("")
//    .Build();

//Log.Logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(config)
//    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
//    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, loggerConf) =>
{
    loggerConf
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .ReadFrom.Configuration(ctx.Configuration);
});

//var services = builder.Services;

//builder.Host.ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
//{
//    var configurationRoot = configurationBuilder.Build();

//    var connectionString = configurationRoot.GetConnectionString("AzureAppConfiguration");
//    var azureAppConfigurationLabel = configurationRoot["Azure:AppConfiguration:Label"];

//    configurationBuilder.AddAzureAppConfiguration(options =>
//        options
//            .Connect(connectionString)
//            .Select("Api:*")
//            .Select("Api:*", azureAppConfigurationLabel)
//            .TrimKeyPrefix("Api:")
//    );

//    if (!azureAppConfigurationLabel.Equals("local")) return;

//    configurationBuilder.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
//    configurationBuilder.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);

//    var hostEnvironment = hostingContext.HostingEnvironment;
//    var appAssembly = Assembly.Load(new AssemblyName(hostEnvironment.ApplicationName));
//    configurationBuilder.AddUserSecrets(appAssembly, optional: true);
//});

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddInfraestructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy",
        opts =>
        {
            opts.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });

    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Global Ticket Ticket Management API"
    });

    c.OperationFilter<FileResultContentTypeOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GlobalTicket Ticket Management API");
    });
}

app.UseHttpsRedirection();

//app.UseRouting();

app.UseCustomExceptionHandler();

app.UseCors("DefaultCorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.Run();

// For Integration Tests purposes.
public partial class Program { }
