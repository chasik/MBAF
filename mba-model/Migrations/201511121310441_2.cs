namespace mba_model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Permissions", "CommandParam", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Permissions", "CommandParam");
        }
    }
}
