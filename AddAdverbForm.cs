using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Alev
{
    public partial class AddAdverbForm : Form
    {
        string spath = "adverbs.xml";
        List<string> Items = new List<string>();

        public AddAdverbForm()
        {
            InitializeComponent();
        }

        private void AddAdverbForm_Load(object sender, EventArgs e)
        {
            txtNoun.Text = "";

            XmlDocument doc2 = new XmlDocument();
            doc2.Load(spath);
            XmlNodeList node = doc2.GetElementsByTagName("value");

            foreach (XmlNode xn in node)
            {
                Items.Add(xn.InnerText);
            }

            Items = Items.OrderBy(x => x).ToList();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNoun.Text))
            {
                MessageBox.Show("Please enter an adverb!");
                return;
            }

            XDocument doc = XDocument.Load(spath);

            XElement root = new XElement("adverb");
            root.Add(new XElement("key", "adv" + txtNoun.Text.Trim().Replace(' ', '-')));
            root.Add(new XElement("value", txtNoun.Text.Trim()));
            doc.Element("adverbs").Add(root);

            doc.Save(spath);

            doc = null;

            this.Close();
        }

        private void txtNoun_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(Items.Where(x => x.StartsWith(txtNoun.Text.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToArray());
        }
    }
}
