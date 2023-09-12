namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDeletedTime1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ResetOTPs", "DeletedTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ResetOTPs", "DeletedTime", c => c.DateTime());
        }
    }
}
