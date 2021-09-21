namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationsToEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "FullName", c => c.String(nullable: false));
            CreateIndex("dbo.Employees", new[] { "Number", "IsStaffMember" }, unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "Number", "IsStaffMember" });
            AlterColumn("dbo.Employees", "FullName", c => c.String());
        }
    }
}
