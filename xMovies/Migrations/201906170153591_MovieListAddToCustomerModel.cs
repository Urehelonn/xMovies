namespace xMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieListAddToCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MovieList_Id", c => c.Int());
            CreateIndex("dbo.Customers", "MovieList_Id");
            AddForeignKey("dbo.Customers", "MovieList_Id", "dbo.Movies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MovieList_Id", "dbo.Movies");
            DropIndex("dbo.Customers", new[] { "MovieList_Id" });
            DropColumn("dbo.Customers", "MovieList_Id");
        }
    }
}
