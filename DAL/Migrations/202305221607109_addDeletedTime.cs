namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDeletedTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResetOTPs", "DeletedTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ResetOTPs", "DeletedTime");
        }
    }
}
