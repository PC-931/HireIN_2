namespace _2.Data_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicantTableChangedToStringCandidateId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applicants", "CandidateId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applicants", "CandidateId", c => c.Int(nullable: false));
        }
    }
}
