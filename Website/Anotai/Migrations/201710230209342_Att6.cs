namespace Anotai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Att6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Investimentoes",
                c => new
                    {
                        InvestimentoId = c.Int(nullable: false, identity: true),
                        IdUsuario = c.Int(nullable: false),
                        IdPacote = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvestimentoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Investimentoes");
        }
    }
}
