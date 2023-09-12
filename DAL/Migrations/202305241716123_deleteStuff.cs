namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteStuff : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "FinishedCourse");
            DropColumn("dbo.Users", "UnfinishedCourse");
            DropColumn("dbo.Users", "RunningCourse");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "RunningCourse", c => c.String());
            AddColumn("dbo.Users", "UnfinishedCourse", c => c.String());
            AddColumn("dbo.Users", "FinishedCourse", c => c.String());
        }
    }
}
