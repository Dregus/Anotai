namespace Anotai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Att : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pacotes", "QtdDisponivel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pacotes", "QtdDisponivel", c => c.Double(nullable: false));
        }
    }
}
