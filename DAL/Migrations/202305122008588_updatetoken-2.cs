﻿namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetoken2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tokens", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tokens", "UserId", c => c.Int(nullable: false));
        }
    }
}
