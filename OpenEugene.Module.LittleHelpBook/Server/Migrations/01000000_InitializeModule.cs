using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using OpenEugene.Module.LittleHelpBook.Migrations.EntityBuilders;
using OpenEugene.Module.LittleHelpBook.Repository;

namespace OpenEugene.Module.LittleHelpBook.Migrations
{
    [DbContext(typeof(LittleHelpBookContext))]
    [Migration("OpenEugene.Module.LittleHelpBook.01.00.00.00")]
    public class InitializeModule : MultiDatabaseMigration
    {
        public InitializeModule(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new LittleHelpBookEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Create();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new LittleHelpBookEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Drop();
        }
    }
}
