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
    public partial class House : Form
    {
        public ClassLibrary1.House obj = null;
        public House(string Do = "Добавление", ClassLibrary1.House obj = null)
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void House_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // проверяем, не пустые ли боксы
                if (textBox1.Text == "" || maskedTextBox1.Text == "" || maskedTextBox2.Text == "" || maskedTextBox3.Text == "")
                    throw new Exception("Введите все данные");
                int cost = Convert.ToInt32(maskedTextBox1.Text);
                int rooms = Convert.ToInt32(maskedTextBox2.Text);
                int level = Convert.ToInt32(maskedTextBox3.Text);
                bool t = checkBox1.Checked;
                if (cost == 0 || rooms == 0 || level==0)
                    throw new Exception("Введите значения больше 0");
                obj = new ClassLibrary1.House(t, textBox1.Text, cost, rooms, level);
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
