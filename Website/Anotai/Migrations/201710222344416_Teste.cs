namespace Anotai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pacotes",
                c => new
                    {
                        PacoteId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Descrição = c.String(),
                        Preco = c.Double(nullable: false),
                        QtdDisponivel = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PacoteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pacotes");
        }
    }
}
