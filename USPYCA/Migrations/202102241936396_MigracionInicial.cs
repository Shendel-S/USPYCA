namespace USPYCA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "USPYCA.Ciudadano",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido_Paterno = c.String(nullable: false),
                        Apellido_Materno = c.String(nullable: false),
                        Direccion = c.String(nullable: false),
                        CorreoElectronico = c.String(nullable: false),
                        Teléfono = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "USPYCA.Direccion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Localidad = c.String(nullable: false),
                        Calle = c.String(nullable: false),
                        Num_int = c.Int(nullable: false),
                        Num_ext = c.Int(nullable: false),
                        Municipio = c.String(nullable: false),
                        CP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AspNetRoles",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            //CreateTable(
            //    "dbo.AspNetUserRoles",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            RoleId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.UserId, t.RoleId })
            //    .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId)
            //    .Index(t => t.RoleId);
            
            CreateTable(
                "USPYCA.Solicitud",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ubicacion_Id = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        Revision = c.String(),
                        Comentarios = c.String(),
                        Tipo_de_Solicitud = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "USPYCA.Tipo_de_Solicitud",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "USPYCA.Ubicacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitud = c.Int(nullable: false),
                        Longitud = c.Int(nullable: false),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AspNetUsers",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Email = c.String(maxLength: 256),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            ////CreateTable(
            ////    "dbo.AspNetUserClaims",
            ////    c => new
            ////        {
            ////            Id = c.Int(nullable: false, identity: true),
            ////            UserId = c.String(nullable: false, maxLength: 128),
            ////            ClaimType = c.String(),
            ////            ClaimValue = c.String(),
            ////        })
            ////    .PrimaryKey(t => t.Id)
            ////    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            ////    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.AspNetUserLogins",
            //    c => new
            //        {
            //            LoginProvider = c.String(nullable: false, maxLength: 128),
            //            ProviderKey = c.String(nullable: false, maxLength: 128),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            //DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            //DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            //DropIndex("dbo.AspNetUsers", "UserNameIndex");
            //DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            //DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            //DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            //DropTable("dbo.AspNetUserLogins");
            //DropTable("dbo.AspNetUserClaims");
            //DropTable("dbo.AspNetUsers");
            DropTable("USPYCA.Ubicacion");
            DropTable("USPYCA.Tipo_de_Solicitud");
            DropTable("USPYCA.Solicitud");
            //DropTable("dbo.AspNetUserRoles");
            //DropTable("dbo.AspNetRoles");
            DropTable("USPYCA.Direccion");
            DropTable("USPYCA.Ciudadano");
        }
    }
}
