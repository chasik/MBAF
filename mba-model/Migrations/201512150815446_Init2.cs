namespace mba_model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User_Action",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        ActionId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.UserId, t.ActionId })
                .ForeignKey("dbo.Actions", t => t.ActionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ActionId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        FullName = c.String(),
                        Email = c.String(),
                        Photo = c.Binary(),
                        Freezed = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Name = c.String(),
                        ScreenName = c.String(),
                        Tooltip = c.String(),
                        Image = c.String(),
                        CommandParam = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ScreenName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        InnerId = c.Int(nullable: false),
                        Name = c.String(),
                        FullName = c.String(),
                        Image = c.String(),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        Deleted = c.DateTime(precision: 7, storeType: "datetime2"),
                        DeletedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ColumnHeader_Client",
                c => new
                    {
                        ColumnHeaderId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        Changed = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.ColumnHeaderId, t.ClientId })
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.ColumnHeaders", t => t.ColumnHeaderId, cascadeDelete: true)
                .Index(t => t.ColumnHeaderId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.ColumnHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GoodColumns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        Deleted = c.DateTime(precision: 7, storeType: "datetime2"),
                        DeletedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImportTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ClientId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.Int(nullable: false),
                        Deleted = c.DateTime(precision: 7, storeType: "datetime2"),
                        DeletedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.RolePermissions",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        Permission_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Permission_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Permissions", t => t.Permission_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Permission_Id);
            
            CreateTable(
                "dbo.RoleUsers",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.User_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.PermissionUsers",
                c => new
                    {
                        Permission_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Permission_Id, t.User_Id })
                .ForeignKey("dbo.Permissions", t => t.Permission_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Permission_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.ColumnHeader_Client", "ColumnHeaderId", "dbo.ColumnHeaders");
            DropForeignKey("dbo.ColumnHeader_Client", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.User_Action", "UserId", "dbo.Users");
            DropForeignKey("dbo.PermissionUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.PermissionUsers", "Permission_Id", "dbo.Permissions");
            DropForeignKey("dbo.RoleUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RoleUsers", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.RolePermissions", "Permission_Id", "dbo.Permissions");
            DropForeignKey("dbo.RolePermissions", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.User_Action", "ActionId", "dbo.Actions");
            DropIndex("dbo.PermissionUsers", new[] { "User_Id" });
            DropIndex("dbo.PermissionUsers", new[] { "Permission_Id" });
            DropIndex("dbo.RoleUsers", new[] { "User_Id" });
            DropIndex("dbo.RoleUsers", new[] { "Role_Id" });
            DropIndex("dbo.RolePermissions", new[] { "Permission_Id" });
            DropIndex("dbo.RolePermissions", new[] { "Role_Id" });
            DropIndex("dbo.Projects", new[] { "ClientId" });
            DropIndex("dbo.ColumnHeader_Client", new[] { "ClientId" });
            DropIndex("dbo.ColumnHeader_Client", new[] { "ColumnHeaderId" });
            DropIndex("dbo.User_Action", new[] { "ActionId" });
            DropIndex("dbo.User_Action", new[] { "UserId" });
            DropTable("dbo.PermissionUsers");
            DropTable("dbo.RoleUsers");
            DropTable("dbo.RolePermissions");
            DropTable("dbo.Projects");
            DropTable("dbo.ImportTypes");
            DropTable("dbo.GoodColumns");
            DropTable("dbo.ColumnHeaders");
            DropTable("dbo.ColumnHeader_Client");
            DropTable("dbo.Clients");
            DropTable("dbo.Roles");
            DropTable("dbo.Permissions");
            DropTable("dbo.Users");
            DropTable("dbo.User_Action");
            DropTable("dbo.Actions");
        }
    }
}
