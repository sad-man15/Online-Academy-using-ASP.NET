namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcourses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FinishedCourse", c => c.String());
            AddColumn("dbo.Users", "UnfinishedCourse", c => c.String());
            AddColumn("dbo.Users", "RunningCourse", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "RunningCourse");
            DropColumn("dbo.Users", "UnfinishedCourse");
            DropColumn("dbo.Users", "FinishedCourse");
        }
    }
}
