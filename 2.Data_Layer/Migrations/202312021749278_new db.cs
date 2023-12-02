namespace _2.Data_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applicants", "CandidateId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Vacancies", "AgencyId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Applicants", "VacancyId_VacancyId", "dbo.Vacancies");
            DropIndex("dbo.Applicants", new[] { "CandidateId_Id" });
            DropIndex("dbo.Applicants", new[] { "VacancyId_VacancyId" });
            DropIndex("dbo.Vacancies", new[] { "AgencyId_Id" });
            DropPrimaryKey("dbo.Applicants");
            DropColumn("dbo.Applicants", "Id");
            DropColumn("dbo.Applicants", "CandidateId_Id");
            DropColumn("dbo.Applicants", "VacancyId_VacancyId");
            DropColumn("dbo.Vacancies", "AgencyId_Id");
            AddColumn("dbo.Applicants", "ApplicantId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Applicants", "CandidateId", c => c.Int(nullable: false));
            AddColumn("dbo.Applicants", "VacancyId", c => c.Int(nullable: false));
            AddColumn("dbo.Vacancies", "AgencyId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Applicants", "ApplicantId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Applicants");
            DropColumn("dbo.Vacancies", "AgencyId");
            DropColumn("dbo.Applicants", "VacancyId");
            DropColumn("dbo.Applicants", "CandidateId");
            DropColumn("dbo.Applicants", "ApplicantId");
            AddColumn("dbo.Vacancies", "AgencyId_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Applicants", "VacancyId_VacancyId", c => c.Int(nullable: false));
            AddColumn("dbo.Applicants", "CandidateId_Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Applicants", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Applicants", "Id");
            CreateIndex("dbo.Vacancies", "AgencyId_Id");
            CreateIndex("dbo.Applicants", "VacancyId_VacancyId");
            CreateIndex("dbo.Applicants", "CandidateId_Id");
            AddForeignKey("dbo.Applicants", "VacancyId_VacancyId", "dbo.Vacancies", "VacancyId", cascadeDelete: true);
            AddForeignKey("dbo.Vacancies", "AgencyId_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Applicants", "CandidateId_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
