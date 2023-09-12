namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Teachers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        Phone = c.String(nullable: false),
                        Gmail = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        Education = c.String(nullable: false),
                        InterestedCourse = c.String(nullable: false),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
