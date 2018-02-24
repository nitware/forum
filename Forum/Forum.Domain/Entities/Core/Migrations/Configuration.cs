namespace Forum.Domain.Entities.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Forum.Domain.Entities.Core.EntityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Entities\Core\Migrations";
        }

        protected override void Seed(Forum.Domain.Entities.Core.EntityContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            context.Roles.AddOrUpdate(role => role.Name,
                new Role { Name = "Admin" },
                new Role { Name = "User" }
            );

            context.Categorys.AddOrUpdate(c => c.Name,
                new Category { Name = "Software Development" },
                new Category { Name = "Infrastructural Engineering" },
                new Category { Name = "Internet of Things" }
           );
        }






    }
}
