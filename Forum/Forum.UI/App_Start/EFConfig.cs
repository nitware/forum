using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Forum.UI.App_Start
{
    public static class EFConfig
    {
        public static void Initialize()
        {
            RunMigrations();
        }
        private static void RunMigrations()
        {
            var efMigrationSettings = new Domain.Entities.Core.Migrations.Configuration();
            var efMigrator = new DbMigrator(efMigrationSettings);
            efMigrator.Update();
        }


    }
}