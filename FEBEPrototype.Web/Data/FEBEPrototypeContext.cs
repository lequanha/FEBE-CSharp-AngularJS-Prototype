using FEBEPrototype.Web.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FEBEPrototype.Web.Data
{
    public class FEBEPrototypeContext : ApiAuthorizationDbContext<User>
    {
        public FEBEPrototypeContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        public DbSet<Component> Components { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<ProjectComponent> ProjectComponents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            UpdateIdentityModel(builder);
            SetProjectTypes(builder);
            SetComponentEntity(builder);
            SetProjectTypeComponents(builder);

            builder.Entity<ProjectComponent>()
                .HasKey(s => new { s.ProjectId, s.ComponentId });

        }


        private void UpdateIdentityModel(ModelBuilder builder)
        {
            builder.Entity<User>()
                .ToTable("Users");

            builder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles");

            builder.Entity<IdentityUserClaim<string>>()
                .ToTable("UserClaims");

            builder.Entity<IdentityUserLogin<string>>()
                .ToTable("UserLogins");

            builder.Entity<IdentityRole>()
                .ToTable("Roles");

            builder.Entity<IdentityRoleClaim<string>>()
                .ToTable("RoleClaims");

            builder.Entity<IdentityUserToken<string>>()
                .ToTable("UserTokes");
        }

        private void SetComponentEntity(ModelBuilder builder)
        {
            builder.Entity<Component>()
                .Property(e => e.Id).ValueGeneratedNever();

            builder.Entity<Component>()
                .HasData(
                    new Component()
                    {
                        Id = 1,
                        Name = "JupyterHub",
                        Description = "JupyterHub Description"
                    },
                    new Component()
                    {
                        Id = 2,
                        Name = "PostgreSQL",
                        Description = "PostgreSQL Description"
                    },
                    new Component()
                    {
                        Id = 3,
                        Name = "SuperSet",
                        Description = "SuperSet Description"
                    }
                );
        }

        private void SetProjectTypes(ModelBuilder builder)
        {
            builder.Entity<ProjectType>()
                .Property(e => e.Id).ValueGeneratedNever();

            builder.Entity<ProjectType>()
                .HasData(
                    new ProjectType()
                    {
                        Id = 1,
                        Name = "Data Exploration",
                        Description = "I'm looking to explore data and visualize it for insight"
                    },
                    new ProjectType()
                    {
                        Id = 2,
                        Name = "Develop ML Pipeline",
                        Description = "I'm developing end to end machine learning pipeline(test, develop, deploy)"
                    },
                    new ProjectType()
                    {
                        Id = 3,
                        Name = "Develop DL Pipeline",
                        Description = "I'm developing end to end deep learning pipeline(text, develop, deploy)"
                    }
                );
        }

        private void SetProjectTypeComponents(ModelBuilder builder)
        {
            builder.Entity<ProjectTypeComponent>()
                .HasKey(s => new { s.ProjectTypeId, s.ComponentId });


            builder.Entity<ProjectTypeComponent>()
                .HasData(
                    new ProjectTypeComponent() { ProjectTypeId = 1, ComponentId = 1 },
                    new ProjectTypeComponent() { ProjectTypeId = 1, ComponentId = 2 },
                    new ProjectTypeComponent() { ProjectTypeId = 1, ComponentId = 3 },
                    new ProjectTypeComponent() { ProjectTypeId = 2, ComponentId = 1 },
                    new ProjectTypeComponent() { ProjectTypeId = 2, ComponentId = 2 },
                    new ProjectTypeComponent() { ProjectTypeId = 3, ComponentId = 1 },
                    new ProjectTypeComponent() { ProjectTypeId = 3, ComponentId = 2 }
                );

        }
    }
}
