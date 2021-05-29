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
	public partial class VoucherForm : Form
	{
		public Model1 Model { get; set; }
		public Voucher Voucher { get; set; }
		public Voucher Permission { get; set; }
		public List<Voucher> Permissions { get; set; }
		public List<Product> ProductsList { get; set; }
		public List<string> ProductsNamesList { get; set; }
		public int Num { get; set; }
		public VoucherForm()
		{
			InitializeComponent();
			Model = new Model1();
			Permission = new Voucher();
			Permissions = new List<Voucher>();
		}
		void insertVoucher()
		{
			try { 
			Model1 c = new Model1();
			Voucher permission = new Voucher();
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
			warehouse.Vouchers.Add(permission);
			supplier.Vouchers.Add(permission);
			permission.Quantity = int.Parse(textBox2.Text);
			permission.Supplier_SupplierId = supplier.SupplierId;
			permission.Warehouse_WarehouseId = warehouse.WarehouseId;
			permission.Warehouse = warehouse;
			permission.Supplier = supplier;
			product.TotalQuantity -= permission.Quantity;
			VouchersProduct vouchersProduct = new VouchersProduct();
			vouchersProduct.ProductId = product.ProductId;
			vouchersProduct.VocherId = permission.Number;
			vouchersProduct.Product = product;
			vouchersProduct.Voucher = permission;
			permission.VouchersProducts.Add(vouchersProduct);
			c.Vouchers.Add(permission);
			Permission = permission;
			Permissions.Add(permission);
			Model = c;
			MessageBox.Show("A new produt is added.");

			c.SaveChanges();
			refresh();
			}
			catch (Exception) { MessageBox.Show("Failed to add this permission!"); }
		}
		void getVoucherProducts()
		{
			try { 
			Num = int.Parse(textBox1.Text);
			//DateTime date = dateTimePicker1.Value;
			//string WarehouseName = comboBox1.SelectedItem.ToString();
			//string SupplierName = comboBox2.SelectedItem.ToString();
			Voucher voucher = Model.Vouchers.
				Where(sp => sp.Number == Num).Select(sp => sp).First();
			IEnumerable<VouchersProduct> products = Model.VouchersProducts.Where(p => p.VocherId == Num).Select(p => p);
			ProductsList = new List<Product>();
			ProductsNamesList = new List<string>();
			foreach (VouchersProduct p in products)
			{
				ProductsList.Add(p.Product);
			}
			foreach (VouchersProduct p in products)
			{
				ProductsNamesList.Add(p.Product.Name);
			}
			listBox1.DataSource = ProductsNamesList;
			}
			catch (Exception) { MessageBox.Show("Failed to load Permission Products."); }
		}
		void updateVoucher()
		{
			try
			{
				int pNo = int.Parse(textBox1.Text);
				var Product = Model.Products.Where(a => a.Name == comboBox3.SelectedItem.ToString()).Select(a => a).First();
				VouchersProduct permission = Model.VouchersProducts
					.Where(p => p.Voucher.Number == pNo && p.ProductId == Product.ProductId).Select(p => p).FirstOrDefault();
				int oldpQ = permission.Product.TotalQuantity;
				int oldPerQ = permission.Voucher.Quantity;

				permission.Voucher.Number = int.Parse(textBox1.Text);
				permission.Voucher.Date = dateTimePicker1.Value;
				permission.Voucher.Warehouse.Name = comboBox1.SelectedItem.ToString();
				permission.Voucher.Supplier.Name = comboBox2.SelectedItem.ToString();
				permission.Voucher.Quantity = int.Parse(textBox2.Text);
				permission.Product.TotalQuantity = (oldpQ + oldPerQ) - int.Parse(textBox2.Text);
				MessageBox.Show("Updated");
				refresh();
				Model.SaveChanges();
			}
			catch (Exception) { MessageBox.Show("Failed to update this permission."); }
		}
		void getPermissionDetails()
		{
			try { 
			int pNo = int.Parse(textBox1.Text);
			comboBox3.SelectedItem = listBox1.SelectedItem;
			var Product = Model.Products.Where(a => a.Name == comboBox3.SelectedItem.ToString()).Select(a => a).First();
			VouchersProduct permission = Model.VouchersProducts
				.Where(p => p.Voucher.Number == pNo && p.ProductId == Product.ProductId).Select(p => p).FirstOrDefault();
			int oldpQ = permission.Product.TotalQuantity;
			int oldPerQ = permission.Voucher.Quantity;
			dateTimePicker1.Value = permission.Voucher.Date;
			comboBox1.SelectedItem = permission.Voucher.Warehouse.Name;
			comboBox2.SelectedItem = permission.Voucher.Supplier.Name;
			textBox2.Text = permission.Voucher.Quantity.ToString();
			}
			catch (Exception) { MessageBox.Show("Failed to get Permission content."); }
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
			textBox1.Text = textBox2.Text = string.Empty;
			dateTimePicker1.Value = DateTime.Today;
			listBox1.DataSource = null;
		}

		private void VoucherForm_Load(object sender, EventArgs e)
		{
			try { 
			dateTimePicker1.Focus();
			getAllProducts();
			getAllSuppliers();
			getAllWarehouses();
			}
			catch (Exception) { MessageBox.Show("Failed to load from database!"); }
		}

		private void button1_Click(object sender, EventArgs e)
		{
			insertVoucher();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			updateVoucher();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Model.SaveChanges();
			Permissions.Clear();
			MessageBox.Show("Done");
		}

		private void button3_Click(object sender, EventArgs e)
		{
			getVoucherProducts();
		}

		private void listBox1_MouseClick(object sender, MouseEventArgs e)
		{
			getPermissionDetails();
		}
	}
}
