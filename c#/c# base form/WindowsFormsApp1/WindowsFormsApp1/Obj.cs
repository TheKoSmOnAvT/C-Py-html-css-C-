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
    public partial class Obj : Form
    {
        Main Forms;
        ClassLibrary1.Company dopp;


        public Obj(Main MF, string comp, params string[] mas)
        {
            InitializeComponent();
            Text = comp;
            Forms = MF;
            Forms.Visible = false;

            foreach (var x in mas)// запишем данные в таблицу
                dataGridView_department.Columns.Add(x, x);
            dopp = Forms.RC[comp];
            Write_in_Grid();
        }

        public void Write_in_Grid()
        {
            dataGridView_department.Rows.Clear(); // очищаем перед записью
            // смотрим по названию отдела
            switch (Text)
            {
                case "Квартира":
                    foreach (var x in dopp) // перебираем объекты 
                    {
                        ClassLibrary1.Apartment obj = x as ClassLibrary1.Apartment;
                        dataGridView_department.Rows.Add(obj.pur, obj.name, obj.cost, obj.count_room);
                    }
                    break;
                case "Магазин":
                    foreach (var x in dopp) // перебираем объекты 
                    {
                        ClassLibrary1.Shop obj = x as ClassLibrary1.Shop;
                        dataGridView_department.Rows.Add(obj.pur, obj.name, obj.cost, obj.nazvanie);
                    }
                    break;
                case "Жилая Недвижимость":
                    foreach (var x in dopp)
                    {
                        ClassLibrary1.Residential_Real_Estate obj = x as ClassLibrary1.Residential_Real_Estate;
                        dataGridView_department.Rows.Add(obj.pur, obj.name, obj.cost, obj.date);
                    }
                    break;
                case "Дом":
                    foreach (var x in dopp)
                    {
                        ClassLibrary1.House obj = x as ClassLibrary1.House;
                        dataGridView_department.Rows.Add(obj.pur, obj.name, obj.cost, obj.number, obj.count_level);
                    }
                    break;
                case "Коммерческая Недвижмость":
                    foreach (var x in dopp) // перебираем объекты 
                    {
                        ClassLibrary1.CommercialRealties obj = x as ClassLibrary1.CommercialRealties;
                        dataGridView_department.Rows.Add(obj.pur, obj.name, obj.cost, obj.naznach, obj.count_room);
                    }
                    break;
            }
            BlockColumns(0);
        }
        // блокируем столбцы начиная с заданной строки
        public void BlockColumns(int indRow)
        {
            // идем по строкам
            for (int i = indRow; i < dataGridView_department.Rows.Count; i++)
                // идем по столбцам
                for (int j = 0; j < dataGridView_department.Columns.Count; j++)
                    // блокируем столбцы с названиями Number и TimeOfGetting, тк по логике их менять нельзя
                    if (dataGridView_department.Columns[j].Name == "Number" || dataGridView_department.Columns[j].Name == "TimeOfGetting")
                        dataGridView_department[j, i].ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)//покупкаs
        {
            button1.Enabled = true;
            button7.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button4.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            ObjecrtRealties x = null;
            try
            {
                // смотрим по названию отдела(загаловка)
                switch (Text)
                {
                    case "Квартира":
                        // создаем объект формы для добавления
                        Apartment apartForm = new Apartment();
                        if (checkBox.Checked == true)
                            x = ClassLibrary1.Apartment.GetRandom();
                        //  Отмена
                        else if (apartForm.ShowDialog() == DialogResult.Cancel)
                            return;
                        else
                            x = apartForm.obj;
                        Forms.RC[Text].Buy(x);
                        // добавляем строку в таблицу
                        dataGridView_department.Rows.Add(x.pur, x.name, x.cost, (x as ClassLibrary1.Apartment).count_room);
                        break;
                    case "Магазин":
                        Shop SForm = new Shop();
                        if (checkBox.Checked == true)
                            x = ClassLibrary1.Shop.GetRandom();
                        else if (SForm.ShowDialog() == DialogResult.Cancel)
                            return;
                        else
                            x = SForm.obj;
                        Forms.RC[Text].Buy(x);
                        dataGridView_department.Rows.Add(x.pur, x.name, x.cost, (x as ClassLibrary1.Shop).nazvanie);
                        break;
                    case "Жилая Недвижимость":
                        Residential ResForm = new Residential();
                        if (checkBox.Checked == true)
                            x = Residential_Real_Estate.GetRandom();
                        else if (ResForm.ShowDialog() == DialogResult.Cancel)
                            return;
                        else
                            x = ResForm.obj;
                        Forms.RC[Text].Buy(x);
                        dataGridView_department.Rows.Add(x.pur, x.name, x.cost, (x as ClassLibrary1.Residential_Real_Estate).date);
                        break;
                    case "Дом":
                        House HForm = new House();
                        if (checkBox.Checked == true)
                            x = ClassLibrary1.House.GetRandom();
                        else if (HForm.ShowDialog() == DialogResult.Cancel)
                            return;
                        else
                            x = HForm.obj;
                        Forms.RC[Text].Buy(x);
                        dataGridView_department.Rows.Add(x.pur, x.name, x.cost, (x as ClassLibrary1.House).number, (x as ClassLibrary1.House).count_level);
                        break;
                    case "Коммерческая Недвижмость":
                        CommercialRealties CRForm = new CommercialRealties();
                        if (checkBox.Checked == true)
                            x = ClassLibrary1.CommercialRealties.GetRandom();
                        else if (CRForm.ShowDialog() == DialogResult.Cancel)
                            return;
                        else
                            x = CRForm.obj;
                        Forms.RC[Text].Buy(x);
                        dataGridView_department.Rows.Add(x.pur, x.name, x.cost, (x as ClassLibrary1.CommercialRealties).naznach, (x as ClassLibrary1.CommercialRealties).count_room);
                        break;
                }
                // блокируем столбцы добавленной строки
                BlockColumns(dataGridView_department.RowCount - 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e) //Продажа
        {
            if (dataGridView_department.Rows.Count == 1)
            {
                button1.Enabled = false;
                button7.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button4.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
            }
            ObjecrtRealties x = null;
            bool t1 = false;
            try
            {
                // если не выбрана ячейка
                if (dataGridView_department.SelectedCells.Count == 0)
                    throw new Exception("Выберите ячейку строки для удаления");
                // берем индекс строки ячейки
                int row = dataGridView_department.SelectedCells[0].RowIndex;
                // берем номер объекта в данной строке
                int number = Convert.ToInt32(dataGridView_department[0, row].Value);
                // берем объект по индексатору отдела
                string t = (dataGridView_department[0, row].Value.ToString());
                if (t == "True") t1 = true;
                string name = dataGridView_department[1, row].Value.ToString();
                int cost = Convert.ToInt32(dataGridView_department[2, row].Value.ToString());

                foreach (var k in Forms.RC[Text])
                {
                    if (k.name == name && k.pur == t1 && k.cost == cost)
                    {
                        x = k;
                    }
                }


                //удалеяем строку из таблицы
                dataGridView_department.Rows.RemoveAt(row);


                // удаляем объект 
                Forms.RC[Text].Sold(x);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_department_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Obj_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) //возвращаем main
        {
            // возвращаем главную форму
            Forms.Visible = true;
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e) //вернуть весь список
        {

            dopp = Forms.RC[Text];
            Write_in_Grid();
        }

        void CreateDG(IEnumerable<ObjecrtRealties> tr)
        {
            ClassLibrary1.Company com = new ClassLibrary1.Company(Text);
            foreach (var x in tr)
                com.Buy(x);
            dopp = com;
            Write_in_Grid();
        }
        private void button5_Click(object sender, EventArgs e) // в аренде 
        {
            dopp = Forms.RC[Text];
            Write_in_Grid();
            var res = dopp.Where(x => x.pur == true);
            CreateDG(res);
        }

        private void button6_Click(object sender, EventArgs e) //не в аренде 
        {
            dopp = Forms.RC[Text];
            Write_in_Grid();
            var res = dopp.Where(x => x.pur == false);
            CreateDG(res);
        }

        private void button4_Click(object sender, EventArgs e) //количество в таблице
        {
            int count = dopp.Count;
            MessageBox.Show($"Элементов базы '{Text}' == {count}");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    throw new Exception("Ошибка");
                }
                int c1 = Convert.ToInt32(textBox1.Text);
                int c2 = Convert.ToInt32(textBox2.Text);
                dopp = Forms.RC[Text];
                Write_in_Grid();
                var res = dopp.Where(x => x.cost < c2 && x.cost > c1);
                CreateDG(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void Obj_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.Visible = true;
            Close();
        }

        private void button9_Click(object sender, EventArgs e) //change
        {
            ObjecrtRealties x = null;
            ObjecrtRealties x2 = null;
            bool t1 = false;
            try
            {
                // если не выбрана ячейка
                if (dataGridView_department.SelectedCells.Count == 0)
                    throw new Exception("Выберите ячейку строки для изменения");
                // берем индекс строки ячейки
                int row = dataGridView_department.SelectedCells[0].RowIndex;
                // берем номер объекта в данной строке
                int number = Convert.ToInt32(dataGridView_department[0, row].Value);

                // берем объект по индексатору отдела
                string t = (dataGridView_department[0, row].Value.ToString());
                if (t == "True") t1 = true;
                string name = dataGridView_department[1, row].Value.ToString();
                int cost = Convert.ToInt32(dataGridView_department[2, row].Value.ToString());
                foreach (var k in Forms.RC[Text])
                {
                    if (k.name == name && k.pur == t1 && k.cost == cost)
                    {
                        x = k;
                    }
                }
                /////

                switch (Text)
                {
                    case "Квартира":
                        Apartment apartForm = new Apartment();
                        if (apartForm.ShowDialog() == DialogResult.Cancel)
                            return;
                        else
                            x2 = apartForm.obj;
                        dataGridView_department.Rows.RemoveAt(row);
                        Forms.RC[Text].ChangeOR(x, x2);
                        dataGridView_department.Rows.Add(x2.pur, x2.name, x2.cost, (x2 as ClassLibrary1.Apartment).count_room);
                        break;
                    case "Магазин":
                        Shop SForm = new Shop();
                        if (SForm.ShowDialog() == DialogResult.Cancel)
                            return;
                        else
                            x2 = SForm.obj;
                        dataGridView_department.Rows.RemoveAt(row);
                        Forms.RC[Text].ChangeOR(x, x2);
                        dataGridView_department.Rows.Add(x2.pur, x2.name, x2.cost, (x2 as ClassLibrary1.Shop).nazvanie);
                        break;

                    case "Жилая Недвижимость":
                        Residential ResForm = new Residential();
                        if (ResForm.ShowDialog() == DialogResult.Cancel)
                            return;
                        else
                            x2 = ResForm.obj;
                        dataGridView_department.Rows.RemoveAt(row);
                        Forms.RC[Text].ChangeOR(x, x2);
                        dataGridView_department.Rows.Add(x2.pur, x2.name, x2.cost, (x2 as ClassLibrary1.Residential_Real_Estate).date);
                        break;
                    case "Дом":
                        House HForm = new House();
                        if (HForm.ShowDialog() == DialogResult.Cancel)
                            return;
                        else
                            x2 = HForm.obj;
                        dataGridView_department.Rows.RemoveAt(row);
                        Forms.RC[Text].ChangeOR(x, x2);
                        dataGridView_department.Rows.Add(x2.pur, x2.name, x2.cost, (x2 as ClassLibrary1.House).number, (x2 as ClassLibrary1.House).count_level);
                        break;
                    case "Коммерческая Недвижмость":
                        CommercialRealties CRForm = new CommercialRealties();
                        if (CRForm.ShowDialog() == DialogResult.Cancel)
                            return;
                        else
                            x2 = CRForm.obj;
                        dataGridView_department.Rows.RemoveAt(row);
                        Forms.RC[Text].ChangeOR(x, x2);
                        dataGridView_department.Rows.Add(x2.pur, x2.name, x2.cost, (x2 as ClassLibrary1.CommercialRealties).naznach, (x2 as ClassLibrary1.CommercialRealties).count_room);
                        break;
                }
                ///
                // изменяем объект объект 
                //Forms.RC[Text].ChangeOR(x, x2);
                //foreach (var k in Forms.RC[Text])
                //{
                //    if (k.name == name && k.pur == t1 && k.cost == cost)
                //    {
                //        x = x2;
                //    }
                //}

                //удалеяем строку из таблицы
                //dataGridView_department.Rows.RemoveAt(row);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
