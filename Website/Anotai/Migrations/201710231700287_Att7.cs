namespace Anotai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Att7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RelatorioInvestidors",
                c => new
                    {
                        RelatorioInvestidorId = c.Int(nullable: false, identity: true),
                        NomeInvestidor = c.String(),
                        ValorTotal = c.String(),
                    })
                .PrimaryKey(t => t.RelatorioInvestidorId);
            
            CreateTable(
                "dbo.RelatorioPacotes",
                c => new
                    {
                        RelatorioPacoteId = c.Int(nullable: false, identity: true),
                        NomePacote = c.String(),
                        ValorTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RelatorioPacoteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RelatorioPacotes");
            DropTable("dbo.RelatorioInvestidors");
        }
    }
}
