namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin_guncellememig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminPasswordSalt", c => c.Byte(nullable: false));
            AlterColumn("dbo.Admins", "AdminUserName", c => c.Byte(nullable: false));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.Byte(nullable: false));
            AlterColumn("dbo.Admins", "AdminRole", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminPasswordSalt");
        }
    }
}
