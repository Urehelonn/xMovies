namespace xMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5cd73186-f7a2-46e2-ab59-d7e28fe9edfd', N'admin@xmoives.ca', 0, N'APRZi6t5yHh+0rGsBPpPM2g4ST5iO1YorvBQX13wck3BWjH8mzlly7c4p1Q31eaxQw==', N'79450dda-6f23-4d01-b040-11f945236710', NULL, 0, 0, NULL, 1, 0, N'admin@xmoives.ca')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ac390e40-fbd2-4553-9e67-c93a15cf55a6', N'user@xmovies.ca', 0, N'AERARQtpNTsgFD92IriQwjUQ/Ex3TKY8NZkkqzYDCvJag9/TgG92Cic7tn3VyE6fdw==', N'eed457cf-5301-48da-b888-2af55b3a8e12', NULL, 0, 0, NULL, 1, 0, N'user@xmovies.ca')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cd682e53-d424-4b7e-99a9-7ac42944c66a', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5cd73186-f7a2-46e2-ab59-d7e28fe9edfd', N'cd682e53-d424-4b7e-99a9-7ac42944c66a')
");
        }
        
        public override void Down()
        {
        }
    }
}
