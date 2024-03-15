namespace Settimana_19_Esercizio_Unico.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NuovaColonnaDataInOrdini : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ordini", "Data", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ordini", "Data");
        }
    }
}
