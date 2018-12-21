namespace Outlook_Signatures_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSignatureColumnsToEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "DefaultSignatureId", c => c.Int());
            AddColumn("dbo.Employees", "ForwardReplySignatureId", c => c.Int());
            AddColumn("dbo.Employees", "HasIndividualDefaultSignature", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "HasIndividualForwardReplySignature", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Employees", "DefaultSignatureId");
            CreateIndex("dbo.Employees", "ForwardReplySignatureId");
            AddForeignKey("dbo.Employees", "DefaultSignatureId", "dbo.Signatures", "SignatureId");
            AddForeignKey("dbo.Employees", "ForwardReplySignatureId", "dbo.Signatures", "SignatureId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ForwardReplySignatureId", "dbo.Signatures");
            DropForeignKey("dbo.Employees", "DefaultSignatureId", "dbo.Signatures");
            DropIndex("dbo.Employees", new[] { "ForwardReplySignatureId" });
            DropIndex("dbo.Employees", new[] { "DefaultSignatureId" });
            DropColumn("dbo.Employees", "HasIndividualForwardReplySignature");
            DropColumn("dbo.Employees", "HasIndividualDefaultSignature");
            DropColumn("dbo.Employees", "ForwardReplySignatureId");
            DropColumn("dbo.Employees", "DefaultSignatureId");
        }
    }
}
