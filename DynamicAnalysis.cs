using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Alev
{
    public partial class DynamicAnalysis : Form
    {
        public Dictionary<string, List<int>> Info { get; set; }
        List<string> keywords = new List<string>();

        public DynamicAnalysis()
        {
            InitializeComponent();
        }

        private void DynamicAnalysis_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void LoadItems()
        {
            tvActions.Nodes.Clear();

            #region actions
            tvActions.Nodes.Add("Personal pronoun suffixes");
            tvActions.Nodes[0].Nodes.Add("p1s", "p1s");
            tvActions.Nodes[0].Nodes.Add("p2s", "p2s");
            tvActions.Nodes[0].Nodes.Add("p3s", "p3s");
            tvActions.Nodes[0].Nodes.Add("p1p", "p1p");
            tvActions.Nodes[0].Nodes.Add("p2p", "p2p");
            tvActions.Nodes[0].Nodes.Add("p3p", "p3p");

            tvActions.Nodes.Add("Possessive pronoun suffixes");
            tvActions.Nodes[1].Nodes.Add("pss1s", "pss1s");
            tvActions.Nodes[1].Nodes.Add("pss2s", "pss2s");
            tvActions.Nodes[1].Nodes.Add("pss3s", "pss3s");
            tvActions.Nodes[1].Nodes.Add("pss1p", "pss1p");
            tvActions.Nodes[1].Nodes.Add("pss2p", "pss2p");
            tvActions.Nodes[1].Nodes.Add("pss3p", "pss3p");

            tvActions.Nodes.Add("Exist", "Existential");
            tvActions.Nodes.Add("ExistNeg", "Existential Neg");
            tvActions.Nodes.Add("Hvow", "Vowel harmony");
            tvActions.Nodes.Add("Hcons", "Consonant harmony");

            tvActions.Nodes.Add("Cases of the noun");
            tvActions.Nodes[6].Nodes.Add("dat", "dative");
            tvActions.Nodes[6].Nodes.Add("loc", "locative");
            tvActions.Nodes[6].Nodes.Add("abl", "ablative");
            //tvActions.Nodes[6].Nodes.Add("ins", "instrumental");// sil
            //tvActions.Nodes[6].Nodes.Add("gen", "genetive");// sil
            tvActions.Nodes[6].Nodes.Add("acc", "accusative");
            tvActions.Nodes[6].Nodes.Add("nom", "nominative");

            tvActions.Nodes.Add("buff", "Buffer letter");

            tvActions.Nodes.Add("Q", "Question particle");

            tvActions.Nodes.Add("Negation");
            tvActions.Nodes[9].Nodes.Add("NegmA", "Neg mA");
            tvActions.Nodes[9].Nodes.Add("Değil", "Değil");

            tvActions.Nodes.Add("prep", "Preposition");

            tvActions.Nodes.Add("Tenses");
            tvActions.Nodes[11].Nodes.Add("Tprog", "Present progressive tense suffix");
            tvActions.Nodes[11].Nodes.Add("Tpres", "Simple present tense");
            tvActions.Nodes[11].Nodes.Add("Tpast", "Past tense suffix (DI)");
            tvActions.Nodes[11].Nodes.Add("TInEvPast", "Indirect evidence past tense");
            tvActions.Nodes[11].Nodes.Add("PastCon", "Past continous");
            tvActions.Nodes[11].Nodes.Add("futur", "Future tense");

            tvActions.Nodes.Add("plr", "Plural suffix");
            tvActions.Nodes.Add("partip", "Participles");
            tvActions.Nodes.Add("Adv", "Adverb");
            tvActions.Nodes.Add("Adj", "Adjective");
            // tvActions.Nodes.Add("postPos", "Post position");// sil
            tvActions.Nodes.Add("part", "Particles");
            tvActions.Nodes.Add("Conj", "Conjunction");
            tvActions.Nodes.Add("Intj", "Interjection");
            tvActions.Nodes.Add("Abil", "Ability");
            tvActions.Nodes.Add("iuon", "Incorrect use of noun");
            tvActions.Nodes.Add("softCons", "Softening of consonants");
            tvActions.Nodes.Add("pron", "Prononciation");
            tvActions.Nodes.Add("RepSp", "Reported speech");
            tvActions.Nodes.Add("necc", "Necessity");
            tvActions.Nodes.Add("wOrder", "Word order");
            tvActions.Nodes.Add("con", "If conditional");
            tvActions.Nodes.Add("req", "Request");
            tvActions.Nodes.Add("impr", "Imperative");
            tvActions.Nodes.Add("compNoun", "Compound noun");
            #endregion

            tvActions.Nodes[0].ExpandAll();
            tvActions.Nodes[1].ExpandAll();
            tvActions.Nodes[6].ExpandAll();
            tvActions.Nodes[9].ExpandAll();
            tvActions.Nodes[11].ExpandAll();

            tabControl1.SelectedTab = tabControl1.TabPages[2];
            tvActions.Nodes[0].EnsureVisible();

            Helper.HideCheckBox(tvActions, tvActions.Nodes[0]);
            Helper.HideCheckBox(tvActions, tvActions.Nodes[1]);
            Helper.HideCheckBox(tvActions, tvActions.Nodes[6]);
            Helper.HideCheckBox(tvActions, tvActions.Nodes[9]);
            Helper.HideCheckBox(tvActions, tvActions.Nodes[11]);

            LoadDynamicItems();
        }

        void LoadDynamicItems()
        {
            Helper.LoadDynamicItem(tvNouns, ItemType.Nouns);
            Helper.LoadDynamicItem(tvVerbs, ItemType.Verbs);
        }

        private void GetSelecteds()
        {
            keywords.Clear();

            GetSelectedsRecursive(tvActions.Nodes);
            GetSelectedsRecursive(tvVerbs.Nodes);
            GetSelectedsRecursive(tvNouns.Nodes);

            var query = Info.Where(x => keywords.Contains(x.Key));

            var _priceDataArray = from row in query
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
            bs.DataSource = _priceDataArray.OrderBy(x => x.Noun);

            dataGridView1.DataSource = bs;
        }

        void GetSelectedsRecursive(TreeNodeCollection nodes)
        {
            foreach (TreeNode child in nodes)
            {
                if (child.Nodes.Count == 0 && child.Checked)
                {
                    keywords.Add(child.Name);
                }
                else
                {
                    GetSelectedsRecursive(child.Nodes);
                }
            }
        }

        private void tvVerbs_AfterCheck(object sender, TreeViewEventArgs e)
        {
            GetSelecteds();
        }

        private void tvNouns_AfterCheck(object sender, TreeViewEventArgs e)
        {
            GetSelecteds();
        }

        private void tvAdjectives_AfterCheck(object sender, TreeViewEventArgs e)
        {
            GetSelecteds();
        }

        private void tvActions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            GetSelecteds();
        }

        private void cleanAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanTreesRecursive(tvActions.Nodes);
            CleanTreesRecursive(tvVerbs.Nodes);
            CleanTreesRecursive(tvNouns.Nodes);

            GetSelecteds();
        }

        void CleanTreesRecursive(TreeNodeCollection nodes)
        {
            foreach (TreeNode child in nodes)
            {
                if (child.Nodes.Count == 0 && child.Checked)
                {
                    child.Checked = false;
                }
                else
                {
                    CleanTreesRecursive(child.Nodes);
                }
            }
        }
    }
}
