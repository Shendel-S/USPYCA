namespace USPYCA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiomdlosol : DbMigration
    {
        public override void Up()
        {
            AddColumn("USPYCA.Ciudadano", "Telefono", c => c.Int(nullable: false));
            AddColumn("USPYCA.Ciudadano", "DireccionCiudadano_Id", c => c.Int(nullable: false));
            AddColumn("USPYCA.Solicitud", "Ciudadanos_Id", c => c.Int());
            AddColumn("USPYCA.Solicitud", "Tipotramite_Id", c => c.Int());
            CreateIndex("USPYCA.Ciudadano", "DireccionCiudadano_Id");
            CreateIndex("USPYCA.Solicitud", "Ciudadanos_Id");
            CreateIndex("USPYCA.Solicitud", "Tipotramite_Id");
            AddForeignKey("USPYCA.Ciudadano", "DireccionCiudadano_Id", "USPYCA.Direccion", "Id", cascadeDelete: true);
            AddForeignKey("USPYCA.Solicitud", "Ciudadanos_Id", "USPYCA.Ciudadano", "Id");
            AddForeignKey("USPYCA.Solicitud", "Tipotramite_Id", "USPYCA.Tramite", "Id");
            DropColumn("USPYCA.Ciudadano", "Direccion");
            DropColumn("USPYCA.Ciudadano", "Teléfono");
            DropColumn("USPYCA.Ciudadano", "Ubicacion");
            DropColumn("USPYCA.Solicitud", "Ubicacion_Id");
            DropColumn("USPYCA.Solicitud", "Tipo_de_Solicitud");
            DropTable("USPYCA.Tipo_de_Solicitud");
        }
        
        public override void Down()
        {
            CreateTable(
                "USPYCA.Tipo_de_Solicitud",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("USPYCA.Solicitud", "Tipo_de_Solicitud", c => c.String());
            AddColumn("USPYCA.Solicitud", "Ubicacion_Id", c => c.String());
            AddColumn("USPYCA.Ciudadano", "Ubicacion", c => c.String(nullable: false));
            AddColumn("USPYCA.Ciudadano", "Teléfono", c => c.Int(nullable: false));
            AddColumn("USPYCA.Ciudadano", "Direccion", c => c.String(nullable: false));
            DropForeignKey("USPYCA.Solicitud", "Tipotramite_Id", "USPYCA.Tramite");
            DropForeignKey("USPYCA.Solicitud", "Ciudadanos_Id", "USPYCA.Ciudadano");
            DropForeignKey("USPYCA.Ciudadano", "DireccionCiudadano_Id", "USPYCA.Direccion");
            DropIndex("USPYCA.Solicitud", new[] { "Tipotramite_Id" });
            DropIndex("USPYCA.Solicitud", new[] { "Ciudadanos_Id" });
            DropIndex("USPYCA.Ciudadano", new[] { "DireccionCiudadano_Id" });
            DropColumn("USPYCA.Solicitud", "Tipotramite_Id");
            DropColumn("USPYCA.Solicitud", "Ciudadanos_Id");
            DropColumn("USPYCA.Ciudadano", "DireccionCiudadano_Id");
            DropColumn("USPYCA.Ciudadano", "Telefono");
        }
    }
}
