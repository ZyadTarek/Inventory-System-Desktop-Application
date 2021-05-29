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
	public partial class Home : Form
	{
		public Home()
		{
			InitializeComponent();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();

		}

		private void warehouseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			WarehouseForm warehouseForm = new WarehouseForm();
			warehouseForm.ShowDialog();
		}

		private void productToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ProductForm productForm = new ProductForm();
			productForm.ShowDialog();
		}

		private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SupplierForm supplierForm = new SupplierForm();
			supplierForm.ShowDialog();
		}

		private void supplierPermissionToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void clientToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ClientForm clientForm = new ClientForm();
			clientForm.ShowDialog();
		}



		private void moveProductToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MoveProductsForm moveProductsForm = new MoveProductsForm();
			moveProductsForm.ShowDialog();
		}

		private void viewWarehouseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ViewWarehouse viewWarehouse = new ViewWarehouse();
			viewWarehouse.ShowDialog();
		}

		private void supplyPermissionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SupplyPermissionForm supplyPermissionForm = new SupplyPermissionForm();
			supplyPermissionForm.ShowDialog();
		}

		private void voucherToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SupplyPermissionForm supplyPermissionForm = new SupplyPermissionForm();
			supplyPermissionForm.ShowDialog();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			richTextBox1.Enabled = false;
		}

		private void voucherPermissionToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void viewWarehouseProductsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ViewWarehouseProducts viewWarehouseProducts = new ViewWarehouseProducts();
			viewWarehouseProducts.ShowDialog();
		}
	}
}
