namespace EFProjeect_DBFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SupplyPermission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SupplyPermission()
        {
            SupplierPermissionsProducts = new HashSet<SupplierPermissionsProduct>();
        }

        public int SupplyPermissionId { get; set; }

        public int Number { get; set; }

        public DateTime Date { get; set; }

        public DateTime ProductionDate { get; set; }

        public int ExpirationPeriod { get; set; }

        public int Quantity { get; set; }

        public int? Supplier_SupplierId { get; set; }

        public int? Warehouse_WarehouseId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierPermissionsProduct> SupplierPermissionsProducts { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
