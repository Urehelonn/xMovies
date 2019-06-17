namespace xMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieLimitAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Limit", c => c.Boolean(nullable: false));
            DropColumn("dbo.MovieAccessRecords", "Comment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieAccessRecords", "Comment", c => c.String(nullable: false));
            DropColumn("dbo.Movies", "Limit");
        }
    }
}
