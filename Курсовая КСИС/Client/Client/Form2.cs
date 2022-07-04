using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public int NOD(int a, int b)
        {
            while (true)
            {
                if (a == 0 || b == 0)
                {
                    break;
                }
                else
                {
                    if (a > b)
                    {
                        a = a % b;
                    }
                    else
                    {
                        b = b % a;
                    }
                }
            }
            return a + b;
        }

        private void tbP_Leave(object sender, EventArgs e)
        {
            if (tbP.Text != "")
            {
                if (!SimpleDigit(Convert.ToInt32(tbP.Text)))
                {
                    tbP.Text = "";
                    MessageBox.Show("Число должно быть простым!");
                }
                if (tbQ.Text != "")
                {
                    tbN1.Text = (Convert.ToInt32(tbP.Text) * Convert.ToInt32(tbQ.Text)).ToString();
                    tbFi.Text = Convert.ToString((Convert.ToInt32(tbP.Text) - 1) * (Convert.ToInt32(tbQ.Text) - 1));
                }
            }
        }

        private void tbKs_Leave(object sender, EventArgs e)
        {
            if (tbKs.Text != "")
            {
                if (NOD(Convert.ToInt32(tbKs.Text), Convert.ToInt32(tbFi.Text)) != 1)
                {
                    MessageBox.Show("Число должно быть взаимнопростым с фи!");
                    tbKs.Text = "";
                }
                else
                {
                    int x;
                    int y;
                    int d = this.EuclidExtended(Convert.ToInt32(tbFi.Text), Convert.ToInt32(tbKs.Text), out x, out y);
                    if (y < 0)
                    {
                        y += Convert.ToInt32(tbFi.Text);
                    }
                    tbKo.Text = y.ToString();
                }
            }
        }


        public bool SimpleDigit(int y)
        {
            for (int i = y - 1; i > 1; i--)
            {
                if (y % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public int EuclidExtended(int a, int b, out int x, out int y)
        {
            int q, r, x1, x2, y1, y2, d;

            if (b == 0)
            {
                d = a;
                x = 1;
                y = 0;
                return d;
            }

            x2 = 1;
            x1 = 0;
            y2 = 0;
            y1 = 1;

            while (b > 0)
            {

                q = a / b;
                r = a - q * b;

                x = x2 - q * x1;
                y = y2 - q * y1;

                a = b;
                b = r;

                x2 = x1;
                x1 = x;
                y2 = y1;
                y1 = y;

            }

            d = a;
            x = x2;
            y = y2;

            return d;
        }
        private void tbQ_Leave(object sender, EventArgs e)
        {
            if (tbQ.Text != "")
            {
                if (!SimpleDigit(Convert.ToInt32(tbQ.Text)))
                {
                    tbQ.Text = "";
                    MessageBox.Show("Число должно быть простым!");
                }
                if (tbP.Text != "")
                {
                    tbN1.Text = (Convert.ToInt32(tbP.Text) * Convert.ToInt32(tbQ.Text)).ToString();
                    tbFi.Text = Convert.ToString((Convert.ToInt32(tbP.Text) - 1) * (Convert.ToInt32(tbQ.Text) - 1));
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form._Key_s = Convert.ToInt32(tbKs.Text);
            form._Key_o = Convert.ToInt32(tbKo.Text);
            form._n = Convert.ToInt32(tbN1.Text);
            MessageBox.Show("Параметры ключа применены", "Ключ");
            this.Close();
        }
    }
}
