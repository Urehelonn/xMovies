namespace xMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerMembershipDurationLeftAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembershipDurationLeftInMonth", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "MembershipDurationLeftInMonth");
        }
    }
}
