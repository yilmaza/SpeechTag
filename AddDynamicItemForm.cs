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
    public partial class AddDynamicItemForm : Form
    {
        ItemType itemType;
        List<string> Items = new List<string>();
        string itemNameSingular;
        string itemNamePlural;
        string itemNamePluralLowerCase;
        string itemNameSingularLowerCase;

        public AddDynamicItemForm(ItemType itemType)
        {
            this.itemType = itemType;
            itemNamePlural = itemType.ToString();
            itemNamePluralLowerCase = itemType.ToString().ToLower().Replace('ı', 'i');
            itemNameSingular = itemNamePlural.Substring(0, itemType.ToString().Length - 1);
            itemNameSingularLowerCase = itemNamePlural.Substring(0, itemType.ToString().Length - 1).ToLower().Replace('ı', 'i');

            InitializeComponent();
        }

        private void AddDynamicItemForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Enter " + itemNameSingular + ":";
            this.Text = "Add " + itemNameSingular;

            txtNoun.Text = "";

            XmlDocument doc2 = new XmlDocument();
            doc2.Load(itemNamePluralLowerCase + ".xml");
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

        private void txtNoun_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(Items.Where(x => x.StartsWith(txtNoun.Text.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToArray());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNoun.Text))
            {
                MessageBox.Show("Please enter " + itemNameSingularLowerCase + "!");
                return;
            }

            XDocument doc = XDocument.Load(itemNamePluralLowerCase + ".xml");

            XElement root = new XElement(itemNameSingularLowerCase);
            root.Add(new XElement("key", itemNameSingular.Substring(0, 3) + txtNoun.Text.Trim().Replace(' ', '-')));
            root.Add(new XElement("value", txtNoun.Text.Trim()));
            doc.Element(itemNamePluralLowerCase).Add(root);

            doc.Save(itemNamePluralLowerCase + ".xml");

            doc = null;

            this.Close();
        }
    }
}
