namespace USPYCA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tramiteid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("USPYCA.Solicitud", "Tipotramite_Id", "USPYCA.Tramite");
            DropIndex("USPYCA.Solicitud", new[] { "Tipotramite_Id" });
            AddColumn("USPYCA.Solicitud", "Tramite_id", c => c.Int(nullable: false));
            DropColumn("USPYCA.Solicitud", "Tipotramite_Id");
        }
        
        public override void Down()
        {
            AddColumn("USPYCA.Solicitud", "Tipotramite_Id", c => c.Int());
            DropColumn("USPYCA.Solicitud", "Tramite_id");
            CreateIndex("USPYCA.Solicitud", "Tipotramite_Id");
            AddForeignKey("USPYCA.Solicitud", "Tipotramite_Id", "USPYCA.Tramite", "Id");
        }
    }
}
