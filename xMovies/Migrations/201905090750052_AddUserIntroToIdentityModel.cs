namespace xMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIntroToIdentityModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserIntro", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserIntro");
        }
    }
}
