namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7d1079f0-323f-48b3-b2fa-936b9f13745c', N'guest@correo.com', 0, N'ALoMBERm8v4Zh3JLZnM+2WmXunn8J3XW07Q951lXi13MDFtaVX8zFbuH7qLAamIB9g==', N'8385afd9-85ed-4ffb-beb5-a112e9fda92e', NULL, 0, 0, NULL, 1, 0, N'guest@correo.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c172027b-1c0a-4c66-81b2-be9c989acbac', N'admin@correo.com', 0, N'ALcTQoFaVhlo0kdz4F1qD6jGhFO/7lMsdMW5HfhAd8oPqjQbh57IJqU7gDDojxN2jQ==', N'7cd4b4ac-1692-45f8-b0b2-f509c14fc577', NULL, 0, 0, NULL, 1, 0, N'admin@correo.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ee31b002-112a-4dfb-b65e-882db0013bf9', N'rgomez@correo.com', 0, N'AFkfKpMkubRr6ste27yjOlIiiRsDYpLifXQ0Ws5SwlgCjdDVC04QRVZwbuFsyd9a6Q==', N'5c5cbe07-10ba-4992-9988-9b4af522d163', NULL, 0, 0, NULL, 1, 0, N'rgomez@correo.com')
            
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'041677c4-7239-4a61-8c46-ff278803abec', N'CanManageMovie')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c172027b-1c0a-4c66-81b2-be9c989acbac', N'041677c4-7239-4a61-8c46-ff278803abec')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
