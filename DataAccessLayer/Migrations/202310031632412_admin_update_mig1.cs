namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin_update_mig1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String());
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String());
            DropColumn("dbo.Admins", "AdminPasswordSalt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminPasswordSalt", c => c.Binary());
            AlterColumn("dbo.Admins", "AdminPassword", c => c.Binary());
            AlterColumn("dbo.Admins", "AdminUserName", c => c.Binary());
        }
    }
}
