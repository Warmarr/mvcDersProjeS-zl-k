namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin_guncelleme_mig1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminRole", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminRole", c => c.String());
        }
    }
}
