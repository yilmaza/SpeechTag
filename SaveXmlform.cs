using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alev
{
    public partial class SaveXmlform : Form
    {
        public string Text { get; set; }
        public RichTextBox Rtb { get; set; }

        public SaveXmlform()
        {
            InitializeComponent();
        }

        private void SaveXmlform_Load(object sender, EventArgs e)
        {
            richTextBox1.Rtf = Rtb.Rtf;
            //Helper.SaveMyFile(richTextBox1);
            SaveFile();
        }

        private void SaveFile()
        {
            string[] list;
            StringBuilder yeniKelime = new StringBuilder();
            int start, end;

            while (richTextBox1.Text.IndexOf('[') > -1)
            {
                start = richTextBox1.Text.IndexOf('[');
                end = richTextBox1.Text.IndexOf(']');
                yeniKelime.Clear();

                if (end <= start)
                {
                    MessageBox.Show("Kelime dizisi hatasi!");
                    return;
                }

                list = richTextBox1.Text.Substring(start + 1, end - start - 1).Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in list)
                {
                    yeniKelime.Append("<" + item + ">");
                }

                richTextBox1.SelectionStart = start;
                richTextBox1.SelectionLength = end - start + 1;
                richTextBox1.SelectionFont = new Font("Calibri", 10, FontStyle.Italic);
                richTextBox1.SelectionColor = Color.Black;

                Clipboard.SetText(yeniKelime.ToString());
                richTextBox1.Paste();
            }
        }
    }
}
