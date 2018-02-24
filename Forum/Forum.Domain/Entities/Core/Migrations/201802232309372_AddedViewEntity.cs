namespace Forum.Domain.Entities.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedViewEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.View",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        UserId = c.Int(),
                        On = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.UserId)
                .Index(t => t.PostId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.View", "UserId", "dbo.Person");
            DropForeignKey("dbo.View", "PostId", "dbo.Post");
            DropIndex("dbo.View", new[] { "UserId" });
            DropIndex("dbo.View", new[] { "PostId" });
            DropTable("dbo.View");
        }
    }
}
