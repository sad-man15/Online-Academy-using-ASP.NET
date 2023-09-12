namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class token30 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tokens", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tokens", "UserId");
            AddForeignKey("dbo.Tokens", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "UserId", "dbo.Users");
            DropIndex("dbo.Tokens", new[] { "UserId" });
            AlterColumn("dbo.Tokens", "UserId", c => c.String(nullable: false));
        }
    }
}
