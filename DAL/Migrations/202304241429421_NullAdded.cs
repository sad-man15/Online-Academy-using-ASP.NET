namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Comments", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Posts", "CommunityId", "dbo.Communities");
            DropForeignKey("dbo.Posts", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Posts", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Comments", new[] { "StudentId" });
            DropIndex("dbo.Comments", new[] { "TeacherId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Posts", new[] { "CommunityId" });
            DropIndex("dbo.Posts", new[] { "StudentId" });
            DropIndex("dbo.Posts", new[] { "TeacherId" });
            AlterColumn("dbo.Comments", "StudentId", c => c.Int());
            AlterColumn("dbo.Comments", "TeacherId", c => c.Int());
            AlterColumn("dbo.Comments", "PostId", c => c.Int());
            AlterColumn("dbo.Posts", "CommunityId", c => c.Int());
            AlterColumn("dbo.Posts", "StudentId", c => c.Int());
            AlterColumn("dbo.Posts", "TeacherId", c => c.Int());
            CreateIndex("dbo.Comments", "StudentId");
            CreateIndex("dbo.Comments", "TeacherId");
            CreateIndex("dbo.Comments", "PostId");
            CreateIndex("dbo.Posts", "CommunityId");
            CreateIndex("dbo.Posts", "StudentId");
            CreateIndex("dbo.Posts", "TeacherId");
            AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "Id");
            AddForeignKey("dbo.Comments", "StudentId", "dbo.Students", "Id");
            AddForeignKey("dbo.Comments", "TeacherId", "dbo.Teachers", "Id");
            AddForeignKey("dbo.Posts", "CommunityId", "dbo.Communities", "Id");
            AddForeignKey("dbo.Posts", "StudentId", "dbo.Students", "Id");
            AddForeignKey("dbo.Posts", "TeacherId", "dbo.Teachers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Posts", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Posts", "CommunityId", "dbo.Communities");
            DropForeignKey("dbo.Comments", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Comments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "TeacherId" });
            DropIndex("dbo.Posts", new[] { "StudentId" });
            DropIndex("dbo.Posts", new[] { "CommunityId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "TeacherId" });
            DropIndex("dbo.Comments", new[] { "StudentId" });
            AlterColumn("dbo.Posts", "TeacherId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "CommunityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "PostId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "TeacherId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "TeacherId");
            CreateIndex("dbo.Posts", "StudentId");
            CreateIndex("dbo.Posts", "CommunityId");
            CreateIndex("dbo.Comments", "PostId");
            CreateIndex("dbo.Comments", "TeacherId");
            CreateIndex("dbo.Comments", "StudentId");
            AddForeignKey("dbo.Posts", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Posts", "CommunityId", "dbo.Communities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
