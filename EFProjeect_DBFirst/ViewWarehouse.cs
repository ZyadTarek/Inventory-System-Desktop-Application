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
	public partial class ViewWarehouse : Form
	{
		public ViewWarehouse()
		{
			InitializeComponent();
		}
		void getAllWarehouses()
		{
			Model1 c = new Model1();
			List<object> collection = new List<object>();
			foreach (var w in c.Warehouses)
			{
				collection.Add(w.Name);
			}
			comboBox3.Items.AddRange(collection.ToArray());
		}
		void viewWarehouse()
		{
			Model1 c = new Model1();
			string name = comboBox3.SelectedItem.ToString();
			if(name != string.Empty)
			{
				var data = c.Warehouses.Where(w => w.Name == name).Select(w => w).ToList();
				this.Text += $" {name.ToUpperInvariant()}";
				dataGridView1.DataSource = data;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			viewWarehouse();
		}

		private void ViewWarehouse_Load(object sender, EventArgs e)
		{
			getAllWarehouses();
		}
	}
}
