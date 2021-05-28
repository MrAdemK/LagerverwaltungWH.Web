namespace LagerverwaltungWH.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMitarbeiterToGeschäftsfall : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Geschäftsfall", "Mitarbeiter", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Geschäftsfall", "Mitarbeiter");
        }
    }
}
