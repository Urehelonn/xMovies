namespace xMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerChangedBack : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "UserEmail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "UserEmail", c => c.String(nullable: false));
        }
    }
}
