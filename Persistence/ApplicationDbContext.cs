using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public sealed class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

            //builder.Entity<ISoftDelete>().HasQueryFilter(x=>!x.IsDelete);
            //builder.Entity<ISoftDelete>().HasIndex(x => x.IsDelete).HasFilter("is_deleted=0");
            /* var softDeleteEntities = typeof(ISoftDelete).Assembly.GetTypes()
                 .Where(type => typeof(ISoftDelete).IsAssignableFrom(type) && type.IsClass && type.IsAbstract);
             foreach (var softDeleteEntity in softDeleteEntities)
             {
                 builder.Entity(softDeleteEntity).HasQueryFilter(GenerateQueryFilterLambda(softDeleteEntity));
             }*/
        }

        /* private LambdaExpression GenerateQueryFilterLambda(Type type)
         {
             //parameter: "w=>"
             var parameter = Expression.Parameter(type, "w");
             //falseConstantValue: false
             var falseConstantValue = Expression.Constant(false);
             //protertyAccess: "w.IsDeleted"
             var propertyAccess = Expression.PropertyOrField(parameter, nameof(ISoftDelete.IsDelete));
             //equalExpression: "w.IsDeleted=false"
             var equalExpression = Expression.Equal(propertyAccess, falseConstantValue);
             //lamda:"w=>w.Deleted=false"
             var lamda = Expression.Lambda(equalExpression, parameter);
             return lamda;
         }*/


    }
}
