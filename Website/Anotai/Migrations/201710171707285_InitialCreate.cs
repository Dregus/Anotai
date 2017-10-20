namespace Anotai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contatoes",
                c => new
                    {
                        ContatoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Telefone = c.String(),
                        Email = c.String(),
                        Mensagem = c.String(),
                    })
                .PrimaryKey(t => t.ContatoId);
            
            CreateTable(
                "dbo.Noticias",
                c => new
                    {
                        NoticiaId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Mensagem = c.String(),
                    })
                .PrimaryKey(t => t.NoticiaId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        TipoUsuario = c.String(),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Telefone = c.String(),
                        Cep = c.String(),
                        Endereco = c.String(),
                        NumeroCasa = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
            DropTable("dbo.Noticias");
            DropTable("dbo.Contatoes");
        }
    }
}
