namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_adminrole1_mig2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Admins", name: "Role_RoleId", newName: "RoleId");
            RenameIndex(table: "dbo.Admins", name: "IX_Role_RoleId", newName: "IX_RoleId");
            DropColumn("dbo.Admins", "AdminRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminRole", c => c.Int());
            RenameIndex(table: "dbo.Admins", name: "IX_RoleId", newName: "IX_Role_RoleId");
            RenameColumn(table: "dbo.Admins", name: "RoleId", newName: "Role_RoleId");
        }
    }
}
