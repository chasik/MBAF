namespace mba_model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ColumnHeaders", "GoodColumn_Id", "dbo.GoodColumns");
            DropIndex("dbo.ColumnHeaders", new[] { "GoodColumn_Id" });
            RenameColumn(table: "dbo.ColumnHeaders", name: "GoodColumn_Id", newName: "GoodColumnId");
            AlterColumn("dbo.ColumnHeaders", "GoodColumnId", c => c.Int(nullable: false));
            CreateIndex("dbo.ColumnHeaders", "GoodColumnId");
            AddForeignKey("dbo.ColumnHeaders", "GoodColumnId", "dbo.GoodColumns", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ColumnHeaders", "GoodColumnId", "dbo.GoodColumns");
            DropIndex("dbo.ColumnHeaders", new[] { "GoodColumnId" });
            AlterColumn("dbo.ColumnHeaders", "GoodColumnId", c => c.Int());
            RenameColumn(table: "dbo.ColumnHeaders", name: "GoodColumnId", newName: "GoodColumn_Id");
            CreateIndex("dbo.ColumnHeaders", "GoodColumn_Id");
            AddForeignKey("dbo.ColumnHeaders", "GoodColumn_Id", "dbo.GoodColumns", "Id");
        }
    }
}
