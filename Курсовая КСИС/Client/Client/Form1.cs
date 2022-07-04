using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace Client
{
    public partial class Form1 : Form
    {
        private char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' ', '.' };
        static private int port = 8005;
        static private string address;
        static private string ClientName;
        static private byte[] data;
        static private int key_open;
        static private int key_close;
        static private int n;
        static private int st_key_open;
        static private int st_n;
        static private bool flag_connect = false;

        private static IPEndPoint ipPoint;
        private static Socket socket;
        
        
        public Form1()
        {
            InitializeComponent();
        }

        public int _Key_s
        {
            set { key_close = value; }
        }

        public int _Key_o
        {
            set { key_open = value; }
        }

        public int _n
        {
            set { n = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!flag_connect)
            {
                if (checkBox1.Checked)
                {
                    if (key_close > 0)
                    {
                        textBox3.Text = key_close.ToString();
                    }
                    else
                    {
                        MessageBox.Show("ERROR: ошибка ключа !", "ERROR");
                    }

                    if (key_open > 0)
                    {
                        textBox6.Text = key_open.ToString();
                    }
                    else
                    {
                        MessageBox.Show("ERROR: ошибка ключа !", "ERROR");
                    }

                    if (n > 0)
                    {
                        textBox7.Text = n.ToString();
                    }
                    else
                    {
                        MessageBox.Show("ERROR: ошибка ключа !", "ERROR");
                    }

                    if (textBox8.Text != "0")
                    {
                        st_key_open = Convert.ToInt32(textBox8.Text);
                    }
                    else
                    {
                        MessageBox.Show("ERROR: ошибка ключа !", "ERROR");
                    }

                    if (textBox9.Text != "0")
                    {
                        st_n = Convert.ToInt32(textBox9.Text);
                    }
                    else
                    {
                        MessageBox.Show("ERROR: ошибка ключа !", "ERROR");
                    }
                    checkBox1.Enabled = false;
                }
                else
                {
                    checkBox1.Enabled = false;
                }

                if (textBox5.Text != null)
                {
                    address = textBox5.Text;
                }
                else
                {
                    MessageBox.Show("ERROR: вы оставили пустые поля !", "ERROR");
                }

                if (textBox4.Text != null)
                {
                    ClientName = textBox4.Text;
                }
                else
                {
                    MessageBox.Show("ERROR: вы оставили пустые поля !", "ERROR");
                }

                ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);
                byte[] data;
                data = Encoding.Unicode.GetBytes(ClientName + " - ");
                socket.Send(data);
                timer1.Enabled = true;
                flag_connect = true;
                MessageBox.Show("Вы подключены.", "Подключение");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag_connect)
            {
                string message = "";
                if (textBox1 == null)
                {
                    MessageBox.Show("В поле сообщения ничего нет!");
                }
                else
                {
                    if (checkBox1.Checked)
                    {
                        message = textBox1.Text;
                        byte[] data;
                        data = Encoding.Unicode.GetBytes(ClientName + ": " + Crypt(message));
                        socket.Send(data);
                        textBox1.Text = "";
                    }
                    else
                    {
                        message = textBox1.Text;
                        byte[] data;
                        data = Encoding.Unicode.GetBytes(ClientName + ": " + message);
                        socket.Send(data);
                        textBox1.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("ERROR:не установлено подключение!", "ERROR");
            }

        }

        public int GetIndexAlphabet(char c)
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (c == alphabet[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public string CryptText(string text, int Ko, int n)
        {
            string outStr = "";

            int num;
            for (int i = 0; i < text.Length; i++)
            {
                int ret = 1;
                if (GetIndexAlphabet(text[i]) != -1)
                {
                    num = GetIndexAlphabet(text[i]) + 2;
                    for (int j = 0; j < Ko; j++)
                    {
                        ret = (ret * num) % n;
                    }
                    outStr += (char)(ret + 1);
                }
                else
                {
                    outStr += text[i];
                }
            }
            return outStr;
        }


        public string EnCryptText(string text, int Ks, int n)
        {
            string outStr = "";

            int num;
            for (int i = 0; i < text.Length; i++)
            {
                int ret = 1;
                /*if (text[i] != ' ')
                {*/
                num = (int)text[i] - 1;
                for (int j = 0; j < Ks; j++)
                {
                    ret = (ret * num) % n;
                }

                if (ret - 1 < 25) //ret - 2
                {
                    outStr += alphabet[ret - 2];
                }
                else
                {
                    outStr += text[i];
                }

            }
            return outStr;
        }

        public string Crypt(string message)
        {
            string crypt_str = "";
            int x = 0;
            int y = 0;
            int d = this.EuclidExtended(12, Convert.ToInt32(textBox3.Text), out x, out y);
            if (y < 0)
            {
                y += 12;
            }

            crypt_str = CryptText(message, st_key_open, st_n);
           
            return crypt_str;
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


        public string Encrypt(string crypt_str)
        {
            string Encrypt_str = "";
            Encrypt_str = EnCryptText(crypt_str, key_close, n);
            return Encrypt_str;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag_connect)
            {
                if (checkBox1.Checked)
                {
                    if (socket.Available > 0)
                    {
                        data = new byte[256]; // буфер для ответа
                        StringBuilder builder = new StringBuilder();
                        int bytes;

                        bytes = socket.Receive(data, data.Length, 0);

                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        string str = builder.ToString();
                        textBox2.AppendText(str.Remove(str.IndexOf(":",4)+ 1,str.Length - str.IndexOf(":",4) - 1 ) + " " + Encrypt(str.Remove(0, str.IndexOf(":",4) + 2)) + Environment.NewLine);
                    }
                }
                else
                {
                    if (socket.Available > 0)
                    {
                        data = new byte[256]; // буфер для ответа
                        StringBuilder builder = new StringBuilder();
                        int bytes;

                        bytes = socket.Receive(data, data.Length, 0);

                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        string str = builder.ToString();
                        textBox2.AppendText(str + Environment.NewLine);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            textBox3.Text = key_close.ToString();
            textBox6.Text = key_open.ToString();
            textBox7.Text = n.ToString();
            if (key_close != 0)
            {
                timer2.Stop();
                timer2.Enabled = false;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", "help.txt");
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данная программа представляет чат с шифрованием RSA. Работает это программа на сокетах TCP и передает по ним защищенное сообщение.", "О программе");
        }
    }

}
