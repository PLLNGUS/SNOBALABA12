using LABA12;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNOBALABA12
{
    public partial class Form3 : Form
    {
        private readonly AppDbContext _context;
        private readonly Clients _client;

        public Form3(AppDbContext context, Clients client)
        {
            InitializeComponent();
            _context = context;
            _client = client;
            int Id =_client.Id;

            _client = _context.Client.Include(u => u.Orders).FirstOrDefault(u => u.Id == Id);
                /*Orders = _context.Order.Where(b => b.ClientId == _client.Id).ToList();*/


            Text = $"Ремонтная пользователя {_client.Name}";

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = _client.Orders;

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows[0];
            var order = (Orderss)selectedRow.DataBoundItem;
            _client.Orders.Remove(order);
            _context.SaveChanges();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _client.Orders;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bookForm = new Form4(_context, _client);
            if (bookForm.ShowDialog() == DialogResult.OK)
            {
             /*   _client.Orders.Add(bookForm.Order);
                _context.SaveChanges();*/

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _client.Orders;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows[0];
            var order = (Orderss)selectedRow.DataBoundItem;
            order.Status = "Неактивный";
            _context.SaveChanges();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _client.Orders;
        }
    }
}
