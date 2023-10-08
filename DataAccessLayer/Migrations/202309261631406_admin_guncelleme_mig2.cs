namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin_guncelleme_mig2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminUserName", c => c.Binary());
            AlterColumn("dbo.Admins", "AdminPassword", c => c.Binary());
            AlterColumn("dbo.Admins", "AdminPasswordSalt", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminPasswordSalt", c => c.Byte(nullable: false));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.Byte(nullable: false));
            AlterColumn("dbo.Admins", "AdminUserName", c => c.Byte(nullable: false));
        }
    }
}
