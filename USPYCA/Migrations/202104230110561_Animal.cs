namespace USPYCA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Animal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "USPYCA.Animal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Especie = c.String(nullable: false),
                        Raza = c.String(nullable: false),
                        Sexo = c.String(nullable: false),
                        Color = c.String(nullable: false),
                        Edad = c.String(nullable: false),
                        CausadeMuerte = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("USPYCA.Solicitud", "Animales_Id", c => c.Int());
            CreateIndex("USPYCA.Solicitud", "Animales_Id");
            AddForeignKey("USPYCA.Solicitud", "Animales_Id", "USPYCA.Animal", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("USPYCA.Solicitud", "Animales_Id", "USPYCA.Animal");
            DropIndex("USPYCA.Solicitud", new[] { "Animales_Id" });
            DropColumn("USPYCA.Solicitud", "Animales_Id");
            DropTable("USPYCA.Animal");
        }
    }
}
