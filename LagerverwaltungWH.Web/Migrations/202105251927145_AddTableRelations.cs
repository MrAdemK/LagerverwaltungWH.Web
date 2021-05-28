namespace LagerverwaltungWH.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Geschäftsfall",
                c => new
                    {
                        GeschäftsfallId = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(),
                        ErstelltVon = c.String(),
                        GeändertVon = c.String(),
                        LagerartikelId = c.Int(nullable: false),
                        LagerbewegungsId = c.Int(nullable: false),
                        VorgangsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GeschäftsfallId)
                .ForeignKey("dbo.Lagerartikels", t => t.LagerartikelId, cascadeDelete: true)
                .ForeignKey("dbo.Lagerbewegungs", t => t.LagerbewegungsId, cascadeDelete: true)
                .ForeignKey("dbo.Vorgangstyps", t => t.VorgangsId, cascadeDelete: true)
                .Index(t => t.LagerartikelId)
                .Index(t => t.LagerbewegungsId)
                .Index(t => t.VorgangsId);
            
            CreateTable(
                "dbo.Lagerartikels",
                c => new
                    {
                        LagerartikelId = c.Int(nullable: false, identity: true),
                        Bezeichnung = c.String(nullable: false, maxLength: 100),
                        Preis = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Lagerstand = c.Int(nullable: false),
                        MengeneinheitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LagerartikelId)
                .ForeignKey("dbo.Mengeneinheits", t => t.MengeneinheitId, cascadeDelete: true)
                .Index(t => t.MengeneinheitId);
            
            CreateTable(
                "dbo.Mengeneinheits",
                c => new
                    {
                        MengeneinheitId = c.Int(nullable: false, identity: true),
                        MengeneinheitBezeichnung = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.MengeneinheitId);
            
            CreateTable(
                "dbo.Lagerbewegungs",
                c => new
                    {
                        LagerbewegungsId = c.Int(nullable: false, identity: true),
                        LB_Menge = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LagerbewegungsId);
            
            CreateTable(
                "dbo.Vorgangstyps",
                c => new
                    {
                        VorgangsId = c.Int(nullable: false, identity: true),
                        Vorgang = c.String(nullable: false, maxLength: 7),
                    })
                .PrimaryKey(t => t.VorgangsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Geschäftsfall", "VorgangsId", "dbo.Vorgangstyps");
            DropForeignKey("dbo.Geschäftsfall", "LagerbewegungsId", "dbo.Lagerbewegungs");
            DropForeignKey("dbo.Lagerartikels", "MengeneinheitId", "dbo.Mengeneinheits");
            DropForeignKey("dbo.Geschäftsfall", "LagerartikelId", "dbo.Lagerartikels");
            DropIndex("dbo.Lagerartikels", new[] { "MengeneinheitId" });
            DropIndex("dbo.Geschäftsfall", new[] { "VorgangsId" });
            DropIndex("dbo.Geschäftsfall", new[] { "LagerbewegungsId" });
            DropIndex("dbo.Geschäftsfall", new[] { "LagerartikelId" });
            DropTable("dbo.Vorgangstyps");
            DropTable("dbo.Lagerbewegungs");
            DropTable("dbo.Mengeneinheits");
            DropTable("dbo.Lagerartikels");
            DropTable("dbo.Geschäftsfall");
        }
    }
}
