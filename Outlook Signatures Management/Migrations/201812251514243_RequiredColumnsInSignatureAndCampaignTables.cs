namespace Outlook_Signatures_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredColumnsInSignatureAndCampaignTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Campaigns", "CampaignName", c => c.String(nullable: false));
            AlterColumn("dbo.Signatures", "SignatureName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Signatures", "SignatureName", c => c.String());
            AlterColumn("dbo.Campaigns", "CampaignName", c => c.String());
        }
    }
}
