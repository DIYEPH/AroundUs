
using Persistence.DependencyInjection.Extensions;
using Persistence.DependencyInjection.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
///

//SqlServer
builder.Services.ConfigureSqlServerRetryOptionsPersistence(builder.Configuration.GetSection(nameof(SqlServerRetryOptions)));
builder.Services.AddSqlServerPersistence();

//Authentication
builder.Services.ConfigurationJWTTokenAuthenticationOptionsPersistence(builder.Configuration.GetSection(nameof(JWTTokenAuthentication)));
builder.Services.AddJWTAuthentication();

//Repository
builder.Services.AddRepositoryPersistence();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
