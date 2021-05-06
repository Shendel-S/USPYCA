namespace USPYCA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestriccionAnimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("USPYCA.Animal", "Raza", c => c.String());
            AlterColumn("USPYCA.Animal", "Sexo", c => c.String());
            AlterColumn("USPYCA.Animal", "Color", c => c.String());
            AlterColumn("USPYCA.Animal", "Edad", c => c.String());
            AlterColumn("USPYCA.Animal", "CausadeMuerte", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("USPYCA.Animal", "CausadeMuerte", c => c.String(nullable: false));
            AlterColumn("USPYCA.Animal", "Edad", c => c.String(nullable: false));
            AlterColumn("USPYCA.Animal", "Color", c => c.String(nullable: false));
            AlterColumn("USPYCA.Animal", "Sexo", c => c.String(nullable: false));
            AlterColumn("USPYCA.Animal", "Raza", c => c.String(nullable: false));
        }
    }
}
