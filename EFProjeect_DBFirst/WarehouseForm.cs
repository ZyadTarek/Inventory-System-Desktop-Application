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
	public partial class WarehouseForm : Form
	{
		public Warehouse Warehouse { get; set; }

		public WarehouseForm()
		{
			InitializeComponent();
		}
		void insertWarehouse()
		{
			try
			{
				Model1 context = new Model1();
				Warehouse warehouse = new Warehouse();
				warehouse.Name = textBox1.Text;
				warehouse.Address = textBox2.Text;
				warehouse.Manager = textBox3.Text;
				context.Warehouses.Add(warehouse);
				context.SaveChanges();
				refresh();
				MessageBox.Show($"{warehouse.Name} is Added Successfully.");
			}
			catch (Exception ex) { MessageBox.Show(ex.Message); }
		}
		void searchByName()
		{
			Model1 context = new Model1();
			Warehouse = context.Warehouses.Where(w => w.Name == textBox1.Text).Select(w => w).First();
			textBox2.Text = Warehouse.Address;
			textBox3.Text = Warehouse.Manager;
		}
		void updateWarehouse()
		{
			try
			{
				Model1 context = new Model1();
				string name = Warehouse.Name;
				Warehouse = context.Warehouses.Where(w => w.Name == name).Select(w => w).First();

				if (textBox1.Text != string.Empty && textBox2.Text != string.Empty &&
					textBox3.Text != string.Empty)
				{
					Warehouse.Name = textBox1.Text;
					Warehouse.Address = textBox2.Text;
					Warehouse.Manager = textBox3.Text;
					context.SaveChanges();
					refresh();
					MessageBox.Show($"Warehouse info is updated successfully.");
				}
			}
			catch (Exception ex) { MessageBox.Show(ex.Message); }
		}
		void selectAll()
		{
			Model1 context = new Model1();
			IEnumerable<Warehouse> warehouses = context.Warehouses;
			dataGridView1.DataSource = warehouses.ToList();
		}
		void refresh()
		{
			textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
			selectAll();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			insertWarehouse();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			updateWarehouse();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			searchByName();
		}

		private void WarehouseForm_Load(object sender, EventArgs e)
		{
			selectAll();
			textBox1.Focus();
		}
	}
}
