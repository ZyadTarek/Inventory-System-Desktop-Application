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
	public partial class MoveProductsForm : Form
	{
		public Model1 Model { get; set; }

		public MoveProductsForm()
		{
			InitializeComponent();
			Model = new Model1();

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
			comboBox5.Items.AddRange(collection.ToArray());
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
			comboBox4.Items.AddRange(collection.ToArray());
		}
		void selectAll()
		{
			Model1 context = new Model1();
			var data = context.Products.Join(
				context.Warehouses, product => product.ProductId,
				warehouse => warehouse.WarehouseId,
				(product, warehouse) => new
				{
					product_Id = product.ProductId,
					warehouse_Id = warehouse.WarehouseId,
					product_Name = product.Name,
					warehouse_Name = warehouse.Name,
					Total_Quantity = product.TotalQuantity
				}
				).ToList();
			dataGridView1.DataSource = data;
		}
		void updateSupplyPermission()
		{
			try
			{
				//int pNo = int.Parse(textBox1.Text);
				var Product = Model.Products.Where(a => a.Name == comboBox3.SelectedItem.ToString()).Select(a => a).First();
				SupplierPermissionsProduct permission = Model.SupplierPermissionsProducts
					.Where(p => p.SupplyPermission.Warehouse.Name == comboBox1.SelectedItem.ToString()
					&& p.ProductId == Product.ProductId && 
					p.SupplyPermission.Supplier.Name == comboBox2.SelectedItem.ToString()).
					Select(p => p).FirstOrDefault();
				int oldpQ = permission.Product.TotalQuantity;
				int oldPerQ = permission.SupplyPermission.Quantity;

				//permission.SupplyPermission.Number = int.Parse(textBox1.Text);
				//permission.SupplyPermission.Date = dateTimePicker1.Value;
				permission.SupplyPermission.Warehouse.Name = comboBox5.SelectedItem.ToString();
				permission.SupplyPermission.Supplier.Name = comboBox4.SelectedItem.ToString();
				permission.SupplyPermission.Quantity = int.Parse(textBox2.Text);
				permission.Product.TotalQuantity = (oldpQ - oldPerQ) + int.Parse(textBox2.Text);
				permission.SupplyPermission.ProductionDate = dateTimePicker1.Value;
				permission.SupplyPermission.ExpirationPeriod = int.Parse(textBox1.Text);
				//refresh();
				Model.SaveChanges();
				//selectAll();
				MessageBox.Show($"{Product.Name} is added to {permission.SupplyPermission.Warehouse.Name}");

			}
			catch (Exception) { MessageBox.Show("Failed to update this permission."); }
		}
		void updateVoucher()
		{
			try
			{
				//int pNo = int.Parse(textBox1.Text);
				var Product = Model.Products.Where(a => a.Name == comboBox3.SelectedItem.ToString()).Select(a => a).First();
				VouchersProduct permission = Model.VouchersProducts
					.Where(p => p.Voucher.Warehouse.Name == comboBox1.SelectedItem.ToString()
					&& p.ProductId == Product.ProductId &&
					p.Voucher.Supplier.Name == comboBox2.SelectedItem.ToString()).
					Select(p => p).FirstOrDefault();
				int oldpQ = permission.Product.TotalQuantity;
				int oldPerQ = permission.Voucher.Quantity;

				//permission.SupplyPermission.Number = int.Parse(textBox1.Text);
				//permission.SupplyPermission.Date = dateTimePicker1.Value;
				permission.Voucher.Warehouse.Name = comboBox5.SelectedItem.ToString();
				permission.Voucher.Supplier.Name = comboBox4.SelectedItem.ToString();
				permission.Voucher.Quantity = int.Parse(textBox2.Text);
				permission.Product.TotalQuantity = (oldpQ - oldPerQ) - int.Parse(textBox2.Text);
				//permission.Voucher.ProductionDate = dateTimePicker1.Value;
				//permission.Voucher.ExpirationPeriod = int.Parse(textBox1.Text);
				//refresh();
				Model.SaveChanges();
				//selectAll();
				MessageBox.Show($"{Product.Name} is moved from {permission.Voucher.Warehouse.Name}");

			}
			catch (Exception) { MessageBox.Show("Failed to update this permission."); }
		}
		private void refresh()
		{
			textBox1.Text = textBox2.Text = string.Empty;
			dataGridView1.DataSource = null;
			selectAll();
		}
		private void MoveProductsForm_Load(object sender, EventArgs e)
		{
			selectAll();
			getAllProducts();
			getAllSuppliers();
			getAllWarehouses();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			updateVoucher();
			updateSupplyPermission();
			refresh();
		}
	}
}
