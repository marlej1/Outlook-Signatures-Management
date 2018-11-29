namespace Outlook_Signatures_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTheDataTypeForEmployeeLastNameColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "FirstName", c => c.Int(nullable: false));
        }
    }
}
