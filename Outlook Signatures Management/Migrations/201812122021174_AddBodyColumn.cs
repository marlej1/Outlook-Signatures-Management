namespace Outlook_Signatures_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBodyColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Signatures", "Body", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Signatures", "Body");
        }
    }
}
