namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmplotyeeTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "FullName", c => c.Int(nullable: false));
        }
    }
}
