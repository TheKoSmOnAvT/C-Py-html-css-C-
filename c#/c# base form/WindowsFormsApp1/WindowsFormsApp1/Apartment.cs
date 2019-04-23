using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace WindowsFormsApp1
{
    public partial class Apartment : Form
    {
        public ClassLibrary1.Apartment obj = null;
        public Apartment(string Do = "Добавление", ClassLibrary1.Apartment obj = null)
        {
            InitializeComponent();
        }

        private void Apartment_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)//ok
        {
            try
            {
                // проверяем, не пустые ли боксы
                if (textBox1.Text == "" || maskedTextBox1.Text == "" || maskedTextBox2.Text == "")
                    throw new Exception("Введите все данные");
                int cost = 0;

                cost = Convert.ToInt32(maskedTextBox2.Text);

                int count = Convert.ToInt32(maskedTextBox2.Text);
                bool t = checkBox1.Checked;
                if (cost == 0 || count == 0)
                    throw new Exception("Введите значения больше 0");
                obj = new ClassLibrary1.Apartment(t, textBox1.Text, cost, count);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)//cancel
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
