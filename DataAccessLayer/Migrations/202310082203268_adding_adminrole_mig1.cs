namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_adminrole_mig1 : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.Admins", "Role_RoleId");
            AddForeignKey("dbo.Admins", "Role_RoleId", "dbo.AdminRoles", "RoleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "Role_RoleId", "dbo.AdminRoles");
            DropIndex("dbo.Admins", new[] { "Role_RoleId" });
            DropColumn("dbo.Admins", "Role_RoleId");
            DropTable("dbo.AdminRoles");
        }
    }
}
