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
    public partial class Form2 : Form
    {
        private AppDbContext context;


        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clients client;
            using (var context = new AppDbContext())
            {
                var email = textBox1.Text;
                var password = textBox2.Text;

                client = context.Client.FirstOrDefault(u => u.Email == email && u.Password == password);
            }


            if (client != null)
            {
                MessageBox.Show("Вы успешно авторизовались!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form3 mainForm = new Form3(new AppDbContext(), client);
                Hide();
                mainForm.ShowDialog();

                DialogResult dialogResult = MessageBox.Show("Закрыть программу?", "Думай", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                    Close();
                else if (dialogResult == DialogResult.No)
                    Show();
            }
            else
            {
                MessageBox.Show("Неправильный email или пароль", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 registrationForm = new Form1(new AppDbContext());
            Hide();
            registrationForm.ShowDialog();
            Show();
        }
    }
}

