using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFProjeect_DBFirst
{
	public partial class SupplyPermissionForm : Form
	{
		public Model1 Model { get; set; }
		public SupplyPermission Permission { get; set; }
		public List<SupplyPermission> Permissions { get; set; }
		public List<Product> ProductsList { get; set; }
		public List<string> ProductsNamesList { get; set; }
		public int Num { get; set; }
		public SupplyPermissionForm()
		{
			InitializeComponent();
			Model = new Model1();
			Permission = new SupplyPermission();
			Permissions = new List<SupplyPermission>();
		}
		void insertSupplyPermission()
		{
			try {
				Model1 c = new Model1();
				SupplyPermission permission = new SupplyPermission();
				permission.Number = int.Parse(textBox1.Text);
				permission.Date = dateTimePicker1.Value;
				string WarehouseName = comboBox1.SelectedItem.ToString();
				string SupplierName = comboBox2.SelectedItem.ToString();
				string ProductName = comboBox3.SelectedItem.ToString();
				Warehouse warehouse = c.Warehouses.Where(w => w.Name == WarehouseName).Select(w => w).First();
				Supplier supplier = c.Suppliers.Where(s => s.Name == SupplierName).Select(s => s).First();
				Product product = c.Products.Where(p => p.Name == ProductName).Select(p => p).First();
				warehouse.Products.Add(product);
				supplier.Products.Add(product);
				warehouse.SupplyPermissions.Add(permission);
				supplier.SupplyPermissions.Add(permission);
				permission.Quantity = int.Parse(textBox2.Text);
				permission.ProductionDate = dateTimePicker2.Value;
				permission.ExpirationPeriod = int.Parse(textBox3.Text);
				permission.Supplier_SupplierId = supplier.SupplierId;
				permission.Warehouse_WarehouseId = warehouse.WarehouseId;
				permission.Warehouse = warehouse;
				permission.Supplier = supplier;
				product.TotalQuantity += permission.Quantity;
				SupplierPermissionsProduct supplierPermissionsProduct = new SupplierPermissionsProduct();
				supplierPermissionsProduct.ProductId = product.ProductId;
				supplierPermissionsProduct.SupplierPermissionId = permission.Number;
				supplierPermissionsProduct.Product = product;
				supplierPermissionsProduct.SupplyPermission = permission;
				permission.SupplierPermissionsProducts.Add(supplierPermissionsProduct);
				c.SupplyPermissions.Add(permission);
				Permission = permission;
				Permissions.Add(permission);
				Model = c;
				MessageBox.Show("A new produt is added.");
				c.SaveChanges();
				refresh();
			} catch (Exception) { MessageBox.Show("Insertion Failed"); }
		}
		void getSupplyPermissionProducts()
		{
			Num = int.Parse(textBox1.Text);
			//DateTime date = dateTimePicker1.Value;
			//string WarehouseName = comboBox1.SelectedItem.ToString();
			//string SupplierName = comboBox2.SelectedItem.ToString();
			SupplyPermission supplyPermission = Model.SupplyPermissions.
				Where(sp =>sp.Number == Num).Select(sp => sp).First();
			IEnumerable<SupplierPermissionsProduct> products = Model.SupplierPermissionsProducts.Where(p => p.SupplierPermissionId == Num).Select(p => p);
			ProductsList = new List<Product>();
			ProductsNamesList = new List<string>();
			foreach(SupplierPermissionsProduct p in products)
			{
				ProductsList.Add(p.Product);
			}
			foreach (SupplierPermissionsProduct p in products)
			{
				ProductsNamesList.Add(p.Product.Name);
			}
			listBox1.DataSource = ProductsNamesList;
		}
		void updateSupplyPermission()
		{
			try { 
			int pNo = int.Parse(textBox1.Text);
			var Product = Model.Products.Where(a => a.Name == comboBox3.SelectedItem.ToString()).Select(a=>a).First();
			SupplierPermissionsProduct permission = Model.SupplierPermissionsProducts
				.Where(p => p.SupplyPermission.Number == pNo && p.ProductId == Product.ProductId).Select(p => p).FirstOrDefault();
			int oldpQ = permission.Product.TotalQuantity;
			int oldPerQ = permission.SupplyPermission.Quantity;

			permission.SupplyPermission.Number = int.Parse(textBox1.Text);
			permission.SupplyPermission.Date = dateTimePicker1.Value;
			permission.SupplyPermission.Warehouse.Name = comboBox1.SelectedItem.ToString();
			permission.SupplyPermission.Supplier.Name = comboBox2.SelectedItem.ToString();
			permission.SupplyPermission.Quantity = int.Parse(textBox2.Text);
			permission.Product.TotalQuantity = (oldpQ - oldPerQ) + int.Parse(textBox2.Text);
			permission.SupplyPermission.ProductionDate = dateTimePicker2.Value;
			permission.SupplyPermission.ExpirationPeriod = int.Parse(textBox3.Text);
			MessageBox.Show("Updated");
			refresh();
			Model.SaveChanges();
			}
			catch (Exception) { MessageBox.Show("Failed to update this permission."); }
		}
		void getPermissionDetails()
		{
			int pNo = int.Parse(textBox1.Text);
			comboBox3.SelectedItem = listBox1.SelectedItem;
			var Product = Model.Products.Where(a => a.Name == comboBox3.SelectedItem.ToString()).Select(a => a).First();
			SupplierPermissionsProduct permission = Model.SupplierPermissionsProducts
				.Where(p => p.SupplyPermission.Number == pNo && p.ProductId == Product.ProductId).Select(p => p).FirstOrDefault();
			int oldpQ = permission.Product.TotalQuantity;
			int oldPerQ = permission.SupplyPermission.Quantity;
			dateTimePicker1.Value = permission.SupplyPermission.Date;
			comboBox1.SelectedItem = permission.SupplyPermission.Warehouse.Name;
			comboBox2.SelectedItem = permission.SupplyPermission.Supplier.Name;
			textBox2.Text = permission.SupplyPermission.Quantity.ToString();
			dateTimePicker2.Value = permission.SupplyPermission.ProductionDate;
			textBox3.Text = permission.SupplyPermission.ExpirationPeriod.ToString();
			//textBox3.Enabled = false;

		}
		void getAllProducts()
		{
			Model1 c = new Model1();
			List<object> collection = new List<object>();
			foreach (var product in c.Products)
			{
				collection.Add(product.Name);
			}
			comboBox3.Items.AddRange(collection.ToArray());
		}
		void getAllWarehouses()
		{
			Model1 c = new Model1();
			List<object> collection = new List<object>();
			foreach (var w in c.Warehouses)
			{
				collection.Add(w.Name);
			}
			comboBox1.Items.AddRange(collection.ToArray());
		}
		void getAllSuppliers()
		{
			Model1 c = new Model1();
			List<object> collection = new List<object>();
			foreach (var suuplier in c.Suppliers)
			{
				collection.Add(suuplier.Name);
			}
			comboBox2.Items.AddRange(collection.ToArray());
		}
		private void refresh()
		{
			textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
			dateTimePicker1.Value = dateTimePicker2.Value = DateTime.Today;
			listBox1.DataSource = null;
		}
		private void SupplyPermissionForm_Load(object sender, EventArgs e)
		{
			dateTimePicker1.Focus();
			getAllProducts();
			getAllSuppliers();
			getAllWarehouses();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			insertSupplyPermission();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Model.SaveChanges();
			Permissions.Clear();
			MessageBox.Show("Done");

		}

		private void button3_Click(object sender, EventArgs e)
		{
			getSupplyPermissionProducts();
			//listBox1.Items.Clear();
		}

		private void listBox1_MouseClick(object sender, MouseEventArgs e)
		{
			getPermissionDetails(); 
		}

		private void button2_Click(object sender, EventArgs e)
		{
			updateSupplyPermission();
		}
	}
}
