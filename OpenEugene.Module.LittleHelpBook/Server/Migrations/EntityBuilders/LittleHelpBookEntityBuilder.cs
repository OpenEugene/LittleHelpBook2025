using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace OpenEugene.Module.LittleHelpBook.Migrations.EntityBuilders
{
    public class LittleHelpBookEntityBuilder : AuditableBaseEntityBuilder<LittleHelpBookEntityBuilder>
    {
        private const string _entityTableName = "OpenEugeneLittleHelpBook";
        private readonly PrimaryKey<LittleHelpBookEntityBuilder> _primaryKey = new("PK_OpenEugeneLittleHelpBook", x => x.LittleHelpBookId);
        private readonly ForeignKey<LittleHelpBookEntityBuilder> _moduleForeignKey = new("FK_OpenEugeneLittleHelpBook_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public LittleHelpBookEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override LittleHelpBookEntityBuilder BuildTable(ColumnsBuilder table)
        {
            LittleHelpBookId = AddAutoIncrementColumn(table,"LittleHelpBookId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> LittleHelpBookId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
