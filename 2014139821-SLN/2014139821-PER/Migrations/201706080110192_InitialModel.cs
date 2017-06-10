namespace _2014139821_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdministradorEquipo",
                c => new
                    {
                        AdministradorEquipoId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AdministradorEquipoId);
            
            CreateTable(
                "dbo.EquipoCelular",
                c => new
                    {
                        EquipoCelularId = c.Int(nullable: false, identity: true),
                        AdministradorEquipoId = c.Int(nullable: false),
                        EvaluacionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipoCelularId)
                .ForeignKey("dbo.AdministradorEquipo", t => t.AdministradorEquipoId, cascadeDelete: true)
                .Index(t => t.AdministradorEquipoId);
            
            CreateTable(
                "dbo.Evaluacion",
                c => new
                    {
                        EvaluacionId = c.Int(nullable: false),
                        VentaId = c.Int(nullable: false),
                        TrabajadorId = c.Int(nullable: false),
                        CentroAtencionId = c.Int(nullable: false),
                        Cliente_ClienteId = c.Int(nullable: false),
                        EquipoCelular_EquipoCelularId = c.Int(nullable: false),
                        EstadoEvaluacion_EstadoEvaluacionId = c.Int(nullable: false),
                        LineaTelefonica_LineaTelefonicaId = c.Int(nullable: false),
                        Plan_PlanId = c.Int(nullable: false),
                        TipoEvaluacion_TipoEvaluacionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EvaluacionId)
                .ForeignKey("dbo.Venta", t => t.EvaluacionId)
                .ForeignKey("dbo.CentroAtencion", t => t.CentroAtencionId, cascadeDelete: true)
                .ForeignKey("dbo.Cliente", t => t.Cliente_ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.EquipoCelular", t => t.EquipoCelular_EquipoCelularId, cascadeDelete: true)
                .ForeignKey("dbo.EstadoEvaluacion", t => t.EstadoEvaluacion_EstadoEvaluacionId, cascadeDelete: true)
                .ForeignKey("dbo.LineaTelefonica", t => t.LineaTelefonica_LineaTelefonicaId, cascadeDelete: true)
                .ForeignKey("dbo.Plan", t => t.Plan_PlanId, cascadeDelete: true)
                .ForeignKey("dbo.TipoEvaluacion", t => t.TipoEvaluacion_TipoEvaluacionId, cascadeDelete: true)
                .ForeignKey("dbo.Trabajor", t => t.TrabajadorId, cascadeDelete: true)
                .Index(t => t.EvaluacionId)
                .Index(t => t.TrabajadorId)
                .Index(t => t.CentroAtencionId)
                .Index(t => t.Cliente_ClienteId)
                .Index(t => t.EquipoCelular_EquipoCelularId)
                .Index(t => t.EstadoEvaluacion_EstadoEvaluacionId)
                .Index(t => t.LineaTelefonica_LineaTelefonicaId)
                .Index(t => t.Plan_PlanId)
                .Index(t => t.TipoEvaluacion_TipoEvaluacionId);
            
            CreateTable(
                "dbo.CentroAtencion",
                c => new
                    {
                        CentroAtencionId = c.Int(nullable: false, identity: true),
                        DireccionId = c.Int(nullable: false),
                        EvaluacionId = c.Int(nullable: false),
                        VentaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CentroAtencionId);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        DireccionId = c.Int(nullable: false),
                        CentroAtencionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DireccionId)
                .ForeignKey("dbo.CentroAtencion", t => t.DireccionId)
                .Index(t => t.DireccionId);
            
            CreateTable(
                "dbo.Ubigeo",
                c => new
                    {
                        UbigeoId = c.Int(nullable: false),
                        DireccionId = c.Int(nullable: false),
                        Distrito_DistritoId = c.Int(),
                        Provincia_ProvinciaId = c.Int(),
                        Departamento_DepartamentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UbigeoId)
                .ForeignKey("dbo.Distrito", t => t.Distrito_DistritoId)
                .ForeignKey("dbo.Provincia", t => t.Provincia_ProvinciaId)
                .ForeignKey("dbo.Departamento", t => t.Departamento_DepartamentoId, cascadeDelete: true)
                .ForeignKey("dbo.Direccion", t => t.UbigeoId)
                .Index(t => t.UbigeoId)
                .Index(t => t.Distrito_DistritoId)
                .Index(t => t.Provincia_ProvinciaId)
                .Index(t => t.Departamento_DepartamentoId);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        DepartamentoId = c.Int(nullable: false, identity: true),
                        ProvinciaId = c.Int(nullable: false),
                        UbigeoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        ProvinciaId = c.Int(nullable: false, identity: true),
                        CadenaUbigeo = c.String(),
                        DepartamentoId = c.Int(nullable: false),
                        UbigeoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinciaId)
                .ForeignKey("dbo.Departamento", t => t.DepartamentoId, cascadeDelete: true)
                .Index(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Distrito",
                c => new
                    {
                        DistritoId = c.Int(nullable: false, identity: true),
                        ProvinciaId = c.Int(nullable: false),
                        UbigeoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistritoId)
                .ForeignKey("dbo.Provincia", t => t.ProvinciaId, cascadeDelete: true)
                .Index(t => t.ProvinciaId);
            
            CreateTable(
                "dbo.Venta",
                c => new
                    {
                        VentaId = c.Int(nullable: false, identity: true),
                        CentroAtencionId = c.Int(nullable: false),
                        Cliente_ClienteId = c.Int(nullable: false),
                        TipoPago_TipoPagoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VentaId)
                .ForeignKey("dbo.CentroAtencion", t => t.CentroAtencionId, cascadeDelete: true)
                .ForeignKey("dbo.Cliente", t => t.Cliente_ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.TipoPago", t => t.TipoPago_TipoPagoId, cascadeDelete: true)
                .Index(t => t.CentroAtencionId)
                .Index(t => t.Cliente_ClienteId)
                .Index(t => t.TipoPago_TipoPagoId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        EvaluacionId = c.Int(nullable: false),
                        VentaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Contrato",
                c => new
                    {
                        ContratoId = c.Int(nullable: false),
                        VentaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContratoId)
                .ForeignKey("dbo.Venta", t => t.ContratoId)
                .Index(t => t.ContratoId);
            
            CreateTable(
                "dbo.LineaTelefonica",
                c => new
                    {
                        LineaTelefonicaId = c.Int(nullable: false),
                        AdministradorLineaId = c.Int(nullable: false),
                        VentaId = c.Int(nullable: false),
                        EvaluacionId = c.Int(nullable: false),
                        TipoLinea_TipoLineaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LineaTelefonicaId)
                .ForeignKey("dbo.AdministradorLinea", t => t.AdministradorLineaId, cascadeDelete: true)
                .ForeignKey("dbo.TipoLinea", t => t.TipoLinea_TipoLineaId, cascadeDelete: true)
                .ForeignKey("dbo.Venta", t => t.LineaTelefonicaId)
                .Index(t => t.LineaTelefonicaId)
                .Index(t => t.AdministradorLineaId)
                .Index(t => t.TipoLinea_TipoLineaId);
            
            CreateTable(
                "dbo.AdministradorLinea",
                c => new
                    {
                        AdministradorLineaId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AdministradorLineaId);
            
            CreateTable(
                "dbo.TipoLinea",
                c => new
                    {
                        TipoLineaId = c.Int(nullable: false, identity: true),
                        LineaTelefonicaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoLineaId);
            
            CreateTable(
                "dbo.TipoPago",
                c => new
                    {
                        TipoPagoId = c.Int(nullable: false, identity: true),
                        VentaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoPagoId);
            
            CreateTable(
                "dbo.EstadoEvaluacion",
                c => new
                    {
                        EstadoEvaluacionId = c.Int(nullable: false, identity: true),
                        EvaluacionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstadoEvaluacionId);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        EvaluacionId = c.Int(nullable: false),
                        TipoPlan_TipoPlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanId)
                .ForeignKey("dbo.TipoPlan", t => t.TipoPlan_TipoPlanId, cascadeDelete: true)
                .Index(t => t.TipoPlan_TipoPlanId);
            
            CreateTable(
                "dbo.TipoPlan",
                c => new
                    {
                        TipoPlanId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TipoPlanId);
            
            CreateTable(
                "dbo.TipoEvaluacion",
                c => new
                    {
                        TipoEvaluacionId = c.Int(nullable: false, identity: true),
                        EvaluacionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoEvaluacionId);
            
            CreateTable(
                "dbo.Trabajor",
                c => new
                    {
                        TrabajadorId = c.Int(nullable: false, identity: true),
                        EvaluacionID = c.Int(nullable: false),
                        TipoTrabajador_TipoTrabajadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrabajadorId)
                .ForeignKey("dbo.TipoTrabajador", t => t.TipoTrabajador_TipoTrabajadorId, cascadeDelete: true)
                .Index(t => t.TipoTrabajador_TipoTrabajadorId);
            
            CreateTable(
                "dbo.TipoTrabajador",
                c => new
                    {
                        TipoTrabajadorId = c.Int(nullable: false, identity: true),
                        TrabajadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoTrabajadorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluacion", "TrabajadorId", "dbo.Trabajor");
            DropForeignKey("dbo.Trabajor", "TipoTrabajador_TipoTrabajadorId", "dbo.TipoTrabajador");
            DropForeignKey("dbo.Evaluacion", "TipoEvaluacion_TipoEvaluacionId", "dbo.TipoEvaluacion");
            DropForeignKey("dbo.Evaluacion", "Plan_PlanId", "dbo.Plan");
            DropForeignKey("dbo.Plan", "TipoPlan_TipoPlanId", "dbo.TipoPlan");
            DropForeignKey("dbo.Evaluacion", "LineaTelefonica_LineaTelefonicaId", "dbo.LineaTelefonica");
            DropForeignKey("dbo.Evaluacion", "EstadoEvaluacion_EstadoEvaluacionId", "dbo.EstadoEvaluacion");
            DropForeignKey("dbo.Evaluacion", "EquipoCelular_EquipoCelularId", "dbo.EquipoCelular");
            DropForeignKey("dbo.Evaluacion", "Cliente_ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Evaluacion", "CentroAtencionId", "dbo.CentroAtencion");
            DropForeignKey("dbo.Venta", "TipoPago_TipoPagoId", "dbo.TipoPago");
            DropForeignKey("dbo.LineaTelefonica", "LineaTelefonicaId", "dbo.Venta");
            DropForeignKey("dbo.LineaTelefonica", "TipoLinea_TipoLineaId", "dbo.TipoLinea");
            DropForeignKey("dbo.LineaTelefonica", "AdministradorLineaId", "dbo.AdministradorLinea");
            DropForeignKey("dbo.Evaluacion", "EvaluacionId", "dbo.Venta");
            DropForeignKey("dbo.Contrato", "ContratoId", "dbo.Venta");
            DropForeignKey("dbo.Venta", "Cliente_ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Venta", "CentroAtencionId", "dbo.CentroAtencion");
            DropForeignKey("dbo.Direccion", "DireccionId", "dbo.CentroAtencion");
            DropForeignKey("dbo.Ubigeo", "UbigeoId", "dbo.Direccion");
            DropForeignKey("dbo.Ubigeo", "Departamento_DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.Ubigeo", "Provincia_ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.Ubigeo", "Distrito_DistritoId", "dbo.Distrito");
            DropForeignKey("dbo.Distrito", "ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.Provincia", "DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.EquipoCelular", "AdministradorEquipoId", "dbo.AdministradorEquipo");
            DropIndex("dbo.Trabajor", new[] { "TipoTrabajador_TipoTrabajadorId" });
            DropIndex("dbo.Plan", new[] { "TipoPlan_TipoPlanId" });
            DropIndex("dbo.LineaTelefonica", new[] { "TipoLinea_TipoLineaId" });
            DropIndex("dbo.LineaTelefonica", new[] { "AdministradorLineaId" });
            DropIndex("dbo.LineaTelefonica", new[] { "LineaTelefonicaId" });
            DropIndex("dbo.Contrato", new[] { "ContratoId" });
            DropIndex("dbo.Venta", new[] { "TipoPago_TipoPagoId" });
            DropIndex("dbo.Venta", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.Venta", new[] { "CentroAtencionId" });
            DropIndex("dbo.Distrito", new[] { "ProvinciaId" });
            DropIndex("dbo.Provincia", new[] { "DepartamentoId" });
            DropIndex("dbo.Ubigeo", new[] { "Departamento_DepartamentoId" });
            DropIndex("dbo.Ubigeo", new[] { "Provincia_ProvinciaId" });
            DropIndex("dbo.Ubigeo", new[] { "Distrito_DistritoId" });
            DropIndex("dbo.Ubigeo", new[] { "UbigeoId" });
            DropIndex("dbo.Direccion", new[] { "DireccionId" });
            DropIndex("dbo.Evaluacion", new[] { "TipoEvaluacion_TipoEvaluacionId" });
            DropIndex("dbo.Evaluacion", new[] { "Plan_PlanId" });
            DropIndex("dbo.Evaluacion", new[] { "LineaTelefonica_LineaTelefonicaId" });
            DropIndex("dbo.Evaluacion", new[] { "EstadoEvaluacion_EstadoEvaluacionId" });
            DropIndex("dbo.Evaluacion", new[] { "EquipoCelular_EquipoCelularId" });
            DropIndex("dbo.Evaluacion", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.Evaluacion", new[] { "CentroAtencionId" });
            DropIndex("dbo.Evaluacion", new[] { "TrabajadorId" });
            DropIndex("dbo.Evaluacion", new[] { "EvaluacionId" });
            DropIndex("dbo.EquipoCelular", new[] { "AdministradorEquipoId" });
            DropTable("dbo.TipoTrabajador");
            DropTable("dbo.Trabajor");
            DropTable("dbo.TipoEvaluacion");
            DropTable("dbo.TipoPlan");
            DropTable("dbo.Plan");
            DropTable("dbo.EstadoEvaluacion");
            DropTable("dbo.TipoPago");
            DropTable("dbo.TipoLinea");
            DropTable("dbo.AdministradorLinea");
            DropTable("dbo.LineaTelefonica");
            DropTable("dbo.Contrato");
            DropTable("dbo.Cliente");
            DropTable("dbo.Venta");
            DropTable("dbo.Distrito");
            DropTable("dbo.Provincia");
            DropTable("dbo.Departamento");
            DropTable("dbo.Ubigeo");
            DropTable("dbo.Direccion");
            DropTable("dbo.CentroAtencion");
            DropTable("dbo.Evaluacion");
            DropTable("dbo.EquipoCelular");
            DropTable("dbo.AdministradorEquipo");
        }
    }
}
