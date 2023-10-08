namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_admingncllme_mig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "Role_RoleId", "dbo.AdminRoles");
            DropIndex("dbo.Admins", new[] { "Role_RoleId" });
            AlterColumn("dbo.Admins", "AdminRole", c => c.String());
            DropColumn("dbo.Admins", "Role_RoleId");
            DropTable("dbo.AdminRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AdminRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleAd = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.Admins", "Role_RoleId", c => c.Int());
            AlterColumn("dbo.Admins", "AdminRole", c => c.Int(nullable: false));
            CreateIndex("dbo.Admins", "Role_RoleId");
            AddForeignKey("dbo.Admins", "Role_RoleId", "dbo.AdminRoles", "RoleId");
        }
    }
}
