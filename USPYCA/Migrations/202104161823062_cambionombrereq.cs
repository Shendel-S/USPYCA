namespace USPYCA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambionombrereq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("USPYCA.Requisito", "Nombre", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("USPYCA.Requisito", "Nombre", c => c.Int(nullable: false));
        }
    }
}
