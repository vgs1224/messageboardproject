namespace MessageBoardApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Threads");
            AddColumn("dbo.Threads", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Threads", "Title", c => c.String());
            AddPrimaryKey("dbo.Threads", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Threads");
            AlterColumn("dbo.Threads", "Title", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Threads", "Id");
            AddPrimaryKey("dbo.Threads", "Title");
        }
    }
}
