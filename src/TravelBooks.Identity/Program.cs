var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
Log.Logger = CreateSerilogLogger();

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddContextApplicationDI(configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerServiceDI();
builder.Services.AddJwtServiceDI(configuration);
builder.Services.AddOptionServiceDI(configuration);
builder.Services.AddServiceApplicationDI();

builder.Services.AddHealthChecks();

builder.Services.AddTransient(sp =>
{
    var logger = sp.GetService<ILogger<InitializerDatabase>>();
    var contextdb = sp.GetService<TravelBooksIdentityContext>();
    var encrypt = sp.GetService<IEncryptService>();
    return ActivatorUtilities.CreateInstance<InitializerDatabase>(sp, contextdb!, logger!);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    using var scope = app.Services.CreateScope();
    var service = scope.ServiceProvider;
    var initializer = service.GetRequiredService<InitializerDatabase>();
    await initializer.Run(default);
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health",
    new HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.MapHealthChecks("/liveness",
    new HealthCheckOptions
    {
        Predicate = response => response.Name.Contains("selft")
    });                                  


app.Run();


static Serilog.ILogger CreateSerilogLogger() => new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .Enrich.WithProperty("ApplicationContext", typeof(Program).Namespace)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("identitylogger.txt",
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
        .CreateLogger();