namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Students", newName: "Users");
            DropForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.StudentCommunities", "CommunityId", "dbo.Communities");
            DropForeignKey("dbo.StudentCommunities", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropIndex("dbo.StudentCourses", new[] { "StudentId" });
            DropIndex("dbo.StudentCourses", new[] { "CourseId" });
            DropIndex("dbo.StudentCommunities", new[] { "StudentId" });
            DropIndex("dbo.StudentCommunities", new[] { "CommunityId" });
            RenameColumn(table: "dbo.Comments", name: "StudentId", newName: "UserId");
            RenameColumn(table: "dbo.Posts", name: "StudentId", newName: "UserId");
            RenameIndex(table: "dbo.Comments", name: "IX_StudentId", newName: "IX_UserId");
            RenameIndex(table: "dbo.Posts", name: "IX_StudentId", newName: "IX_UserId");
            CreateTable(
                "dbo.UserCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.UserCommunities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CommunityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Communities", t => t.CommunityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CommunityId);
            
            DropColumn("dbo.Courses", "TeacherId");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.StudentCommunities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentCommunities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CommunityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "TeacherId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserCourses", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserCommunities", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserCommunities", "CommunityId", "dbo.Communities");
            DropForeignKey("dbo.UserCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.UserCommunities", new[] { "CommunityId" });
            DropIndex("dbo.UserCommunities", new[] { "UserId" });
            DropIndex("dbo.UserCourses", new[] { "CourseId" });
            DropIndex("dbo.UserCourses", new[] { "UserId" });
            DropTable("dbo.UserCommunities");
            DropTable("dbo.UserCourses");
            RenameIndex(table: "dbo.Posts", name: "IX_UserId", newName: "IX_StudentId");
            RenameIndex(table: "dbo.Comments", name: "IX_UserId", newName: "IX_StudentId");
            RenameColumn(table: "dbo.Posts", name: "UserId", newName: "StudentId");
            RenameColumn(table: "dbo.Comments", name: "UserId", newName: "StudentId");
            CreateIndex("dbo.StudentCommunities", "CommunityId");
            CreateIndex("dbo.StudentCommunities", "StudentId");
            CreateIndex("dbo.StudentCourses", "CourseId");
            CreateIndex("dbo.StudentCourses", "StudentId");
            AddForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentCommunities", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentCommunities", "CommunityId", "dbo.Communities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Users", newName: "Students");
        }
    }
}
