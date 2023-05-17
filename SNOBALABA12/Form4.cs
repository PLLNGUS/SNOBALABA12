using LABA12;
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
    public partial class Form4 : Form
    {
        private readonly AppDbContext _context;
        private readonly Clients _client;

        public Orderss Order { get; private set; }

        public Form4(AppDbContext context, Clients client)
        {
            InitializeComponent();
            _context = context;
            _client = client;

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var order = new Orderss
            {
                Title = textBox1.Text,
                Сontent = textBox2.Text,
                Status = textBox3.Text,
                YearStart = int.Parse(textBox4.Text),
                YearFinish = int.Parse(textBox5.Text),
                ClientId = _client.Id
            };

            _context.Order.Add(order);
            _context.SaveChanges();

            Order = order;
            DialogResult = DialogResult.OK;
        }

    }
}

