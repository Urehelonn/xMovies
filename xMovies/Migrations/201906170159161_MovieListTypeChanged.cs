namespace xMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieListTypeChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MovieList_Id", "dbo.Movies");
            DropIndex("dbo.Customers", new[] { "MovieList_Id" });
            DropColumn("dbo.Customers", "MovieList_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MovieList_Id", c => c.Int());
            CreateIndex("dbo.Customers", "MovieList_Id");
            AddForeignKey("dbo.Customers", "MovieList_Id", "dbo.Movies", "Id");
        }
    }
}
