namespace xMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class membershiptypeNonAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "SignUpFee", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypes", "SighUpFee");

            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, MembershipClass, MembershipName) VALUES (0,0,0,0,'Not Member')");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "SighUpFee", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypes", "SignUpFee");
        }
    }
}
