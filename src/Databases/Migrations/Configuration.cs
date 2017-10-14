using System.Data.Entity.Migrations;

namespace Databases.Migrations
{
    public class Configuration : DbMigrationsConfiguration<DataBaseSQL>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }


    }
}
