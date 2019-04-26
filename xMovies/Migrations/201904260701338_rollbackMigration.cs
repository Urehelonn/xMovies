namespace xMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rollbackMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "VIPMovie");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "VIPMovie", c => c.Boolean(nullable: false));
        }
    }
}
