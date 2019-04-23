using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        public Realties RC;
        public Main()
        {
            //переменные и конструкторы
            InitializeComponent();
            RC = new Realties();
            openFileDialog.Filter = "Text files(*.or)|*.or";
            saveFileDialog.Filter = "Text files(*.or)|*.or";
            saveFileDialog.DefaultExt = "or"; //если не указано расширение после .
        }

        private void button2_Click(object sender, EventArgs e) //сохранение
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string path = saveFileDialog.FileName;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Create))
                formatter.Serialize(fs, RC);
        }

        private void button3_Click(object sender, EventArgs e)//открытие
        {
            TextBox_list.Clear();
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) // если отмена
                return;
            string path = openFileDialog.FileName; // полный путь к файлу
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Open))
                RC = (Realties)formatter.Deserialize(fs);
            TextBox_list.Text = RC.log.ToString();
        }

        private void richTextBox_list_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // если отдел не выбран
            if (napravlenie.SelectedItem == null)
                return;
            // инициализиурем форму отдела
            Obj form = null;
            // смотря по выбранному отделу, переходим в нужный отдел
            switch (napravlenie.SelectedItem.ToString())
            {
                case "Квартира":
                    // в параметрах: ссылка на текущую форму, выбранный отдел, свойства(переменные) соответствующего класса
                    form = new Obj(this, napravlenie.SelectedItem.ToString(), "Аренда", "Улица", "Стоимость", "Кол. комнат");
                    break;
                case "Коммерческая Недвижмость":
                    form = new Obj(this, napravlenie.SelectedItem.ToString(), "Аренда", "Улица", "Стоимость","назначение", "Кол. комнат");
                    break;
                case "Дом":
                    form = new Obj(this, napravlenie.SelectedItem.ToString(), "Аренда", "Улица", "Стоимость","Кол. комнат", "Кол. этажей");
                    break;
                case "Жилая Недвижимость":
                    form = new Obj(this, napravlenie.SelectedItem.ToString(), "Аренда", "Улица", "Стоимость", "Дата постройки");
                    break;
                case "Магазин":
                    form = new Obj(this, napravlenie.SelectedItem.ToString(), "Аренда", "Улица", "Стоимость","Название");
                    break;
            }
            // перейдем в форму отдела
            form.ShowDialog();
            // при выходе перевыведем данные журнала
            TextBox_list.Text = RC.log.ToString();
        }

        private void napravlenie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextBox_list.Clear();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void Main_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Сохранить?", "????", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            button2_Click(sender, e);
        }
    }
}
