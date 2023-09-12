namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Details = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CommunityId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Communities", t => t.CommunityId, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: false)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: false)
                .Index(t => t.CommunityId)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId);
            
            AddColumn("dbo.Comments", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "PostId");
            AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Posts", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Posts", "CommunityId", "dbo.Communities");
            DropIndex("dbo.Posts", new[] { "TeacherId" });
            DropIndex("dbo.Posts", new[] { "StudentId" });
            DropIndex("dbo.Posts", new[] { "CommunityId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropColumn("dbo.Comments", "PostId");
            DropTable("dbo.Posts");
        }
    }
}
