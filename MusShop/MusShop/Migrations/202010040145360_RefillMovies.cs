namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefillMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO Genres (Name) VALUES ('Thriller')");
            Sql("INSERT INTO Genres (Name) VALUES ('Family')");
            Sql("INSERT INTO Genres (Name) VALUES ('Romance')");
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");

            Sql(" INSERT INTO[dbo].[Movies] ([Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId]) VALUES(N'Shrek', N'2009-08-12 00:00:00', N'2020-09-29 00:00:00', 5, 5)");

            Sql("INSERT INTO[dbo].[Movies] ([Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId]) VALUES(N'Terminator', N'2002-05-06 00:00:00', N'2020-09-29 00:00:00', 3, 1)");
            Sql("INSERT INTO[dbo].[Movies] ([Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId]) VALUES(N'Titanic', N'1998-07-04 00:00:00', N'2020-09-29 00:00:00', 10, 4)");
            Sql("INSERT INTO[dbo].[Movies]([Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId]) VALUES(N'Die Hard', N'1999-02-03 00:00:00', N'2020-09-29 00:00:00', 4, 1)");
            Sql("INSERT INTO[dbo].[Movies]([Name], [ReleaseDate], [DateAdded], [NumberInStock], [GenreId]) VALUES(N'Toy Story', N'2007-07-15 00:00:00', N'2020-09-29 00:00:00', 15, 3)");
        }

        
        public override void Down()
        {
        }
    }
}
