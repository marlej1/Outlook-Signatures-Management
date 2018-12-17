namespace Outlook_Signatures_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCampaignTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        CampaignId = c.Int(nullable: false, identity: true),
                        CampaignName = c.String(),
                        Content = c.String(),
                        SideNotes = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        IsAlwaysActive = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Priority = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CampaignId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Campaigns");
        }
    }
}
