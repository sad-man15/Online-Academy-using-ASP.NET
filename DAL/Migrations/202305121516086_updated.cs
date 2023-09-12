namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Posts", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Comments", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Comments", new[] { "TeacherId" });
            DropIndex("dbo.Posts", new[] { "TeacherId" });
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            AddColumn("dbo.Students", "Role", c => c.String(nullable: false));
            DropColumn("dbo.Comments", "TeacherId");
            DropColumn("dbo.Posts", "TeacherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "TeacherId", c => c.Int());
            AddColumn("dbo.Comments", "TeacherId", c => c.Int());
            DropColumn("dbo.Students", "Role");
            CreateIndex("dbo.Courses", "TeacherId");
            CreateIndex("dbo.Posts", "TeacherId");
            CreateIndex("dbo.Comments", "TeacherId");
            AddForeignKey("dbo.Comments", "TeacherId", "dbo.Teachers", "Id");
            AddForeignKey("dbo.Posts", "TeacherId", "dbo.Teachers", "Id");
            AddForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
        }
    }
}
