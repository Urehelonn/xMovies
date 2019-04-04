namespace xMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailSubscribedAddToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "EmailSubscribed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "EmailSubscribed");
        }
    }
}
