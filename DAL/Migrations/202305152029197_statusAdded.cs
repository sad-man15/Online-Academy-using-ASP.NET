namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statusAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "status");
        }
    }
}
