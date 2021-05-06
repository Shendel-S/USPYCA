namespace USPYCA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiomdlosol2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("USPYCA.Ciudadano", "DireccionCiudadano_Id", "USPYCA.Direccion");
            DropIndex("USPYCA.Ciudadano", new[] { "DireccionCiudadano_Id" });
            AlterColumn("USPYCA.Ciudadano", "DireccionCiudadano_Id", c => c.Int());
            AlterColumn("USPYCA.Solicitud", "Revision", c => c.Boolean(nullable: false));
            CreateIndex("USPYCA.Ciudadano", "DireccionCiudadano_Id");
            AddForeignKey("USPYCA.Ciudadano", "DireccionCiudadano_Id", "USPYCA.Direccion", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("USPYCA.Ciudadano", "DireccionCiudadano_Id", "USPYCA.Direccion");
            DropIndex("USPYCA.Ciudadano", new[] { "DireccionCiudadano_Id" });
            AlterColumn("USPYCA.Solicitud", "Revision", c => c.String());
            AlterColumn("USPYCA.Ciudadano", "DireccionCiudadano_Id", c => c.Int(nullable: false));
            CreateIndex("USPYCA.Ciudadano", "DireccionCiudadano_Id");
            AddForeignKey("USPYCA.Ciudadano", "DireccionCiudadano_Id", "USPYCA.Direccion", "Id", cascadeDelete: true);
        }
    }
}
