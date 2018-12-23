namespace Outlook_Signatures_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnabledToDisabledColummnInCampaignTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campaigns", "Disabled", c => c.Boolean(nullable: false));
            DropColumn("dbo.Campaigns", "Enabled");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Campaigns", "Enabled", c => c.Boolean(nullable: false));
            DropColumn("dbo.Campaigns", "Disabled");
        }
    }
}
