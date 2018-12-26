namespace Outlook_Signatures_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePhoneNumerFromRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "PhoneNumber", c => c.String(nullable: false));
        }
    }
}
