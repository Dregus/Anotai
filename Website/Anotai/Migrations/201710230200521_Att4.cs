namespace Anotai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Att4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pacotes", "QtdInvestir", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pacotes", "QtdInvestir");
        }
    }
}
