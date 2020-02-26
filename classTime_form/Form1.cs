using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace classTime_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
                InitializeComponent();
                comboBox1.Text = comboBox1.Items[0].ToString();
                comboBox2.Text = comboBox2.Items[0].ToString();
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Time temp;
            float num;
            try
            {
                string selectedState = comboBox1.SelectedItem.ToString();
                temp = new Time(textBox1.Text);

                switch (selectedState)
                {
                    case "в секунды":
                        num = (float)temp.ToSecond;
                        result.Text = num.ToString();
                        break;
                    case "в минуты ":
                        num = (float)Math.Round(c1.Abs(), 4);
                        result.Text = num.ToString();
                        break;
                    case "в часы":
                        c1.ToExponential();
                        result.Text = c1.Re.ToString() + "*e^i" +
                            c1.Im.ToString() + "°";
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Ошибка: {exception.Message}");
            }
        }
    }
}
