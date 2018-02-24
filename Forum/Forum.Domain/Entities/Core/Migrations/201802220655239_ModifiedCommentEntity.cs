namespace Forum.Domain.Entities.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedCommentEntity : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comment", name: "PostId", newName: "DiscussionId");
            RenameIndex(table: "dbo.Comment", name: "IX_PostId", newName: "IX_DiscussionId");
            AddColumn("dbo.Comment", "Reply", c => c.String(nullable: false));
            DropColumn("dbo.Comment", "Body");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "Body", c => c.String(nullable: false));
            DropColumn("dbo.Comment", "Reply");
            RenameIndex(table: "dbo.Comment", name: "IX_DiscussionId", newName: "IX_PostId");
            RenameColumn(table: "dbo.Comment", name: "DiscussionId", newName: "PostId");
        }
    }
}
