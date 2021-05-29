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
	public partial class ProductForm : Form
	{
		public Product Product { get; set; }
		public string[] Units { get; set; }
		public ProductForm()
		{
			InitializeComponent();
		}
		void insertProduct()
		{
			try
			{
				Model1 context = new Model1();
				Product product = new Product();
				product.Name = textBox1.Text;
				product.TotalQuantity = 0;
				product.MeasuringUnit = string.Empty;
				foreach (var item in checkedListBox1.CheckedItems)
				{
					product.MeasuringUnit += $"{item.ToString()} ";
				}
				context.Products.Add(product);


				context.SaveChanges();
				refresh();
				MessageBox.Show($"{product.Name} is Added Successfully.");
			}
			catch (Exception ex) { MessageBox.Show(ex.Message); }
		}
		int getNoOfUnits(string[] units)
		{
			int count = 0;
			foreach (var unit in units)
			{
				if (unit != string.Empty) count++;
			}
			return count;
		}
		void updateProduct()
		{
			try
			{
				Model1 context = new Model1();
				string name = Product.Name;
				Product = context.Products.Where(p => p.Name == name).Select(p => p).First();
				if (textBox1.Text != string.Empty && checkedListBox1.CheckedItems.ToString() != string.Empty)
				{
					Product.Name = textBox1.Text;
					foreach (var item in checkedListBox1.CheckedItems)
					{
						if (getNoOfUnits(Units) < checkedListBox1.CheckedItems.Count)
							Product.MeasuringUnit += $"{item.ToString()} ";
						else Product.MeasuringUnit = createString(checkedListBox1.CheckedItems);
					}
					context.SaveChanges();
					refresh();
					MessageBox.Show($"Product info is updated successfully.");
				}
				else MessageBox.Show($"Failed to update {name} info");
			}
			catch (Exception ex) { MessageBox.Show(ex.Message); }
		}
		string createString(CheckedListBox.CheckedItemCollection checkedItems)
		{
			string s = string.Empty;
			foreach (var str in checkedItems)
			{
				s += $"{str} ";
			}
			return s;
		}
		void searchByName()
		{
			Model1 context = new Model1();
			Product = context.Products.Where(p => p.Name == textBox1.Text).Select(p => p).First();
			Units = Product.MeasuringUnit.Split(' ');
			for (int item = 0; item < Units.Length; item++)
			{
				if (Units[item] == string.Empty) continue;
				if (checkedListBox1.Items.Contains(Units[item]))
				{
					checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(Units[item]), true);
				}
			}
		}
		void selectAll()
		{
			Model1 context = new Model1();
			IEnumerable<Product> suppliers = context.Products;
			dataGridView1.DataSource = suppliers.ToList();
		}
		private void refresh()
		{
			textBox1.Text = string.Empty;
			for (int item = 0; item < checkedListBox1.Items.Count; item++)
				checkedListBox1.SetItemChecked(item, false);
			selectAll();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			insertProduct();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			updateProduct();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			searchByName();
		}

		private void ProductForm_Load(object sender, EventArgs e)
		{
			selectAll();
			textBox1.Focus();
		}
	}
}
