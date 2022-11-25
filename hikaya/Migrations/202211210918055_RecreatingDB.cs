namespace hikaya.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreatingDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 100),
                        email = c.String(nullable: false, maxLength: 80),
                        password = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.FeaturedMessage",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        text = c.String(maxLength: 300),
                        date = c.DateTime(),
                        storyid = c.Int(),
                        userid = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Story", t => t.storyid)
                .ForeignKey("dbo.Users", t => t.userid)
                .Index(t => t.storyid)
                .Index(t => t.userid);
            
            CreateTable(
                "dbo.Story",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(maxLength: 50),
                        tags = c.String(maxLength: 50),
                        postDate = c.DateTime(),
                        isPublished = c.Boolean(),
                        userid = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.userid)
                .Index(t => t.userid);
            
            CreateTable(
                "dbo.SavedStory",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        storyid = c.Int(),
                        userid = c.Int(),
                        date = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Story", t => t.storyid)
                .ForeignKey("dbo.Users", t => t.userid)
                .Index(t => t.storyid)
                .Index(t => t.userid);
            
            CreateTable(
                "dbo.StoryPlot",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        storyid = c.Int(),
                        imageUrl = c.String(maxLength: 50),
                        text = c.String(),
                        sort = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Story", t => t.storyid, cascadeDelete: true)
                .Index(t => t.storyid);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeaturedMessage", "userid", "dbo.Users");
            DropForeignKey("dbo.Story", "userid", "dbo.Users");
            DropForeignKey("dbo.StoryPlot", "storyid", "dbo.Story");
            DropForeignKey("dbo.SavedStory", "userid", "dbo.Users");
            DropForeignKey("dbo.SavedStory", "storyid", "dbo.Story");
            DropForeignKey("dbo.FeaturedMessage", "storyid", "dbo.Story");
            DropForeignKey("dbo.Admin", "id", "dbo.Users");
            DropIndex("dbo.StoryPlot", new[] { "storyid" });
            DropIndex("dbo.SavedStory", new[] { "userid" });
            DropIndex("dbo.SavedStory", new[] { "storyid" });
            DropIndex("dbo.Story", new[] { "userid" });
            DropIndex("dbo.FeaturedMessage", new[] { "userid" });
            DropIndex("dbo.FeaturedMessage", new[] { "storyid" });
            DropIndex("dbo.Admin", new[] { "id" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.StoryPlot");
            DropTable("dbo.SavedStory");
            DropTable("dbo.Story");
            DropTable("dbo.FeaturedMessage");
            DropTable("dbo.Users");
            DropTable("dbo.Admin");
        }
    }
}
