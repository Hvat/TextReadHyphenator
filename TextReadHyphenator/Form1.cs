using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHyphenator;
using NHyphenator.Loaders;

namespace TextReadHyphenator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            richTextBox1.TextChanged += richTextBox1_TextChanged;
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            var loader = new FilePatternsLoader("d:/repos/textreadhyphenator/nhyphenator/nhyphenator/resurses/hyph-ru.pat.txt",
                "d:/repos/textreadhyphenator/nhyphenator/nhyphenator/resurses/hyph-ru.hyp.txt");
            Hyphenator hypenator = new Hyphenator(loader);
            richTextBox1.Text = hypenator.HyphenateText(richTextBox1.Text);
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Новый текст
            richTextBox1.Clear();     
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Открываем существующий файл
            OpenFileDialog open = new OpenFileDialog();

            open.DefaultExt = "*.txt";
            open.Filter = "TXT Files|*.txt|RTF Files|*.rtf|HTML Files|*.html|All Files|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(open.FileName, RichTextBoxStreamType.PlainText);
                Text = open.FileName;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Сохраняем файл
            SaveFileDialog sav = new SaveFileDialog();

            sav.DefaultExt = "*.txt";
            sav.Filter = "TXT Files|*.txt|RTF Files|*.rtf|HTML Files|*.html|All Files|*.*";
            if (sav.ShowDialog() == DialogResult.OK && sav.FileName.Length > 0)
            {
                richTextBox1.SaveFile(sav.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Выход из приложения
            Application.Exit();
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Отменяем предыдущую операцию
            richTextBox1.Undo();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Вырезаем выделенный текст
            richTextBox1.Cut();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Копируем выделенный текст
            richTextBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Вставляем из буфера
            richTextBox1.Paste();
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Выделяем весь текст
            richTextBox1.SelectAll();
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Выбираем шрифт
           
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }    
        }
    }
}
