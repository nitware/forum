namespace Forum.Domain.Entities.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedCommentEntity_2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comment", name: "DiscussionId", newName: "PostId");
            RenameIndex(table: "dbo.Comment", name: "IX_DiscussionId", newName: "IX_PostId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Comment", name: "IX_PostId", newName: "IX_DiscussionId");
            RenameColumn(table: "dbo.Comment", name: "PostId", newName: "DiscussionId");
        }
    }
}
