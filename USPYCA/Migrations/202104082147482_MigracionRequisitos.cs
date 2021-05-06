namespace USPYCA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionRequisitos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "USPYCA.Requisito",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nombre = c.Int(nullable: false),
                        idTramite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("USPYCA.Solicitud", "Folio", c => c.Int(nullable: false));
            AddColumn("USPYCA.Solicitud", "Revisado", c => c.Boolean(nullable: false));
            DropColumn("USPYCA.Solicitud", "Revision");
        }
        
        public override void Down()
        {
            AddColumn("USPYCA.Solicitud", "Revision", c => c.Boolean(nullable: false));
            DropColumn("USPYCA.Solicitud", "Revisado");
            DropColumn("USPYCA.Solicitud", "Folio");
            DropTable("USPYCA.Requisito");
        }
    }
}
