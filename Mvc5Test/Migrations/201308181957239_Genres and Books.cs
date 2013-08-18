namespace Mvc5Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenresandBooks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Author = c.String(),
                        Title = c.String(),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.BookGenre",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.GenreId })
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookGenre", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.BookGenre", "BookId", "dbo.Books");
            DropIndex("dbo.BookGenre", new[] { "GenreId" });
            DropIndex("dbo.BookGenre", new[] { "BookId" });
            DropTable("dbo.BookGenre");
            DropTable("dbo.Books");
            DropTable("dbo.Genres");
        }
    }
}
