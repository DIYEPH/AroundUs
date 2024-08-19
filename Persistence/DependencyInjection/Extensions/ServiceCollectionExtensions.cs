using Domain.Abstractions.Entities;
using Domain.Abstractions.Repositories;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Persistence.DependencyInjection.Options;
using Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Persistence.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSqlServerPersistence(this IServiceCollection services)
        {
            services.AddDbContextPool<DbContext, ApplicationDbContext>((provider, builder) =>
            {
                //var auditableInterceptor = provider.GetService<UpdateAuditableEntitiesInterceptor>();
                var configuration = provider.GetRequiredService<IConfiguration>();
                var options = provider.GetRequiredService<IOptionsMonitor<SqlServerRetryOptions>>();

                // ---SQL-SERVER-STRATERY-1---
                builder
                .EnableDetailedErrors(true)
                .EnableSensitiveDataLogging(true)
                .UseLazyLoadingProxies(true) //If UseLazyLoadingProxies, all of the navigation fields should be VIRTUAL
                .UseSqlServer(
                    connectionString: configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptionsAction: optionsBuilder
                    => optionsBuilder.ExecutionStrategy(
                        dependencies => new SqlServerRetryingExecutionStrategy(
                            dependencies: dependencies,
                            maxRetryCount: options.CurrentValue.MaxRetryCount,
                            maxRetryDelay: options.CurrentValue.MaxRetryDelay,
                            errorNumbersToAdd: options.CurrentValue.ErrorNumbersToAdd))
                    .MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name));
                //.AddInterceptors(auditableInterceptor);
            });
            //---SQL - SERVER - STRATEGY - 2
            //builder
            //.EnableDetailedErrors(true)
            //.EnableSensitiveDataLogging(true)
            //.UseLazyLoadingProxies(true) // => If UselazyLoading Proxies, all of the navigation fields should be VIRTUAL
            //.UseSqlServer(
            // connectionString: configuration.GetConnectionString("ConnectionStrings"),

            //sqlServerOptionsAction: optionsBuilder
            //=> optionsBuilder
            //MigrationsAssembly(typeof(ApplicationDbContext) Assembly.GetName().Name));

            services.AddIdentityCore<AppUser>(options =>
            {
                //Default Lockout settings
                //options.Lockout.DefaultLockoutTimespan=Timespan.FromMinutes(5);
                //options.Lockout.MaxFailedAccessAttempts = 5;
                //options.Lockout.AllowedForNewUsers = true;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;
            })
                .AddRoles<AppRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            var passwordValidatorOptions = services.BuildServiceProvider().GetRequiredService<IOptionsMonitor<PasswordValidationOptions>>();

            services.Configure<IdentityOptions>(options =>
            {
                /*           
          Description
          RequireDigit: Requires a number between 6 - 9 in the password,
          RequiredLongth: The minimum longth of the passwore.
          RequireLowercase: Requires a lowercase character in the password.
          Requireuppercase: Requires an uppercase character in the password.
          RequireNonAlphanumeric: Requires a non - alphanumeric character in the password
          RequiredUnique Chars: (Only applies to ASP.NET Core 2.0 or later.) Requires the number of distinct characters in the
          */

                //Default Password Settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                //Or

                //options.Password.RequireDigit = passwordValidatorOptions.CurrentValue.RequiredDigitLength >= 1 ? true : false;

                //Enabling Email Configuration
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            });


        }
        public static void AddRepositoryPersistence(this IServiceCollection services)
        {
            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            services.AddTransient(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            services.AddTransient(typeof(IUnitOfWorkDbContext<>), typeof(EFUnitOfWorkDbContext<>));
            services.AddTransient(typeof(IRepositoryBaseDbContext<,,>), typeof(RepositoryBaseDbContext<,,>));

            //services.AddTransient<IProductRepository,ProductRepository>;

        }
        public static void AddInterceptorPersistence(this IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        }
        public static OptionsBuilder<SqlServerRetryOptions> ConfigureSqlServerRetryOptionsPersistence(this IServiceCollection services, IConfigurationSection section)
           => services.AddOptions<SqlServerRetryOptions>()
                .Bind(section)
                .ValidateDataAnnotations()
                .ValidateOnStart();
        public static OptionsBuilder<JWTTokenAuthentication> ConfigurationJWTTokenAuthenticationOptionsPersistence(this IServiceCollection services,IConfigurationSection section)
            => services.AddOptions<JWTTokenAuthentication>()
                .Bind(section)
                .ValidateDataAnnotations()
                .ValidateOnStart();
        public static void AddJWTAuthentication(this IServiceCollection services)
        {
            var jwtconfig = services.BuildServiceProvider().GetRequiredService<IOptionsMonitor<JWTTokenAuthentication>>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = jwtconfig.CurrentValue.ValidAudience,
                    ValidIssuer = jwtconfig.CurrentValue.ValidIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtconfig.CurrentValue.Secret))
                };
            });
        }
    }
}
