namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertdatatomembership : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Movies", new[] { "MembershipTypeId" });
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "MembershipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "MembershipTypeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropColumn("dbo.Movies", "GenreId");
            DropTable("dbo.Genres");
            CreateIndex("dbo.Movies", "MembershipTypeId");
            AddForeignKey("dbo.Movies", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
