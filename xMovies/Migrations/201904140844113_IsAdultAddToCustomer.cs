namespace xMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsAdultAddToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsAdult", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsAdult");
        }
    }
}
