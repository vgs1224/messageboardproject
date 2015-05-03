namespace MessageBoardApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class threadlistandsearch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        commentId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Author = c.String(),
                        ThreadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.commentId);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        ThreadId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Message = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.ThreadId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Threads");
            DropTable("dbo.Comments");
        }
    }
}
