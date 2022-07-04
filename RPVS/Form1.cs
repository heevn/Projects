using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjectRPVS
{
    public partial class Form1 : Form
    {
        readonly Pen pen = new Pen(Color.Black);

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.save1;
            textBox2.Text = Properties.Settings.Default.save2;
            textBox3.Text = Properties.Settings.Default.save3;
            textBox4.Text = Properties.Settings.Default.save4;
            textBox5.Text = Properties.Settings.Default.savex;
            textBox6.Text = Properties.Settings.Default.savey;
            radioButton1.Checked = Properties.Settings.Default.ifChecked1;
            radioButton2.Checked = Properties.Settings.Default.ifChecked2;
            Properties.Settings.Default.Save();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // отрисовка изображения
            try
            {
                if (radioButton1.Checked)
                {
                    Circles.DrawRecursiveCircle(pen, e.Graphics, int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), float.Parse(textBox4.Text), panel1.Width / 2, panel1.Height / 2);

                }
                else if (radioButton2.Checked)
                {
                    Circles.DrawRecursiveCircle(pen, e.Graphics, int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), float.Parse(textBox4.Text), float.Parse(textBox5.Text), float.Parse(textBox6.Text));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат данных!");
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // выход и сохранение
            SaveLoad.Save(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, radioButton1.Checked, radioButton2.Checked);
            System.Windows.Forms.Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // меню "о программе"
            MessageBox.Show("Программа предназначена для рекурсивного отображения окружностей по заданным пользователем параметрам.", "О программе");
        }

        private void цвет_Click(object sender, EventArgs e)
        {
            // выбор цвета отрисовки
            Circles.ColorChoose(pen);
        }

        private void нарисовать_Click(object sender, EventArgs e)
        {
            // обновление панели
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel1.Refresh();
        }

        private void вывестиДанныеВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // открываем приложение
            var application = new Microsoft.Office.Interop.Excel.Application();

            // файл шаблона
            const string template = "template.xlsx";

            // открываем книгу
            var workBook = application.Workbooks.Open(Path.Combine(Environment.CurrentDirectory, template));

            // получаем активную таблицу
            var worksheet = workBook.ActiveSheet as Worksheet;

            // записываем данные
            worksheet.Range["A1"].Value = label1.Text;
            worksheet.Range["A2"].Value = label2.Text;
            worksheet.Range["A3"].Value = label3.Text;
            worksheet.Range["A4"].Value = label4.Text;
            worksheet.Range["D1"].Value = textBox1.Text;
            worksheet.Range["D2"].Value = textBox2.Text;
            worksheet.Range["D3"].Value = textBox3.Text;
            worksheet.Range["D4"].Value = textBox4.Text;

            // показываем приложение
            application.Visible = true;
            TopMost = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // сохранение при выходе нажатием на крестик
            SaveLoad.Save(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, radioButton1.Checked, radioButton2.Checked);
        }

        private void вывестиДанныеВWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var wordapp = new Microsoft.Office.Interop.Word.Application();
            wordapp.Visible = true;

            Object filename = @"D:\ProjectRPVS\ProjectRPVS\bin\Debug\example.docx";  // открываем существующий документ
            Object confirmConversions = true;
            Object readOnly = false;
            Object addToRecentFiles = true;
            Object passwordDocument = Type.Missing;
            Object passwordTemplate = Type.Missing;
            Object revert = false;
            Object writePasswordDocument = Type.Missing;
            Object writePasswordTemplate = Type.Missing;
            Object format = Type.Missing;
            Object encoding = Type.Missing; ;
            Object oVisible = Type.Missing;
            Object openConflictDocument = Type.Missing;
            Object openAndRepair = Type.Missing;
            Object documentDirection = Type.Missing;
            Object noEncodingDialog = false;
            Object xmlTransform = Type.Missing;
            var worddocument = wordapp.Documents.Open(ref filename,
            ref confirmConversions, ref readOnly, ref addToRecentFiles,
            ref passwordDocument, ref passwordTemplate, ref revert,
            ref writePasswordDocument, ref writePasswordTemplate,
            ref format, ref encoding, ref oVisible,
            ref openAndRepair, ref documentDirection, ref noEncodingDialog,
              ref xmlTransform);
 
            var wordparagraphs = worddocument.Paragraphs;  // получаем ссылки на параграфы документа
            
            var wordparagraph = wordparagraphs[1];  // будем работать с первым параграфом

            wordparagraph.Range.Text = $"Кол-во разных окружностей: {textBox1.Text}";   // выводим текст в первый параграф

            wordparagraph.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;  // меняем характеристики текста и параграфа
            
            object oMissing = System.Reflection.Missing.Value;  // добавляем в документ несколько параграфов
            worddocument.Paragraphs.Add(ref oMissing);
            worddocument.Paragraphs.Add(ref oMissing);
            worddocument.Paragraphs.Add(ref oMissing);
            worddocument.Paragraphs.Add(ref oMissing);
            worddocument.Paragraphs.Add(ref oMissing);
            wordparagraph = wordparagraphs[2];
            wordparagraph.Range.Text = $"Глубина рекурсии: {textBox2.Text}";
            wordparagraph = wordparagraphs[3];
            wordparagraph.Range.Text = $"Радиус главной окружности: {textBox3.Text}";
            wordparagraph = wordparagraphs[4];
            wordparagraph.Range.Text = $"Коэффициент уменьшения: {textBox4.Text}";
        }

        private void помощь_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, @"D:\ProjectRPVS\ProjectRPVS\Help.chm", HelpNavigator.TableOfContents);
        }
    }
}
