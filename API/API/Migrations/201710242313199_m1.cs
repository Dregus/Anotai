namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.PedidoFinalizadoes",
                c => new
                    {
                        PedidoFinalizadoId = c.Int(nullable: false, identity: true),
                        DonoComandaId = c.Int(nullable: false),
                        NumeroComanda = c.Int(nullable: false),
                        ValorTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoFinalizadoId);
            
           
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
            DropTable("dbo.RelatorioPacotes");
            DropTable("dbo.RelatorioInvestidors");
            DropTable("dbo.PedidoFinalizadoes");
            DropTable("dbo.Pacotes");
            DropTable("dbo.Noticias");
            DropTable("dbo.Investimentoes");
            DropTable("dbo.Contatoes");
            DropTable("dbo.Comandas");
        }
    }
}
