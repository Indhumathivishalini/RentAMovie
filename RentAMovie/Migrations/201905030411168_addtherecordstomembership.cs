namespace RentAMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtherecordstomembership : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieName = c.String(),
                        AddedDate = c.DateTime(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        MembershipTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Movies", new[] { "MembershipTypeId" });
            DropTable("dbo.Movies");
        }
    }
}
