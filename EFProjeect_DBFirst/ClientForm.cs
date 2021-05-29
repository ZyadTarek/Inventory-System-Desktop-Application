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
	public partial class ClientForm : Form
	{
		public Client Client { get; set; }

		public ClientForm()
		{
			InitializeComponent();
		}
		void insertClient()
		{
			try
			{
				Model1 context = new Model1();
				Client client = new Client();
				client.Name = textBox1.Text;
				client.Phone = textBox2.Text;
				client.Fax = textBox3.Text;
				client.Email = textBox4.Text;
				client.Website = textBox5.Text;
				context.Clients.Add(client);
				context.SaveChanges();
				refresh();
				MessageBox.Show($"{Client.Name} is Added Successfully.");
			}
			catch (Exception) { MessageBox.Show("Insertion Failed!"); }
		}
		void searchByEmail()
		{
			try { 
			Model1 context = new Model1();
			Client = context.Clients.Where(c => c.Email == textBox4.Text).Select(w => w).First();
			textBox1.Text = Client.Name;
			textBox2.Text = Client.Phone;
			textBox3.Text = Client.Fax;
			textBox5.Text = Client.Website;
			}
			catch (Exception) { MessageBox.Show("Client is Not Found!"); }
		}
		void updateClient()
		{
			try
			{
				Model1 context = new Model1();

				string email = Client.Email;
				Client = context.Clients.Where(c => c.Email == email).Select(c => c).First();

				if (textBox1.Text != string.Empty && textBox2.Text != string.Empty &&
					textBox3.Text != string.Empty)
				{
					Client.Name = textBox1.Text;
					Client.Phone = textBox2.Text;
					Client.Fax = textBox3.Text;
					Client.Website = textBox5.Text;
					context.SaveChanges();
					refresh();
					MessageBox.Show($"Client info is updated successfully.");
				}
			}
			catch (Exception) { MessageBox.Show("Cannot update Client's info."); }
		}
		void selectAll()
		{
			try { 
			Model1 context = new Model1();
			IEnumerable<Client> clients = context.Clients;
			dataGridView1.DataSource = clients.ToList();
			}
			catch (Exception) { MessageBox.Show("Cannot Load From Database!"); }
		}
		void refresh()
		{
			textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
			selectAll();
		}

		private void ClientForm_Load(object sender, EventArgs e)
		{
			selectAll();
			textBox1.Focus();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			insertClient();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			updateClient();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			searchByEmail();
		}
	}
}
