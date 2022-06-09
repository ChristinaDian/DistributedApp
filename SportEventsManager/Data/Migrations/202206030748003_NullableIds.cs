namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "OrganisationId", "dbo.Organisations");
            DropForeignKey("dbo.Organisations", "UserId", "dbo.Users");
            DropIndex("dbo.Events", new[] { "OrganisationId" });
            DropIndex("dbo.Organisations", new[] { "UserId" });
            AlterColumn("dbo.Events", "OrganisationId", c => c.Int());
            AlterColumn("dbo.Organisations", "UserId", c => c.Int());
            CreateIndex("dbo.Events", "OrganisationId");
            CreateIndex("dbo.Organisations", "UserId");
            AddForeignKey("dbo.Events", "OrganisationId", "dbo.Organisations", "Id");
            AddForeignKey("dbo.Organisations", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organisations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Events", "OrganisationId", "dbo.Organisations");
            DropIndex("dbo.Organisations", new[] { "UserId" });
            DropIndex("dbo.Events", new[] { "OrganisationId" });
            AlterColumn("dbo.Organisations", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "OrganisationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Organisations", "UserId");
            CreateIndex("dbo.Events", "OrganisationId");
            AddForeignKey("dbo.Organisations", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Events", "OrganisationId", "dbo.Organisations", "Id", cascadeDelete: true);
        }
    }
}
