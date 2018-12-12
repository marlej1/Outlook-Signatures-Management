namespace Outlook_Signatures_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSignaturesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Signatures",
                c => new
                    {
                        SignatureId = c.Int(nullable: false, identity: true),
                        SignatureName = c.String(),
                        IsForwardReply = c.Boolean(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        IsOptional = c.Boolean(nullable: false),
                        Notes = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SignatureId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Signatures");
        }
    }
}
