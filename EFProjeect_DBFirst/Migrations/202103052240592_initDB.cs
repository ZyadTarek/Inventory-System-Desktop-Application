namespace EFProjeect_DBFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TotalQuantity = c.Int(nullable: false),
                        MeasuringUnit = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.SupplierPermissionsProducts",
                c => new
                    {
                        SupplierPermissionId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        SupplyPermission_SupplyPermissionId = c.Int(),
                    })
                .PrimaryKey(t => new { t.SupplierPermissionId, t.ProductId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SupplyPermissions", t => t.SupplyPermission_SupplyPermissionId)
                .Index(t => t.ProductId)
                .Index(t => t.SupplyPermission_SupplyPermissionId);
            
            CreateTable(
                "dbo.SupplyPermissions",
                c => new
                    {
                        SupplyPermissionId = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ProductionDate = c.DateTime(nullable: false),
                        ExpirationPeriod = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Supplier_SupplierId = c.Int(),
                        Warehouse_WarehouseId = c.Int(),
                    })
                .PrimaryKey(t => t.SupplyPermissionId)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierId)
                .ForeignKey("dbo.Warehouses", t => t.Warehouse_WarehouseId)
                .Index(t => t.Supplier_SupplierId)
                .Index(t => t.Warehouse_WarehouseId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.Vouchers",
                c => new
                    {
                        VoucherId = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Supplier_SupplierId = c.Int(),
                        Warehouse_WarehouseId = c.Int(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VoucherId)
                .ForeignKey("dbo.Warehouses", t => t.Warehouse_WarehouseId)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierId)
                .Index(t => t.Supplier_SupplierId)
                .Index(t => t.Warehouse_WarehouseId);
            
            CreateTable(
                "dbo.VouchersProducts",
                c => new
                    {
                        VocherId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Voucher_VoucherId = c.Int(),
                    })
                .PrimaryKey(t => new { t.VocherId, t.ProductId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Vouchers", t => t.Voucher_VoucherId)
                .Index(t => t.ProductId)
                .Index(t => t.Voucher_VoucherId);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        WarehouseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Manager = c.String(),
                    })
                .PrimaryKey(t => t.WarehouseId);
            
            CreateTable(
                "dbo.SuppliersProducts",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.SupplierId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.WarehousesProducts",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.WarehouseId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.WarehouseId);
            
            CreateTable(
                "dbo.ClientsProducts",
                c => new
                    {
                        ClientId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClientId, t.ProductId })
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientsProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ClientsProducts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.WarehousesProducts", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.WarehousesProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SuppliersProducts", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.SuppliersProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SupplierPermissionsProducts", "SupplyPermission_SupplyPermissionId", "dbo.SupplyPermissions");
            DropForeignKey("dbo.Vouchers", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Vouchers", "Warehouse_WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.SupplyPermissions", "Warehouse_WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.VouchersProducts", "Voucher_VoucherId", "dbo.Vouchers");
            DropForeignKey("dbo.VouchersProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SupplyPermissions", "Supplier_SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.SupplierPermissionsProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.ClientsProducts", new[] { "ProductId" });
            DropIndex("dbo.ClientsProducts", new[] { "ClientId" });
            DropIndex("dbo.WarehousesProducts", new[] { "WarehouseId" });
            DropIndex("dbo.WarehousesProducts", new[] { "ProductId" });
            DropIndex("dbo.SuppliersProducts", new[] { "SupplierId" });
            DropIndex("dbo.SuppliersProducts", new[] { "ProductId" });
            DropIndex("dbo.VouchersProducts", new[] { "Voucher_VoucherId" });
            DropIndex("dbo.VouchersProducts", new[] { "ProductId" });
            DropIndex("dbo.Vouchers", new[] { "Warehouse_WarehouseId" });
            DropIndex("dbo.Vouchers", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.SupplyPermissions", new[] { "Warehouse_WarehouseId" });
            DropIndex("dbo.SupplyPermissions", new[] { "Supplier_SupplierId" });
            DropIndex("dbo.SupplierPermissionsProducts", new[] { "SupplyPermission_SupplyPermissionId" });
            DropIndex("dbo.SupplierPermissionsProducts", new[] { "ProductId" });
            DropTable("dbo.ClientsProducts");
            DropTable("dbo.WarehousesProducts");
            DropTable("dbo.SuppliersProducts");
            DropTable("dbo.Warehouses");
            DropTable("dbo.VouchersProducts");
            DropTable("dbo.Vouchers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.SupplyPermissions");
            DropTable("dbo.SupplierPermissionsProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Clients");
        }
    }
}
