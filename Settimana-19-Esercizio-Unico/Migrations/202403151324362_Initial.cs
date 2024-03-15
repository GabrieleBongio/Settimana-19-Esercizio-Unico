namespace Settimana_19_Esercizio_Unico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up() { }

        public override void Down()
        {
            DropForeignKey("dbo.Dettagli_Ordini", "IdArticolo", "dbo.Articoli");
            DropForeignKey("dbo.Ordini", "IdUtente", "dbo.Utenti");
            DropForeignKey("dbo.Dettagli_Ordini", "IdOrdine", "dbo.Ordini");
            DropIndex("dbo.Ordini", new[] { "IdUtente" });
            DropIndex("dbo.Dettagli_Ordini", new[] { "IdArticolo" });
            DropIndex("dbo.Dettagli_Ordini", new[] { "IdOrdine" });
            DropTable("dbo.Utenti");
            DropTable("dbo.Ordini");
            DropTable("dbo.Dettagli_Ordini");
            DropTable("dbo.Articoli");
        }
    }
}
