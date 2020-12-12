namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0f191de7-6628-4417-9341-b5a7983840fc', N'admin@mail.com', 0, N'AMwmYlDEF64UuO/HEPHEVVZM/D22sKNiwHW7VLV19oxwKfvhfYixcTv3LQ2n0fnfdA==', N'b52c85c3-4722-4bce-9ef5-15a1ead881fb', NULL, 0, 0, NULL, 1, 0, N'admin@mail.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3563b9c5-7dcd-4a57-8099-7022d52be7f9', N'alex@gmail.com', 0, N'AKSd89rDO/PkNh1QuV/WpY89M4shdNRwHq77UznSrC8PxbigrsrgdmtSRRVvM5EICQ==', N'd99fab91-227e-4b52-9360-877c99737686', NULL, 0, 0, NULL, 1, 0, N'alex@gmail.com')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2cb905c2-0262-4985-abbe-06f7cf5a0be3', N'CanManageMovies')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0f191de7-6628-4417-9341-b5a7983840fc', N'2cb905c2-0262-4985-abbe-06f7cf5a0be3')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
