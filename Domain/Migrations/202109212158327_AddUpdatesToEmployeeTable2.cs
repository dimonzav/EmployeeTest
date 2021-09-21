namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdatesToEmployeeTable2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Employees", new[] { "Number", "IsStaffMember" });
            CreateIndex("dbo.Employees", new[] { "Number", "IsStaffMember" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "Number", "IsStaffMember" });
            CreateIndex("dbo.Employees", new[] { "Number", "IsStaffMember" }, unique: true);
        }
    }
}
