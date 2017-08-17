using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alev
{
    public partial class MultipleAnalysisForm : Form
    {
        List<string> keywords = new List<string>();
        Dictionary<string, Dictionary<string, Dictionary<int, List<int>>>> Info = new Dictionary<string, Dictionary<string, Dictionary<int, List<int>>>>();
        Dictionary<string, string> DictKeyword = new Dictionary<string, string>();
        bool runHandler = true;

        public MultipleAnalysisForm()
        {
            InitializeComponent();
        }

        private void MultipleAnalysisForm_Load(object sender, EventArgs e)
        {
            SelectDocuments();
            LoadItems();
            LoadDictionaryItems();
            GenerateKeywords(1, rtbBeginner);
            GenerateKeywords(2, rtbPostBeginner);
            GenerateKeywords(3, rtbIntermediate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level">1 - Beginner
        /// 2 - Post Beginner
        /// 3 - Intermediate
        /// 4 - Total
        /// </param>
        /// <param name="rtb"></param>
        private void GenerateKeywords(int level, RichTextBox rtb)
        {
            var b = rtb.Text;
            List<string> kk = new List<string>();

            var regex = new Regex(@"\[.*?\]");
            var matches = regex.Matches(b);

            foreach (var match in matches)
            {
                var a = match.ToString();
                a = a.Substring(1);
                a = a.Remove(a.Length - 1);

                kk.AddRange(a.Split(';'));
            }

            foreach (var match in matches)
            {
                var a = match.ToString();
                a = a.Substring(1);
                a = a.Remove(a.Length - 1);

                var fullLoop = a.Split(';');

                foreach (var item in fullLoop)
                {
                    var value = item.Substring(1);

                    if (!item.StartsWith("c") && !item.StartsWith("w"))
                    {
                        continue;
                    }

                    if (!DictKeyword.ContainsKey(value))
                    {
                        MessageBox.Show(item.ToString() + " couldn't be found!");
                        continue;
                    }

                    // ilk once su andaki item keyword olarak ekli mi kontrol et
                    // yoksa ekle, eklerken tekli olarak da ekle, default degerler 0 olarak
                    if (!Info.ContainsKey(item))
                    {
                        Info.Add(
                           item,
                           new Dictionary<string, Dictionary<int, List<int>>>
                            {
                                {"OWN",
                                    new Dictionary<int, List<int>> 
                                    {
                                        {
                                            1,
                                            new List<int>{0, 0}
                                        },
                                        {
                                            2,
                                            new List<int>{0, 0}
                                        },
                                        {
                                            3,
                                            new List<int>{0, 0}
                                        },
                                        {
                                            4,
                                            new List<int>{0, 0}
                                        }
                                    }  
                                 }   
                            }
                           );
                    }


                    // listede tek item var ise, tekli degeri guncelle ve devam et
                    if (fullLoop.Length == 1)
                    {
                        if (item.ToLower().StartsWith("c"))
                        {
                            Info[item]["OWN"][level][0]++;
                            Info[item]["OWN"][4][0]++;
                        }
                        else
                        {
                            Info[item]["OWN"][level][1]++;
                            Info[item]["OWN"][4][1]++;
                        }

                        continue;
                    }

                    // listede cok item var ise
                    // tekrar loop yap listede
                    foreach (var innerItem in fullLoop)
                    {
                        // kendisi ise devam et
                        if (item == innerItem)
                            continue;

                        // baskasi ise dict te var mi kontrol et, yoksa ekle, varsa sayiyi artir
                        if (!Info[item].ContainsKey(innerItem.Substring(1)))
                        {
                            Info[item].Add
                                        (
                                        innerItem.Substring(1),
                                        new Dictionary<int, List<int>> 
                                            {
                                                {
                                                    1,
                                                    new List<int>{0, 0}
                                                },
                                                {
                                                    2,
                                                    new List<int>{0, 0}
                                                },
                                                {
                                                    3,
                                                    new List<int>{0, 0}
                                                },
                                                {
                                                    4,
                                                    new List<int>{0, 0}
                                                }
                                            }
                                        );
                        }

                        if (innerItem.ToLower().StartsWith("c"))
                        {
                            Info[item][innerItem.Substring(1)][level][0]++;
                            Info[item][innerItem.Substring(1)][4][0]++;
                        }
                        else
                        {
                            Info[item][innerItem.Substring(1)][level][1]++;
                            Info[item][innerItem.Substring(1)][4][1]++;
                        }
                    }
                }
            }
        }

        private void LoadDictionaryItems()
        {
            Helper.LoadItemsFromFile("nouns.xml", "noun", DictKeyword);
            Helper.LoadItemsFromFile("verbs.xml", "verb", DictKeyword);
            Helper.LoadStaticItems(DictKeyword);
        }

        private void SelectDocuments()
        {
            // Load beginner first
            // Create an OpenFileDialog to request a file to open.
            OpenFileDialog openFile1 = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for RTF files.
            openFile1.DefaultExt = "*.rtf";
            openFile1.Filter = "RTF Files|*.rtf";
            openFile1.Title = "Beginner File";

            // Determine whether the user selected a file from the OpenFileDialog. 
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
                rtbBeginner.LoadFile(openFile1.FileName);
                //fileName = this.Text = openFile1.FileName;
                //btnSave.Enabled = btnSaveAs.Enabled = timer1.Enabled = richTextBox1.Enabled = true;
            }
            else
            {
                this.Close();
            }

            openFile1.Title = "Post Beginner File";

            // Determine whether the user selected a file from the OpenFileDialog. 
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
                rtbPostBeginner.LoadFile(openFile1.FileName);
                //fileName = this.Text = openFile1.FileName;
                //btnSave.Enabled = btnSaveAs.Enabled = timer1.Enabled = richTextBox1.Enabled = true;
            }
            else
            {
                this.Close();
            }

            openFile1.Title = "Intermediate File";

            // Determine whether the user selected a file from the OpenFileDialog. 
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
                rtbIntermediate.LoadFile(openFile1.FileName);
                //fileName = this.Text = openFile1.FileName;
                //btnSave.Enabled = btnSaveAs.Enabled = timer1.Enabled = richTextBox1.Enabled = true;
            }
            else
            {
                this.Close();
            }
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

            var query = Info.Where(x => keywords.Contains(x.Key.Substring(1)));

            var _priceDataArray = from outer in query
                                  from row in outer.Value
                                  from inner in row.Value
                                  select new
                                  {
                                      Level = inner.Key.ToString().Replace("1", "Beginner").Replace("2", "Post Beginner").Replace("3", "Intermediate").Replace("4", "Total"),
                                      Order = inner.Key,
                                      // SubKeyword = row.Key != "OWN" ? DictKeyword[row.Key] : "OWN",
                                      SubKeyword = row.Key,
                                      Keyword = outer.Key,
                                      TotalUse = inner.Value[0] + inner.Value[1],
                                      CorrectUse = inner.Value[0],
                                      CorrectUsePerc = GetPercentage(1, inner.Value[0], inner.Value[1]).ToString() + "%",
                                      IncorrectUse = inner.Value[1],
                                      IncorrectUsePerc = GetPercentage(2, inner.Value[0], inner.Value[1]).ToString() + "%"
                                  };

            dataGridView1.AutoGenerateColumns = false;

            BindingSource bs = new BindingSource();
            bs.DataSource = _priceDataArray.OrderBy(x => x.Keyword).ThenBy(x => x.SubKeyword).ThenBy(x => x.Order).ThenByDescending(x => x.IncorrectUse);

            dataGridView1.DataSource = bs;
        }

        decimal GetPercentage(int level, int first, int second)
        {
            if (first == 0 && second == 0)
                return 0m;

            if (level == 1)
            {
                return Math.Round(((decimal)first / (decimal)(first + second)) * 100, 0);
            }
            else
            {
                return 100 - Math.Round(((decimal)first / (decimal)(first + second)) * 100, 0);
            }
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

        private void cleanAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runHandler = false;

            CleanTreeRecursive(tvActions.Nodes);
            CleanTreeRecursive(tvVerbs.Nodes);
            CleanTreeRecursive(tvNouns.Nodes);

            GetSelecteds();

            runHandler = true;
        }

        void CleanTreeRecursive(TreeNodeCollection nodes)
        {
            foreach (TreeNode child in nodes)
            {
                if (child.Nodes.Count == 0 && child.Checked)
                {
                    child.Checked = false;
                }
                else
                {
                    CleanTreeRecursive(child.Nodes);
                }
            }
        }

        void SelectTreeRecursive(TreeNodeCollection nodes)
        {
            foreach (TreeNode child in nodes)
            {
                if (child.Nodes.Count == 0 && !child.Checked)
                {
                    child.Checked = true;
                }
                else
                {
                    SelectTreeRecursive(child.Nodes);
                }
            }
        }

        private void tvVerbs_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!runHandler)
                return;

            GetSelecteds();
        }

        private void tvNouns_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!runHandler)
                return;
            GetSelecteds();
        }

        private void tvAdjectives_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!runHandler)
                return;
            GetSelecteds();
        }

        private void tvActions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!runHandler)
                return;
            GetSelecteds();
        }

        private void checkAllVerbsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runHandler = false;

            SelectTreeRecursive(tvVerbs.Nodes);
            GetSelecteds();

            runHandler = true;
        }

        private void checkAllNounsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runHandler = false;

            SelectTreeRecursive(tvNouns.Nodes);
            GetSelecteds();

            runHandler = true;
        }

        private void checkAllActionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runHandler = false;

            SelectTreeRecursive(tvActions.Nodes);
            GetSelecteds();

            runHandler = true;
        }
    }
}
