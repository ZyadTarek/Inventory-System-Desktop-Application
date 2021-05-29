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
	public partial class ViewWarehouseProducts : Form
	{
		public ViewWarehouseProducts()
		{
			InitializeComponent();
		}
		void selectAll()
		{
			Model1 context = new Model1();
			string name = comboBox3.SelectedItem.ToString();
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
				).Where(d=>d.warehouse_Name == name).ToList();
			this.Text += $" {name}";
			dataGridView1.DataSource = data;
		}
		void getAllWarehouses()
		{
			try { 
			Model1 c = new Model1();
			List<object> collection = new List<object>();
			foreach (var w in c.Warehouses)
			{
				collection.Add(w.Name);
			}
			comboBox3.Items.AddRange(collection.ToArray());
			}
			catch (Exception) { MessageBox.Show("Failed to load data from database!"); }
		}

		private void ViewWarehouseProducts_Load(object sender, EventArgs e)
		{
			getAllWarehouses();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			selectAll();
		}
	}
}
