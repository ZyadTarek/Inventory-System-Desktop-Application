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
	public partial class SupplierForm : Form
	{
		public Supplier Supplier { get; set; }
		public SupplierForm()
		{
			InitializeComponent();
		}
		void insertSupplier()
		{
			try
			{
				Model1 context = new Model1();
				Supplier supplier = new Supplier();
				supplier.Name = textBox1.Text;
				supplier.Phone = textBox2.Text;
				supplier.Fax = textBox3.Text;
				supplier.Email = textBox4.Text;
				supplier.Website = textBox5.Text;
				context.Suppliers.Add(supplier);
				context.SaveChanges();
				refresh();
				MessageBox.Show($"{supplier.Name} is Added Successfully.");
			}
			catch (Exception ex) { MessageBox.Show(ex.Message); }
		}
		void searchByName()
		{
			try
			{
				Model1 context = new Model1();
				Supplier = context.Suppliers.Where(s => s.Name == textBox1.Text).Select(s => s).First();
				textBox2.Text = Supplier.Phone;
				textBox3.Text = Supplier.Fax;
				textBox4.Text = Supplier.Email;
				textBox5.Text = Supplier.Website;
			}
			catch (Exception ex) { MessageBox.Show(ex.Message); }
		}
		void updateSupplier()
		{
			try
			{
				Model1 context = new Model1();
				string name = Supplier.Name;
				Supplier = context.Suppliers.Where(s => s.Name == name).Select(s => s).First();

				if (textBox1.Text != string.Empty && textBox2.Text != string.Empty &&
					textBox3.Text != string.Empty && textBox4.Text != string.Empty &&
					textBox5.Text != string.Empty)
				{
					Supplier.Name = textBox1.Text;
					Supplier.Phone = textBox2.Text;
					Supplier.Fax = textBox3.Text;
					Supplier.Email = textBox4.Text;
					Supplier.Website = textBox5.Text;
					context.SaveChanges();
					refresh();
					MessageBox.Show($"Supplier info is updated successfully.");
				}
			}
			catch (Exception ex) { MessageBox.Show(ex.Message); }
		}
		void selectAll()
		{
			Model1 context = new Model1();
			IEnumerable<Supplier> suppliers = context.Suppliers;
			dataGridView1.DataSource = suppliers.ToList();
		}
		private void refresh()
		{
			selectAll();
			textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
		}

		private void SupplierForm_Load(object sender, EventArgs e)
		{
			selectAll();
			textBox1.Focus();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			insertSupplier();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			updateSupplier();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			searchByName();
		}
	}
}
