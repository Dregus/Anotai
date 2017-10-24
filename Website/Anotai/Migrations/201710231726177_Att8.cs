namespace Anotai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Att8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RelatorioInvestidors", "ValorTotal", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RelatorioInvestidors", "ValorTotal", c => c.String());
        }
    }
}
