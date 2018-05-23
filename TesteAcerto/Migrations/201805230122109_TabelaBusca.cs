namespace TesteAcerto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaBusca : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buscas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Termo = c.String(),
                        Hora = c.DateTime(nullable: false),
                        Personagem = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Buscas");
        }
    }
}
