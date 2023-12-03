namespace _2.Data_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicantTableAddedStatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applicants", "Status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applicants", "Status", c => c.Int(nullable: false));
        }
    }
}
