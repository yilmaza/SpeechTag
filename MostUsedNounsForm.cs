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
    public partial class MostUsedNounsForm : Form
    {
        public Dictionary<string, List<int>> NounInfo { get; set; }

        public MostUsedNounsForm()
        {
            InitializeComponent();
        }

        private void MostUsedNounsForm_Load(object sender, EventArgs e)
        {
            // load items
            
            var _priceDataArray = from row in NounInfo
                                  orderby (row.Value[0] + row.Value[1]) descending
                                  select new
            {
                Noun = row.Key,
                TotalUse = row.Value[0] + row.Value[1],
                CorrectUse = row.Value[0],
                CorrectUsePerc = Math.Round((decimal)row.Value[0] / (decimal)(row.Value[0] + row.Value[1]) * 100, 2),
                IncorrectUse = row.Value[1],
                IncorrectUsePerc = Math.Round((decimal)row.Value[1] / (decimal)(row.Value[0] + row.Value[1]) * 100, 2)
            };

            dataGridView1.AutoGenerateColumns = false;

            BindingSource bs = new BindingSource();
            bs.DataSource = _priceDataArray;

            dataGridView1.DataSource = bs;
        }
    }
}
