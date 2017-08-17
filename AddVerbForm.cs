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
    public partial class AddVerbForm : Form
    {
        List<string> Items = new List<string>();
        string spath = "verbs.xml";

        public AddVerbForm()
        {
            InitializeComponent();
        }

        private void AddVerbForm_Load(object sender, EventArgs e)
        {
            txtVerb.Text = "";
            
            XmlDocument doc2 = new XmlDocument();
            doc2.Load(spath);
            XmlNodeList node = doc2.GetElementsByTagName("value");

            foreach (XmlNode xn in node)
            {
                Items.Add(xn.InnerText);
            }

            Items = Items.OrderBy(x => x).ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVerb.Text))
            {
                MessageBox.Show("Please enter a verb!");
                return;
            }

            XDocument doc = XDocument.Load(spath);

            //if (doc.ToString().ToLower().Contains(txtVerb.Text.Trim().ToLower()))
            //{
            //    doc = null;
            //    MessageBox.Show("This verb has been already added!");
            //    return;
            //}

            XElement root = new XElement("verb");
            root.Add(new XElement("key", txtVerb.Text.Trim().Replace(' ', '-')));
            root.Add(new XElement("value", txtVerb.Text.Trim()));
            doc.Element("verbs").Add(root);

            doc.Save(spath);

            doc = null;

            this.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtVerb_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(Items.Where(x => x.StartsWith(txtVerb.Text.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToArray());
        }
    }
}
