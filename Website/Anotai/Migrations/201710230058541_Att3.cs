namespace Anotai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Att3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pacotes", "QtdTotal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pacotes", "QtdTotal");
        }
    }
}
