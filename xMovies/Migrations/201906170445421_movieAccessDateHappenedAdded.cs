namespace xMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieAccessDateHappenedAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieAccessRecords", "DateHappened", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieAccessRecords", "DateHappened");
        }
    }
}
