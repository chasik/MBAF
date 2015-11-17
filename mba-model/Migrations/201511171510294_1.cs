namespace mba_model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImportTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        ScreenName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImportTypes");
        }
    }
}
