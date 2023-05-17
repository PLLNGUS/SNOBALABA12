using LABA12;
using Microsoft.VisualBasic.ApplicationServices;

namespace SNOBALABA12
{
    public partial class Form1 : Form
    {
        private readonly AppDbContext _context;
        public Form1(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new Clients
            {
                Name = textBox1.Text,
                Email = textBox2.Text,
                Number = textBox3.Text,
                Password = textBox4.Text
            };

            _context.Client.Add(client);
            _context.SaveChanges();

            MessageBox.Show("Вы успешно зарегистрировались!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

    }
}
}