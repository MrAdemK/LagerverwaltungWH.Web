namespace LagerverwaltungWH.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteMitarbeiter : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Geschäftsfall", "Mitarbeiter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Geschäftsfall", "Mitarbeiter", c => c.String(maxLength: 50));
        }
    }
}
