namespace xMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipClass : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SighUpFee, DurationInMonths, MembershipClass) VALUES (1, 30, 3, 0)");
            Sql("INSERT INTO MembershipTypes (Id, SighUpFee, DurationInMonths, MembershipClass) VALUES (2, 45, 6, 0)");
            Sql("INSERT INTO MembershipTypes (Id, SighUpFee, DurationInMonths, MembershipClass) VALUES (3, 60, 6, 1)");
            Sql("INSERT INTO MembershipTypes (Id, SighUpFee, DurationInMonths, MembershipClass) VALUES (4, 100, 12, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
