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
    public partial class AddNounForm : Form
    {
        string spath = "nouns.xml";
        List<string> Items = new List<string>();

        public AddNounForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNoun.Text))
            {
                MessageBox.Show("Please enter a noun!");
                return;
            }

            XDocument doc = XDocument.Load(spath);

            //if (doc.ToString().ToLower().Contains(txtNoun.Text.Trim().ToLower()))
            //{
            //    doc = null;
            //    MessageBox.Show("This noun has been already added!");
            //    return;
            //}

            XElement root = new XElement("noun");
            root.Add(new XElement("key", txtNoun.Text.Trim().Replace(' ', '-')));
            root.Add(new XElement("value", txtNoun.Text.Trim()));
            doc.Element("nouns").Add(root);

            doc.Save(spath);

            doc = null;

            this.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNounForm_Load(object sender, EventArgs e)
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

        private void txtNoun_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(Items.Where(x => x.StartsWith(txtNoun.Text.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToArray());
        }
    }
}
