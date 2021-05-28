namespace LagerverwaltungWH.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeedUserAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1cc35a9d-73d5-47f8-9e36-d29aff79203c', N'mm1@gmx.at', 0, N'AIWJOzvX6xSFauV12tzeK98VMgPc2lDyLuI51k3qcMBKCAiPT7PWB1/Cxctea3Vwdg==', N'c402748d-1325-4c97-8a6d-64141ee0d08e', NULL, 0, 0, NULL, 1, 0, N'MM1')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'dcfcc75d-2ab2-4772-9b9c-8cc818097835', N'Mitarbeiter')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1cc35a9d-73d5-47f8-9e36-d29aff79203c', N'dcfcc75d-2ab2-4772-9b9c-8cc818097835')

");
        }
        
        public override void Down()
        {
        }
    }
}
