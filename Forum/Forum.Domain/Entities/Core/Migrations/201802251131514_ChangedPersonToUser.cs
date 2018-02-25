namespace Forum.Domain.Entities.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPersonToUser : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Person", newName: "User");
            RenameColumn(table: "dbo.Comment", name: "CommentorId", newName: "UserId");
            RenameColumn(table: "dbo.Post", name: "PersonId", newName: "UserId");
            RenameIndex(table: "dbo.Comment", name: "IX_CommentorId", newName: "IX_UserId");
            RenameIndex(table: "dbo.Post", name: "IX_PersonId", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Post", name: "IX_UserId", newName: "IX_PersonId");
            RenameIndex(table: "dbo.Comment", name: "IX_UserId", newName: "IX_CommentorId");
            RenameColumn(table: "dbo.Post", name: "UserId", newName: "PersonId");
            RenameColumn(table: "dbo.Comment", name: "UserId", newName: "CommentorId");
            RenameTable(name: "dbo.User", newName: "Person");
        }
    }
}
