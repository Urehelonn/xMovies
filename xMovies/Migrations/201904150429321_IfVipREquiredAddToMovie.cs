namespace xMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IfVipREquiredAddToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "VIPMovie", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "VIPMovie");
        }
    }
}
