namespace _2.Data_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vacancyAgencyIdChangedToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vacancies", "AgencyId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vacancies", "AgencyId", c => c.Int(nullable: false));
        }
    }
}
