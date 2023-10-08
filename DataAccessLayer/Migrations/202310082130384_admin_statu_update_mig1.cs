namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin_statu_update_mig1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminStatus", c => c.String());
        }
    }
}
