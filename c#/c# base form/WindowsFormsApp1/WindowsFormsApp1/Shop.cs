using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Shop : Form
    {
        public ClassLibrary1.Shop obj = null;
        public Shop(string Do = "Добавление", ClassLibrary1.Shop obj = null)
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Shop_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // проверяем, не пустые ли боксы
                if (textBox1.Text == "" || maskedTextBox1.Text == "" || textBox3.Text == "" )
                    throw new Exception("Введите все данные");
                int cost = Convert.ToInt32(maskedTextBox1.Text);
                bool t = checkBox1.Checked;
                if (cost == 0 )
                    throw new Exception("Введите значения больше 0");
                obj = new ClassLibrary1.Shop(t, textBox1.Text, cost, textBox3.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
