using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2k2SemLabs_2
{
    public partial class Form1 : Form
    {

        List<Airplane> listAirs= new List<Airplane>();
       
        public Form1()
        {
            InitializeComponent();
            ID_Airplane.Validating += ID_Validating;
            comboModel.Validating += Model_Validating;
            countBox.Validating += Count_Validating;
            carryingBox.Validating += Carrying_Validating;
            fioBox.Validating += FIO_Validating;
            postBox.Validating += Post_Validating;
            ageBox.Validating += Age_Validating;
        }

        private void ID_Validating(object sender, CancelEventArgs e) 
        {
            if (String.IsNullOrEmpty(ID_Airplane.Text))
            {
                errorProvider1.SetError(ID_Airplane, "Не указан ID!");
                ID_Airplane.BackColor = ColorTranslator.FromHtml("#FFCBCD");

            }
            else if (ID_Airplane.Text.Length < 8)
            {
                errorProvider1.SetError(ID_Airplane, "Слишком короткий ID!");
                ID_Airplane.BackColor = ColorTranslator.FromHtml("#FFCBCD");
            }
            else { 
                errorProvider1.Clear();
                ID_Airplane.BackColor = Color.White;
              
            }
        }

        private void Type_Validating(object sender, CancelEventArgs e)
        {
            bool checks = false;
            foreach (RadioButton rdbut in typePanel.Controls)
                if (rdbut.Checked) checks = true;
            if (!checks)
            {
                errorProvider1.SetError(typePanel, "Выберите тип!");
                typePanel.BackColor = ColorTranslator.FromHtml("#FFCBCD");
            }
            else
            {
                errorProvider1.Clear();
                typePanel.BackColor = Color.WhiteSmoke;
            }
        }
        private void Model_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(comboModel.Text))
            {
                errorProvider1.SetError(comboModel, "Выберите модель!");
                comboModel.BackColor = ColorTranslator.FromHtml("#FFCBCD");
            }
            else
            {
                errorProvider1.Clear();
                comboModel.BackColor = Color.White;
            }

        }

        private void Count_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(countBox.Text))
            {
                errorProvider1.SetError(countBox, "Введите количество мест!");
                countBox.BackColor = ColorTranslator.FromHtml("#FFCBCD");

            }
            else if (countBox.Text.StartsWith("0"))
            {
                errorProvider1.SetError(countBox, "Количество не может начинаться с 0!");
                countBox.BackColor = ColorTranslator.FromHtml("#FFCBCD");
            }
            else
            {
                errorProvider1.Clear();
                countBox.BackColor = Color.White;
            }
        }
        private void Carrying_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(carryingBox.Text))
            {
                errorProvider1.SetError(carryingBox, "Введите грузоподъемность!");
                carryingBox.BackColor = ColorTranslator.FromHtml("#FFCBCD");

            }
            else if (carryingBox.Text.StartsWith("0"))
            {
                errorProvider1.SetError(carryingBox, "Грузоподъемность не может начинаться с 0!");
               carryingBox.BackColor = ColorTranslator.FromHtml("#FFCBCD");
            }
            else if (Convert.ToInt32(carryingBox.Text)<=100)
            {
                errorProvider1.SetError(carryingBox, "Грузоподъемность не может быть меньше 100 кг!");
                carryingBox.BackColor = ColorTranslator.FromHtml("#FFCBCD");
            }
            else
            {
                errorProvider1.Clear();
                carryingBox.BackColor = Color.White;
            }
        }

        private void FIO_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(fioBox.Text))
            {
                errorProvider1.SetError(fioBox, "Укажите ФИО!");
                fioBox.BackColor = ColorTranslator.FromHtml("#FFCBCD");

            }
            else
            {
                errorProvider1.Clear();
                fioBox.BackColor = Color.White;
            }
        }
        private void Post_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(postBox.Text))
            {
                errorProvider1.SetError(postBox, "Выберите должность!");
               postBox.BackColor = ColorTranslator.FromHtml("#FFCBCD");
            }
            else
            {
                errorProvider1.Clear();
                postBox.BackColor = Color.White;
            }

        }

        private void Age_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(ageBox.Text))
            {
                errorProvider1.SetError(ageBox, "Введите возраст!");
                ageBox.BackColor = ColorTranslator.FromHtml("#FFCBCD");

            }
            else if (ageBox.Text.StartsWith("0"))
            {
                errorProvider1.SetError(ageBox, "Возраст не может начинаться с 0!");
                ageBox.BackColor = ColorTranslator.FromHtml("#FFCBCD");
            }
            else if (Convert.ToInt32(ageBox.Text)<18)
            {
                errorProvider1.SetError(ageBox, "Сотруднику не может быть меньше 18 лет!");
                ageBox.BackColor = ColorTranslator.FromHtml("#FFCBCD");
            }
            else
            {
                errorProvider1.Clear();
                ageBox.BackColor = Color.White;
            }
        }
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
           
            label9.Text = String.Format("Стаж: {0} г.", ((TrackBar)sender).Value);
        }

        private bool IsTrueDataAirs()
        {
            bool checks = false;
            foreach (RadioButton rdbut in typePanel.Controls)
                if (rdbut.Checked) checks = true;

            if (ID_Airplane.MaskCompleted && checks && comboModel.Text.Length!=0 && countBox.Text!="0" && countBox.Text.Length!=0 && dateRels.Value > dateServis.Value && carryingBox.Text.Length!=0 && Convert.ToInt32(carryingBox.Text)>=100) return true;
            else return false;
        }
        private void AddAirplButton_Click(object sender, EventArgs e)
        {
            string typeAir = "";
            foreach (RadioButton rdbut in typePanel.Controls)
                if (rdbut.Checked) typeAir = rdbut.Text;

            if (typeAir == "") { typePanel.BackColor = ColorTranslator.FromHtml("#FFCBCD"); return; }
            else { typePanel.BackColor = Color.WhiteSmoke; }

            if (IsTrueDataAirs())
            {
                try
                {
                    Crewmate cr = new Crewmate();
                    Airplane airpl = new Airplane(ID_Airplane.Text, dateRels.Text, dateServis.Text, comboModel.Text, typeAir, Convert.ToUInt16(countBox.Text), Convert.ToInt32(carryingBox.Text), cr);
                    listAirs.Add(airpl);
                    airplansListBox.Items.Add(airpl);
                }
                catch (Exception)
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            else MessageBox.Show("Введены неверные данные!");
   
        }


        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Display a horizontal scroll bar.
           ((ListBox)sender).HorizontalScrollbar = true;

            // Create a Graphics object to use when determining the size of the largest item in the ListBox.
            Graphics g = ((ListBox)sender).CreateGraphics();

            // Determine the size for HorizontalExtent using the MeasureString method using the last item in the list.
            int hzSize = (int)g.MeasureString(((ListBox)sender).Items[((ListBox)sender).Items.Count - 1].ToString(), ((ListBox)sender).Font).Width;
            // Set the HorizontalExtent property.
            ((ListBox)sender).HorizontalExtent = hzSize;
        }
        private bool IsTrueDataCrew()
        {
            if (fioBox.Text.Length!=0 && postBox.SelectedItem != null && Convert.ToInt32(ageBox.Text)> 18 && Convert.ToInt32(ageBox.Text) - exspiTrackBar.Value > 18 && airplansListBox.SelectedItems.Count!=0) return true;
            else return false;
        }
        private void AddDate_Click(object sender, EventArgs e)
        {
            SaveBox.Items.Add(airplansListBox.SelectedItem);
        }

        private void AddCrewmate_Click(object sender, EventArgs e)
        {
            if (IsTrueDataCrew())
            {
                Crewmate NewCrew = new Crewmate(fioBox.Text, Convert.ToInt32(ageBox.Text), exspiTrackBar.Value, postBox.Text);

                for (int i = 0; i < listAirs[airplansListBox.SelectedIndex].CrewList.Count; i++)
                {
                    if (listAirs[airplansListBox.SelectedIndex].CrewList[i].ToString() == "00")
                    {
                        listAirs[airplansListBox.SelectedIndex].CrewList.Insert(i, NewCrew);
                        break;
                    }

                }
            }
            else MessageBox.Show("Введены неверные данные!");
        }
    }
}
