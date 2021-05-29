
namespace EFProjeect_DBFirst
{
	partial class Home
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.warehouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.supplierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.permissionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.supplyPermissionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.voucherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewWarehouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.viewWarehouseProductsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
			resources.ApplyResources(this.menuStrip1, "menuStrip1");
			this.menuStrip1.Name = "menuStrip1";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.permissionsToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
			// 
			// newToolStripMenuItem1
			// 
			this.newToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.warehouseToolStripMenuItem,
            this.productToolStripMenuItem,
            this.supplierToolStripMenuItem,
            this.clientToolStripMenuItem,
            this.moveProductToolStripMenuItem});
			this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
			resources.ApplyResources(this.newToolStripMenuItem1, "newToolStripMenuItem1");
			// 
			// warehouseToolStripMenuItem
			// 
			this.warehouseToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.warehouseToolStripMenuItem.Name = "warehouseToolStripMenuItem";
			resources.ApplyResources(this.warehouseToolStripMenuItem, "warehouseToolStripMenuItem");
			this.warehouseToolStripMenuItem.Click += new System.EventHandler(this.warehouseToolStripMenuItem_Click);
			// 
			// productToolStripMenuItem
			// 
			this.productToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.productToolStripMenuItem.Name = "productToolStripMenuItem";
			resources.ApplyResources(this.productToolStripMenuItem, "productToolStripMenuItem");
			this.productToolStripMenuItem.Click += new System.EventHandler(this.productToolStripMenuItem_Click);
			// 
			// supplierToolStripMenuItem
			// 
			this.supplierToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.supplierToolStripMenuItem.Name = "supplierToolStripMenuItem";
			resources.ApplyResources(this.supplierToolStripMenuItem, "supplierToolStripMenuItem");
			this.supplierToolStripMenuItem.Click += new System.EventHandler(this.supplierToolStripMenuItem_Click);
			// 
			// clientToolStripMenuItem
			// 
			this.clientToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
			resources.ApplyResources(this.clientToolStripMenuItem, "clientToolStripMenuItem");
			this.clientToolStripMenuItem.Click += new System.EventHandler(this.clientToolStripMenuItem_Click);
			// 
			// moveProductToolStripMenuItem
			// 
			this.moveProductToolStripMenuItem.Name = "moveProductToolStripMenuItem";
			resources.ApplyResources(this.moveProductToolStripMenuItem, "moveProductToolStripMenuItem");
			this.moveProductToolStripMenuItem.Click += new System.EventHandler(this.moveProductToolStripMenuItem_Click);
			// 
			// permissionsToolStripMenuItem
			// 
			this.permissionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supplyPermissionToolStripMenuItem,
            this.voucherToolStripMenuItem});
			this.permissionsToolStripMenuItem.Name = "permissionsToolStripMenuItem";
			resources.ApplyResources(this.permissionsToolStripMenuItem, "permissionsToolStripMenuItem");
			// 
			// supplyPermissionToolStripMenuItem
			// 
			this.supplyPermissionToolStripMenuItem.Name = "supplyPermissionToolStripMenuItem";
			resources.ApplyResources(this.supplyPermissionToolStripMenuItem, "supplyPermissionToolStripMenuItem");
			this.supplyPermissionToolStripMenuItem.Click += new System.EventHandler(this.supplyPermissionToolStripMenuItem_Click);
			// 
			// voucherToolStripMenuItem
			// 
			this.voucherToolStripMenuItem.Name = "voucherToolStripMenuItem";
			resources.ApplyResources(this.voucherToolStripMenuItem, "voucherToolStripMenuItem");
			this.voucherToolStripMenuItem.Click += new System.EventHandler(this.voucherToolStripMenuItem_Click);
			// 
			// reportsToolStripMenuItem
			// 
			this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewWarehouseToolStripMenuItem,
            this.viewWarehouseProductsToolStripMenuItem});
			this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
			resources.ApplyResources(this.reportsToolStripMenuItem, "reportsToolStripMenuItem");
			// 
			// viewWarehouseToolStripMenuItem
			// 
			this.viewWarehouseToolStripMenuItem.Name = "viewWarehouseToolStripMenuItem";
			resources.ApplyResources(this.viewWarehouseToolStripMenuItem, "viewWarehouseToolStripMenuItem");
			this.viewWarehouseToolStripMenuItem.Click += new System.EventHandler(this.viewWarehouseToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
			resources.ApplyResources(this.richTextBox1, "richTextBox1");
			this.richTextBox1.Name = "richTextBox1";
			// 
			// viewWarehouseProductsToolStripMenuItem
			// 
			this.viewWarehouseProductsToolStripMenuItem.Name = "viewWarehouseProductsToolStripMenuItem";
			resources.ApplyResources(this.viewWarehouseProductsToolStripMenuItem, "viewWarehouseProductsToolStripMenuItem");
			this.viewWarehouseProductsToolStripMenuItem.Click += new System.EventHandler(this.viewWarehouseProductsToolStripMenuItem_Click);
			// 
			// Form1
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Name = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem warehouseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem supplierToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moveProductToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem permissionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem supplyPermissionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem voucherToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewWarehouseToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.ToolStripMenuItem viewWarehouseProductsToolStripMenuItem;
	}
}

