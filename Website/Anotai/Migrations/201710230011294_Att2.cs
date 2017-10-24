namespace Anotai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Att2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pacotes", "Descricao", c => c.String());
            DropColumn("dbo.Pacotes", "Descrição");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pacotes", "Descrição", c => c.String());
            DropColumn("dbo.Pacotes", "Descricao");
        }
    }
}
