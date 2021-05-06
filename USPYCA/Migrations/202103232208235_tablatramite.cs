namespace USPYCA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablatramite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "USPYCA.Tramite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Requisitos = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("USPYCA.Ciudadano", "Ubicacion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("USPYCA.Ciudadano", "Ubicacion");
            DropTable("USPYCA.Tramite");
        }
    }
}
