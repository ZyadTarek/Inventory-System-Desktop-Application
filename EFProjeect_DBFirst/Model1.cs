using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EFProjeect_DBFirst
{
	public partial class Model1 : DbContext
	{
		public Model1()
			: base("name=DBContext")
		{
		}

		public virtual DbSet<Client> Clients { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<SupplierPermissionsProduct> SupplierPermissionsProducts { get; set; }
		public virtual DbSet<Supplier> Suppliers { get; set; }
		public virtual DbSet<SupplyPermission> SupplyPermissions { get; set; }
		public virtual DbSet<Voucher> Vouchers { get; set; }
		public virtual DbSet<VouchersProduct> VouchersProducts { get; set; }
		public virtual DbSet<Warehouse> Warehouses { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Client>()
				.HasMany(e => e.Products)
				.WithMany(e => e.Clients)
				.Map(m => m.ToTable("ClientsProducts").MapLeftKey("ClientId").MapRightKey("ProductId"));

			modelBuilder.Entity<Product>()
				.HasMany(e => e.Suppliers)
				.WithMany(e => e.Products)
				.Map(m => m.ToTable("SuppliersProducts").MapLeftKey("ProductId").MapRightKey("SupplierId"));

			modelBuilder.Entity<Product>()
				.HasMany(e => e.Warehouses)
				.WithMany(e => e.Products)
				.Map(m => m.ToTable("WarehousesProducts").MapLeftKey("ProductId").MapRightKey("WarehouseId"));

			modelBuilder.Entity<Supplier>()
				.HasMany(e => e.SupplyPermissions)
				.WithOptional(e => e.Supplier)
				.HasForeignKey(e => e.Supplier_SupplierId);

			modelBuilder.Entity<Supplier>()
				.HasMany(e => e.Vouchers)
				.WithOptional(e => e.Supplier)
				.HasForeignKey(e => e.Supplier_SupplierId);

			modelBuilder.Entity<SupplyPermission>()
				.HasMany(e => e.SupplierPermissionsProducts)
				.WithOptional(e => e.SupplyPermission)
				.HasForeignKey(e => e.SupplyPermission_SupplyPermissionId);

			modelBuilder.Entity<Voucher>()
				.HasMany(e => e.VouchersProducts)
				.WithOptional(e => e.Voucher)
				.HasForeignKey(e => e.Voucher_VoucherId);

			modelBuilder.Entity<Warehouse>()
				.HasMany(e => e.SupplyPermissions)
				.WithOptional(e => e.Warehouse)
				.HasForeignKey(e => e.Warehouse_WarehouseId);

			modelBuilder.Entity<Warehouse>()
				.HasMany(e => e.Vouchers)
				.WithOptional(e => e.Warehouse)
				.HasForeignKey(e => e.Warehouse_WarehouseId);
		}
	}
}
