using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using TurkishTag;

namespace Alev
{
    public partial class Form1 : Form
    {
        private string fileName { get; set; }
        private bool saveFile = false;
        private bool kelimeSecili = false;
        private bool islem = false;
        private string[] ids;

        #region Analysis variables
        Dictionary<string, List<int>> NounInfo = new Dictionary<string, List<int>>();
        Dictionary<string, List<int>> VerbInfo = new Dictionary<string, List<int>>();
        Dictionary<string, List<int>> OtherInfo = new Dictionary<string, List<int>>();
        List<Dictionary<string, List<int>>> AllDictionaries = new List<Dictionary<string, List<int>>>();

        Dictionary<string, Dictionary<string, List<int>>> combinedList = new Dictionary<string, Dictionary<string, List<int>>>();

        Dictionary<string, string> DictNoun = new Dictionary<string, string>();
        Dictionary<string, string> DictVerb = new Dictionary<string, string>();
        Dictionary<string, string> DictOther = new Dictionary<string, string>();
        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadItems();
        }


        public void LoadMyFile()
        {
            // Create an OpenFileDialog to request a file to open.
            OpenFileDialog openFile1 = new OpenFileDialog();

            // Initialize the OpenFileDialog to look for RTF files.
            openFile1.DefaultExt = "*.rtf";
            openFile1.Filter = "RTF Files|*.rtf";

            // Determine whether the user selected a file from the OpenFileDialog. 
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
                richTextBox1.LoadFile(openFile1.FileName);
                fileName = this.Text = openFile1.FileName;
                btnSave.Enabled = btnSaveAs.Enabled = timer1.Enabled = richTextBox1.Enabled = true;
            }
        }

        public void AutoSaveMyFile()
        {
            try
            {
                richTextBox1.SaveFile(fileName);
            }
            catch (Exception exc)
            {
                MessageBox.Show(string.Format("Dosya kaydetmede hata olustu. Dosya: {0} Hata: {1}", fileName, exc.Message));
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
            LoadStudents();
        }

        void LoadDynamicItems()
        {
            //foreach (var item in Enum.GetValues(typeof(ItemType)).Cast<ItemType>())
            //{
            //    LoadDynamicItem(item);
            //}
            Helper.LoadDynamicItem(tvNouns, ItemType.Nouns);
            Helper.LoadDynamicItem(tvVerbs, ItemType.Verbs);
            //Helper.LoadDynamicItem(tvAdjectives, ItemType.Adjectives);
            //Helper.LoadDynamicItem(tvAdverbs, ItemType.Adverbs);
            //Helper.LoadDynamicItem(tvParticles, ItemType.Particles);
            //Helper.LoadDynamicItem(tvConjunctions, ItemType.Conjunctions);
            //Helper.LoadDynamicItem(tvInterjections, ItemType.Interjections);
        }


        private void LoadStudents()
        {
            tvStudents.Nodes.Clear();

            tvStudents.Nodes.Add("sstu1", "Student 1");
            tvStudents.Nodes.Add("sstu2", "Student 2");
            tvStudents.Nodes.Add("sstu3", "Student 3");
            tvStudents.Nodes.Add("sstu4", "Student 4");
            tvStudents.Nodes.Add("sstu5", "Student 5");
            tvStudents.Nodes.Add("sstu6", "Student 6");
            tvStudents.Nodes.Add("sstu7", "Student 7");
            tvStudents.Nodes.Add("sstu8", "Student 8");
        }


        private void KelimeGuncelle(string secenekler)
        {
            int start = richTextBox1.SelectionStart;

            if (!islem)
            {
                if (string.IsNullOrEmpty(secenekler))
                {
                    return;
                }

                int bosluk = richTextBox1.Text.IndexOf(' ', start);
                int yeniSatir = richTextBox1.Text.IndexOf('\n', start);

                if (bosluk == -1 && yeniSatir == -1) // son
                {
                    InsertText(secenekler, richTextBox1.TextLength);
                }
                else if (bosluk > -1 && yeniSatir == -1)// sayfa sonunda bosluk var
                {
                    InsertText(secenekler, bosluk);
                }
                else if (bosluk == -1 && yeniSatir > -1)// satir sonu
                {
                    InsertText(secenekler, yeniSatir);
                }
                else // satir icin bosluklu
                {
                    if (bosluk < yeniSatir)
                    {
                        InsertText(secenekler, bosluk);
                    }
                    else
                    {
                        InsertText(secenekler, yeniSatir);
                    }
                }
            }
            else // islem var once varolani sil
            {
                int baslangic = richTextBox1.Text.IndexOf('[', start);
                int bitis = richTextBox1.Text.IndexOf(']', start);

                richTextBox1.SelectionStart = baslangic;
                richTextBox1.SelectionLength = bitis - baslangic + 1;
                richTextBox1.SelectedText = "";

                richTextBox1.SelectionStart = start;
                SelectText();

                if (secenekler.Length > 0)
                {
                    KelimeGuncelle(secenekler);
                }
            }

            richTextBox1.SelectionStart = start;
            SelectText();
        }

        private void InsertText(string secenekler, int start)
        {
            richTextBox1.Select(start, 0);
            Clipboard.SetText(secenekler);
            richTextBox1.Paste();

            richTextBox1.SelectionStart = start;
            richTextBox1.SelectionLength = secenekler.Length;
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.SelectionFont = new Font("Verdana", 1, FontStyle.Bold);
        }

        private string GetSelecteds()
        {
            StringBuilder sb = new StringBuilder("[");
            StringBuilder sb2 = new StringBuilder();
            StringBuilder sb3 = new StringBuilder();

            GetSelectedsRecursive(tvActions.Nodes, sb, sb2, sb3);
            GetSelectedsRecursive(tvVerbs.Nodes, sb, sb2, sb3);
            GetSelectedsRecursive(tvNouns.Nodes, sb, sb2, sb3);
            //GetSelectedsRecursive(tvAdverbs.Nodes, sb, sb2, sb3);
            //GetSelectedsRecursive(tvAdjectives.Nodes, sb, sb2, sb3);
            //GetSelectedsRecursive(tvConjunctions.Nodes, sb, sb2, sb3);
            //GetSelectedsRecursive(tvParticles.Nodes, sb, sb2, sb3);
            //GetSelectedsRecursive(tvInterjections.Nodes, sb, sb2, sb3);
            GetSelectedsRecursive(tvStudents.Nodes, sb, sb2, sb3);

            sb.Length--;

            KelimeListesiTemizle();

            if (sb.Length == 0)
            {
                return "";
            }

            sb.Append("]");

            txtPreview.Text = sb2.ToString();

            sb3.Length--;
            KelimeListesiGuncelle(sb3.ToString());

            return sb.ToString();
        }

        private bool KelimeListedemi(string kelime, ref bool targetUse)
        {
            if (txt1.Text.ToLower() == kelime.ToLower())
            {
                if (rb1T.Checked)
                    targetUse = true;
                else
                    targetUse = false;

                return true;
            }

            if (txt2.Text.ToLower() == kelime.ToLower())
            {
                if (rb2T.Checked)
                    targetUse = true;
                else
                    targetUse = false;

                return true;
            }

            if (txt3.Text.ToLower() == kelime.ToLower())
            {
                if (rb3T.Checked)
                    targetUse = true;
                else
                    targetUse = false;

                return true;
            }

            if (txt4.Text.ToLower() == kelime.ToLower())
            {
                if (rb4T.Checked)
                    targetUse = true;
                else
                    targetUse = false;

                return true;
            }

            if (txt5.Text.ToLower() == kelime.ToLower())
            {
                if (rb5T.Checked)
                    targetUse = true;
                else
                    targetUse = false;

                return true;
            }

            if (txt6.Text.ToLower() == kelime.ToLower())
            {
                if (rb6T.Checked)
                    targetUse = true;
                else
                    targetUse = false;

                return true;
            }

            if (txt7.Text.ToLower() == kelime.ToLower())
            {
                if (rb7T.Checked)
                    targetUse = true;
                else
                    targetUse = false;

                return true;
            }

            return false;
        }

        void GetSelectedsRecursive(TreeNodeCollection nodes, StringBuilder sb, StringBuilder sb2, StringBuilder sb3)
        {
            foreach (TreeNode child in nodes)
            {
                bool targetUse = rbTarget.Checked;
                var prefix = targetUse ? "c" : "w";

                if (child.Nodes.Count == 0 && child.Checked)
                {
                    if (KelimeListedemi(child.Text, ref targetUse))
                    {
                        prefix = targetUse ? "c" : "w";
                    }

                    sb.Append(prefix + child.Name + ";");
                    sb2.Append(string.Format("[{0}] {1}{2}", prefix == "c" ? "correct" : "wrong", child.Text, Environment.NewLine));
                    sb3.Append(prefix + child.Text + ";");
                }
                else
                {
                    GetSelectedsRecursive(child.Nodes, sb, sb2, sb3);
                }
            }
        }

        private void KelimeListesiGuncelle(string kelimeler)
        {
            var kelime = kelimeler.Split(';');

            if (kelime.Length > 7)
            {
                MessageBox.Show("Daha fazla secenek girilmelidir. Lutfen sistem yoneticisine basvurunuz!");
            }

            for (int i = 1; i <= kelime.Length; i++)
            {
                (this.Controls.Find("txt" + i.ToString(), true)[0] as TextBox).Text = kelime[i - 1].Substring(1);
                var rbt = (this.Controls.Find("rb" + i.ToString() + "T", true)[0] as RadioButton);
                var rbn = (this.Controls.Find("rb" + i.ToString() + "N", true)[0] as RadioButton);

                rbt.Enabled = true;
                rbn.Enabled = true;

                if (kelime[i - 1].StartsWith("c"))
                {
                    rbt.Checked = true;
                }
                else
                {
                    rbn.Checked = true;
                }
            }

            for (int i = kelime.Length + 1; i <= 7; i++)
            {
                (this.Controls.Find("rb" + i.ToString() + "T", true)[0] as RadioButton).Enabled = false;
                (this.Controls.Find("rb" + i.ToString() + "N", true)[0] as RadioButton).Enabled = false;
            }

        }

        private void TreeTemizle()
        {
            ClearAfterChecks();

            TreeTemizleRecursive(tvActions.Nodes);
            TreeTemizleRecursive(tvVerbs.Nodes);
            TreeTemizleRecursive(tvNouns.Nodes);
            //TreeTemizleRecursive(tvAdverbs.Nodes);
            //TreeTemizleRecursive(tvAdjectives.Nodes);
            //TreeTemizleRecursive(tvConjunctions.Nodes);
            //TreeTemizleRecursive(tvParticles.Nodes);
            //TreeTemizleRecursive(tvInterjections.Nodes);
            TreeTemizleRecursive(tvStudents.Nodes);
            //rbTarget.Checked = false;
            //rbNonTarget.Checked = false;

            AddAfterChecks();
        }

        void TreeTemizleRecursive(TreeNodeCollection nodes)
        {
            foreach (TreeNode child in nodes)
            {
                if (child.Nodes.Count == 0)
                {
                    child.Checked = false;
                }
                else
                {
                    TreeTemizleRecursive(child.Nodes);
                }
            }
        }

        private void AddAfterChecks()
        {
            this.tvActions.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvActions_AfterCheck);
            this.tvVerbs.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvVerbs_AfterCheck);
            this.tvNouns.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvNouns_AfterCheck);
            //this.tvAdverbs.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvAdverbs_AfterCheck);
            //this.tvAdjectives.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvAdjectives_AfterCheck);
            //this.tvConjunctions.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvConjunctions_AfterCheck);
            //this.tvParticles.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvParticles_AfterCheck);
            //this.tvInterjections.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvInterjections_AfterCheck);
            this.tvStudents.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvStudents_AfterCheck);
            //this.rbTarget.CheckedChanged += rbTarget_CheckedChanged;
            //this.rbNonTarget.CheckedChanged += this.rbNonTarget_CheckedChanged;
        }

        private void ClearAfterChecks()
        {
            this.tvActions.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvActions_AfterCheck);
            this.tvVerbs.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvVerbs_AfterCheck);
            this.tvNouns.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvNouns_AfterCheck);
            //this.tvAdverbs.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvAdverbs_AfterCheck);
            //this.tvAdjectives.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvAdjectives_AfterCheck);
            //this.tvConjunctions.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvConjunctions_AfterCheck);
            //this.tvParticles.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvParticles_AfterCheck);
            //this.tvInterjections.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvInterjections_AfterCheck);
            this.tvStudents.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvStudents_AfterCheck);
            //this.rbTarget.CheckedChanged -= rbTarget_CheckedChanged;
            //this.rbNonTarget.CheckedChanged -= this.rbNonTarget_CheckedChanged;
        }

        private void TreeSec()
        {
            ClearAfterChecks();
            ClearCheckedChangedEvents();

            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            //rbTarget.Checked = ids[0].StartsWith("c", StringComparison.CurrentCultureIgnoreCase);
            //rbNonTarget.Checked = ids[0].StartsWith("w", StringComparison.CurrentCultureIgnoreCase);

            TreeSecRecursive(tvActions.Nodes, sb, sb2);
            TreeSecRecursive(tvNouns.Nodes, sb, sb2);
            TreeSecRecursive(tvVerbs.Nodes, sb, sb2);
            //TreeSecRecursive(tvAdverbs.Nodes, sb, sb2);
            //TreeSecRecursive(tvAdjectives.Nodes, sb, sb2);
            //TreeSecRecursive(tvConjunctions.Nodes, sb, sb2);
            //TreeSecRecursive(tvParticles.Nodes, sb, sb2);
            //TreeSecRecursive(tvInterjections.Nodes, sb, sb2);
            TreeSecRecursive(tvStudents.Nodes, sb, sb2);

            txtPreview.Text = sb.ToString();

            if (sb2.Length > 0)
            {
                sb2.Length--;
                KelimeListesiGuncelle(sb2.ToString());
            }

            AddAfterChecks();
            AddCheckedChangedEvents();
        }

        void TreeSecRecursive(TreeNodeCollection nodes, StringBuilder sb, StringBuilder sb2)
        {
            var prefix = rbTarget.Checked ? "c" : "w";
            var target = rbTarget.Checked;

            foreach (TreeNode child in nodes)
            {
                if (child.Nodes.Count == 0 && ids.Any(x => x.Substring(1) == child.Name))
                {
                    child.Checked = true;
                    var obj = ids.First(x => x.Substring(1) == child.Name);
                    sb.Append(string.Format("[{0}] {1}{2}", obj.StartsWith("c") ? "correct" : "wrong", child.Text, Environment.NewLine));
                    sb2.Append(string.Format("{0}{1};", obj.StartsWith("c") ? "c" : "w", child.Text));
                }
                else
                {
                    TreeSecRecursive(child.Nodes, sb, sb2);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Minute % 5 == 0 && saveFile)
            {
                saveFile = false;
                AutoSaveMyFile();
            }
            else if (DateTime.Now.Minute % 5 != 0)
            {
                saveFile = true;
            }
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            TreeTemizle();
            SelectText();
            txtPreview.Text = "";

            ClearCheckedChangedEvents();
            KelimeListesiTemizle();
            AddCheckedChangedEvents();

            if (islem)
            {
                SetSelecteds();
            }
        }


        private void SelectText()
        {
            islem = false;

            if (!KelimeTiklandimi())
            {
                richTextBox1.SelectionLength = 0;
                return;
            }

            int start = richTextBox1.SelectionStart;

            if (start == richTextBox1.TextLength)
            {
                start--;
            }

            #region Baslangic noktasini belirle
            int index = richTextBox1.Text.LastIndexOfAny(new char[] { ' ', '\n' }, start);

            if (index > -1 && index != start)
            {
                start = index + 1;
            }
            else if (index == start)// bir onceki kelime secilecek
            {
                index = richTextBox1.Text.LastIndexOfAny(new char[] { ' ', '\n' }, start - 1);
                start = index + 1;
            }
            else
            {
                start = 0;
            }
            #endregion


            index = richTextBox1.Text.IndexOfAny(new char[] { ' ', '[', '\n' }, start);
            int selectionLen = 0;

            if (index > -1)
            {
                selectionLen = index - start;
            }
            else
            {
                selectionLen = richTextBox1.TextLength - start;
            }


            if (index > -1 && index == richTextBox1.Text.IndexOf('[', start))
            {
                islem = true;
            }

            richTextBox1.SelectionStart = start;
            richTextBox1.SelectionLength = selectionLen;

            if (islem)
            {
                richTextBox1.SelectionFont = new Font("Calibri", 12, FontStyle.Bold);
            }
            else
            {
                richTextBox1.SelectionFont = new Font("Calibri", 12, FontStyle.Regular);
            }
        }

        private void SetSelecteds()
        {
            if (!islem)
            {
                return;
            }

            int start = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
            int end = richTextBox1.Text.IndexOf(']', richTextBox1.SelectionStart);

            string islemler = richTextBox1.Text.Substring(start, end - start);

            ids = islemler.Substring(1).Split(';');

            TreeSec();
        }

        private bool KelimeTiklandimi()
        {
            int length = richTextBox1.TextLength;
            kelimeSecili = false;

            if (length == 0)
            {
                return false;
            }

            int pos = richTextBox1.SelectionStart;

            if (pos == 0) // baslangic
            {
                if (!string.IsNullOrEmpty(richTextBox1.Text.Substring(pos, 1).Trim()))
                {
                    kelimeSecili = true;
                }
            }
            else if (pos == length) // son
            {
                if (!string.IsNullOrEmpty(richTextBox1.Text.Substring(pos - 1, 1).Trim()))
                {
                    kelimeSecili = true;
                }
            }
            else // ortalar tiklandi
            {
                if (!string.IsNullOrEmpty(richTextBox1.Text.Substring(pos - 1, 1).Trim())) // solda var mi
                {
                    kelimeSecili = true;
                }
                else if (!string.IsNullOrEmpty(richTextBox1.Text.Substring(pos, 1).Trim())) // sagda var mi
                {
                    kelimeSecili = true;
                }
            }

            return kelimeSecili;
        }

        private void btnOpen_Click_1(object sender, EventArgs e)
        {
            LoadMyFile();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            AutoSaveMyFile();
        }

        private void btnSaveAs_Click_1(object sender, EventArgs e)
        {
            fileName = this.Text = Helper.SaveMyFile(richTextBox1);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddDynamicItemForm adif = new AddDynamicItemForm(ItemType.Verbs);

            adif.ShowDialog(this);
            adif.Dispose();
            Helper.LoadDynamicItem(tvVerbs, ItemType.Verbs);
        }

        private void btnGenerateXml_Click(object sender, EventArgs e)
        {
            SaveXmlform sxf = new SaveXmlform();

            sxf.Rtb = richTextBox1;

            sxf.ShowDialog(this);
            sxf.Dispose();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AddDynamicItemForm adif = new AddDynamicItemForm(ItemType.Nouns);

            adif.ShowDialog(this);
            adif.Dispose();
            Helper.LoadDynamicItem(tvNouns, ItemType.Nouns);
        }

        #region AfterCheck events for treeview controls
        private void tvActions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            AfterTreeViewClick();
        }

        private void tvVerbs_AfterCheck(object sender, TreeViewEventArgs e)
        {
            AfterTreeViewClick();
        }

        private void tvNouns_AfterCheck(object sender, TreeViewEventArgs e)
        {
            AfterTreeViewClick();
        }

        private void tvStudents_AfterCheck(object sender, TreeViewEventArgs e)
        {
            AfterTreeViewClick();
        }
        #endregion

        private void AfterTreeViewClick()
        {
            txtPreview.Text = "";

            if (!KelimeTiklandimi())
            {
                return;
            }

            if (!rbTarget.Checked && !rbNonTarget.Checked)
            {
                MessageBox.Show("Please select target/non target use option first!");
                return;
            }


            ClearCheckedChangedEvents();
            KelimeGuncelle(GetSelecteds());
            AddCheckedChangedEvents();
        }


        private void AddCheckedChangedEvents()
        {
            this.rb1T.CheckedChanged += new System.EventHandler(this.rb1T_CheckedChanged);
            this.rb2T.CheckedChanged += new System.EventHandler(this.rb2T_CheckedChanged);
            this.rb3T.CheckedChanged += new System.EventHandler(this.rb3T_CheckedChanged);
            this.rb4T.CheckedChanged += new System.EventHandler(this.rb4T_CheckedChanged);
            this.rb5T.CheckedChanged += new System.EventHandler(this.rb5T_CheckedChanged);
            this.rb6T.CheckedChanged += new System.EventHandler(this.rb6T_CheckedChanged);
            this.rb7T.CheckedChanged += new System.EventHandler(this.rb7T_CheckedChanged);
        }

        private void ClearCheckedChangedEvents()
        {
            this.rb1T.CheckedChanged -= new System.EventHandler(this.rb1T_CheckedChanged);
            this.rb2T.CheckedChanged -= new System.EventHandler(this.rb2T_CheckedChanged);
            this.rb3T.CheckedChanged -= new System.EventHandler(this.rb3T_CheckedChanged);
            this.rb4T.CheckedChanged -= new System.EventHandler(this.rb4T_CheckedChanged);
            this.rb5T.CheckedChanged -= new System.EventHandler(this.rb5T_CheckedChanged);
            this.rb6T.CheckedChanged -= new System.EventHandler(this.rb6T_CheckedChanged);
            this.rb7T.CheckedChanged -= new System.EventHandler(this.rb7T_CheckedChanged);
        }


        private void KelimeListesiTemizle()
        {
            rb1T.Checked = false;
            rb2T.Checked = false;
            rb3T.Checked = false;
            rb4T.Checked = false;
            rb5T.Checked = false;
            rb6T.Checked = false;
            rb7T.Checked = false;

            rb1T.Enabled = false;
            rb2T.Enabled = false;
            rb3T.Enabled = false;
            rb4T.Enabled = false;
            rb5T.Enabled = false;
            rb6T.Enabled = false;
            rb7T.Enabled = false;

            rb1N.Checked = false;
            rb2N.Checked = false;
            rb3N.Checked = false;
            rb4N.Checked = false;
            rb5N.Checked = false;
            rb6N.Checked = false;
            rb7N.Checked = false;

            rb1N.Enabled = false;
            rb2N.Enabled = false;
            rb3N.Enabled = false;
            rb4N.Enabled = false;
            rb5N.Enabled = false;
            rb6N.Enabled = false;
            rb7N.Enabled = false;

            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
        }

        private void rbNonTarget_CheckedChanged(object sender, EventArgs e)
        {
            AfterTreeViewClick();
        }

        private void rbTarget_CheckedChanged(object sender, EventArgs e)
        {
            AfterTreeViewClick();
        }

        private void tvVerbs_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            CollapseNotSelectedItems(tvVerbs, e);
        }

        private void CollapseNotSelectedItems(TreeView treeView, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count == 0)
            {
                return;
            }
            else
            {
                foreach (TreeNode item in treeView.Nodes)
                {
                    if (item != e.Node)
                    {
                        item.Collapse();
                    }
                }
            }
        }

        private void tvNouns_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            CollapseNotSelectedItems(tvNouns, e);
        }

        private void mostUsedNounsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateKeywords();

            MostUsedNounsForm munf = new MostUsedNounsForm();
            munf.NounInfo = NounInfo;

            munf.ShowDialog(this);
            munf.Dispose();
        }


        private void GenerateKeywords()
        {
            DateTime start, end;

            Helper.LoadItemsFromFile("nouns.xml", "noun", DictNoun);
            Helper.LoadItemsFromFile("verbs.xml", "verb", DictVerb);
            Helper.LoadStaticItems(DictOther);

            NounInfo.Clear();
            VerbInfo.Clear();
            OtherInfo.Clear();

            combinedList.Clear();

            start = DateTime.Now;
            var b = richTextBox1.Text;
            List<string> kk = new List<string>();

            //end = DateTime.Now;
            //txtPreview.Text = string.Format("s: {0} {2} f: {1} {3}", start, end, Environment.NewLine, kk[5]);

            var regex = new Regex(@"\[.*?\]");
            var matches = regex.Matches(b);

            foreach (var match in matches)
            {
                var a = match.ToString();
                a = a.Remove(0, 1);
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
                    if (item.ToLower().StartsWith("s"))
                        continue;

                    // ilk once su andaki item keyword olarak ekli mi kontrol et
                    // yoksa ekle, eklerken tekli olarak da ekle, default degerler 0 olarak
                    if (!combinedList.ContainsKey(item))
                    {
                        combinedList.Add(
                                            item,
                                            new Dictionary<string, List<int>> 
                                            {{
                                                "OWN",
                                                new List<int>{0, 0}
                                            }}
                                        );
                    }


                    // listede tek item var ise, tekli degeri guncelle ve devam et
                    if (fullLoop.Length == 1)
                    {
                        if (item.ToLower().StartsWith("c"))
                            combinedList[item]["OWN"][0]++;
                        else
                            combinedList[item]["OWN"][1]++;

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
                        if (!combinedList[item].ContainsKey(innerItem.Substring(1)))
                        {
                            combinedList[item].Add
                                                    (
                                                        innerItem.Substring(1),
                                                        new List<int> { 0, 0 }
                                                    );
                        }

                        if (innerItem.ToLower().StartsWith("c"))
                            combinedList[item][innerItem.Substring(1)][0]++;
                        else
                            combinedList[item][innerItem.Substring(1)][1]++;
                    }
                }
            }

            var p = kk.GroupBy(x => x).Select(x => new
                {
                    Ad = x.Key,
                    Sayi = x.Count()
                });

            foreach (var item in p)
            {
                if (item.Ad.StartsWith("c"))
                {
                    var value = item.Ad.Remove(0, 1);

                    if (DictNoun.ContainsKey(value))
                    {
                        if (!NounInfo.ContainsKey(value))
                        {
                            NounInfo.Add(value, new List<int> { item.Sayi, 0 });
                        }
                        else
                        {
                            NounInfo[value][0] = item.Sayi;
                        }
                    }
                    else if (DictVerb.ContainsKey(value))
                    {
                        if (!VerbInfo.ContainsKey(value))
                        {
                            VerbInfo.Add(value, new List<int> { item.Sayi, 0 });
                        }
                        else
                        {
                            VerbInfo[value][0] = item.Sayi;
                        }
                    }
                    else
                    {
                        if (!OtherInfo.ContainsKey(value))
                        {
                            OtherInfo.Add(value, new List<int> { item.Sayi, 0 });
                        }
                        else
                        {
                            OtherInfo[value][0] = item.Sayi;
                        }
                    }
                }
                else if (item.Ad.StartsWith("w"))
                {
                    var value = item.Ad.Remove(0, 1);

                    if (DictNoun.ContainsKey(value))
                    {
                        if (!NounInfo.ContainsKey(value))
                        {
                            NounInfo.Add(value, new List<int> { 0, item.Sayi });
                        }
                        else
                        {
                            NounInfo[value][1] = item.Sayi;
                        }
                    }
                    else if (DictVerb.ContainsKey(value))
                    {
                        if (!VerbInfo.ContainsKey(value))
                        {
                            VerbInfo.Add(value, new List<int> { 0, item.Sayi });
                        }
                        else
                        {
                            VerbInfo[value][1] = item.Sayi;
                        }
                    }
                    else if (DictOther.ContainsKey(value))
                    {
                        if (!OtherInfo.ContainsKey(value))
                        {
                            OtherInfo.Add(value, new List<int> { 0, item.Sayi });
                        }
                        else
                        {
                            OtherInfo[value][1] = item.Sayi;
                        }
                    }
                    else
                    {
                        // TODO: olmayanlari simdilik ignore et, sonra temizle
                        throw new Exception(item.ToString() + " bulunamadi!");
                    }
                }
                else // s => students
                {

                }
            }

            AllDictionaries.Clear();

            AllDictionaries.Add(NounInfo);
            AllDictionaries.Add(VerbInfo);
            AllDictionaries.Add(OtherInfo);
        }

        #region Analysis items
        void LoadNounsFromFile()
        {
            DictNoun.Clear();
            XmlDocument doc2 = new XmlDocument();
            doc2.Load("nouns.xml");
            XmlNodeList node = doc2.GetElementsByTagName("noun");

            foreach (XmlNode xn in node)
            {
                DictNoun.Add(xn.FirstChild.InnerText, xn.LastChild.InnerText);
            }
        }

        void LoadVerbsFromFile()
        {
            DictVerb.Clear();
            XmlDocument doc2 = new XmlDocument();
            doc2.Load("verbs.xml");
            XmlNodeList node = doc2.GetElementsByTagName("verb");

            foreach (XmlNode xn in node)
            {
                DictVerb.Add(xn.FirstChild.InnerText, xn.LastChild.InnerText);
            }
        }

        //void LoadAdjectivesFromFile()
        //{
        //    DictAdjective.Clear();
        //    XmlDocument doc2 = new XmlDocument();
        //    doc2.Load("adjectives.xml");
        //    XmlNodeList node = doc2.GetElementsByTagName("adjective");

        //    foreach (XmlNode xn in node)
        //    {
        //        DictAdjective.Add(xn.FirstChild.InnerText, xn.LastChild.InnerText);
        //    }
        //}

        void LoadOthers()
        {
            DictOther.Clear();

            DictOther.Add("p1s", "p1s");
            DictOther.Add("p2s", "p2s");
            DictOther.Add("p3s", "p3s");
            DictOther.Add("p1p", "p1p");
            DictOther.Add("p2p", "p2p");
            DictOther.Add("p3p", "p3p");

            DictOther.Add("pss1s", "pss1s");
            DictOther.Add("pss2s", "pss2s");
            DictOther.Add("pss3s", "pss3s");
            DictOther.Add("pss1p", "pss1p");
            DictOther.Add("pss2p", "pss2p");
            DictOther.Add("pss3p", "pss3p");

            DictOther.Add("Exist", "Existential");
            DictOther.Add("ExistNeg", "Existential Neg");
            DictOther.Add("Hvow", "Vowel harmony");
            DictOther.Add("Hcons", "Consonant harmony");

            DictOther.Add("dat", "dative");
            DictOther.Add("loc", "locative");
            DictOther.Add("abl", "ablative");
            //DictOther.Add("ins", "instrumental");
            //DictOther.Add("gen", "genetive");
            DictOther.Add("acc", "accusative");
            DictOther.Add("nom", "nominative");

            DictOther.Add("buff", "Buffer letter");

            DictOther.Add("Q", "Question particle");

            DictOther.Add("NegmA", "Neg mA");
            DictOther.Add("Değil", "Değil");

            DictOther.Add("prep", "Preposition");

            DictOther.Add("Tprog", "Present progressive tense suffix");
            DictOther.Add("Tpres", "Simple present tense");
            DictOther.Add("Tpast", "Past tense suffix (DI)");
            DictOther.Add("TInEvPast", "Indirect evidence past tense");
            DictOther.Add("PastCon", "Past continous");
            DictOther.Add("futur", "Future tense");

            DictOther.Add("plr", "Plural");
            DictOther.Add("partip", "Participles");
            DictOther.Add("Adv", "Adverb");
            DictOther.Add("Adj", "Adjective");
            //DictOther.Add("postPos", "Post position");// sil
            DictOther.Add("part", "Particles");
            DictOther.Add("Conj", "Conjunction");
            DictOther.Add("Intj", "Interjection");
            DictOther.Add("Abil", "Ability");
            DictOther.Add("iuon", "Incorrect use of noun");
            DictOther.Add("softCons", "Softening of consonants");
            DictOther.Add("pron", "Prononciation");
            DictOther.Add("RepSp", "Reported speech");
            DictOther.Add("necc", "Necessity");
            DictOther.Add("wOrder", "Word order");
            DictOther.Add("con", "If conditional");
            DictOther.Add("req", "Request");
            DictOther.Add("impr", "Imperative");
            DictOther.Add("compNoun", "Compound noun");
        }

        private void personalPronounsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateKeywords();

            List<string> pp = new List<string>();

            pp.Add("p1s");
            pp.Add("p2s");
            pp.Add("p3s");
            pp.Add("p1p");
            pp.Add("p2p");
            pp.Add("p3p");


            var aaa = OtherInfo.Where(p => pp.Contains(p.Key))
                        .ToDictionary(p => p.Key, p => p.Value);

            MostUsedNounsForm munf = new MostUsedNounsForm();
            munf.NounInfo = aaa;

            munf.ShowDialog(this);
            munf.Dispose();
        }
        #endregion

        int findPos = 0;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData != Keys.F3)
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            if (txtFind.Text.Trim().Length == 0)
            {
                return true;
            }

            if (findPos == -1)
            {
                findPos = richTextBox1.TextLength - 1;
            }

            findPos = richTextBox1.Text.IndexOf(txtFind.Text, findPos, StringComparison.CurrentCultureIgnoreCase);

            if (findPos == -1)
            {
                MessageBox.Show("No more " + txtFind.Text);
                return true;
            }

            richTextBox1.SelectionStart = findPos;
            richTextBox1.ScrollToCaret();
            //SelectText();

            richTextBox1_Click(new object(), new EventArgs());

            findPos += richTextBox1.SelectionLength;

            return true;
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            findPos = 0;
        }

        private void adverbsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateKeywords();

            List<string> adverbs = new List<string>();

            adverbs.Add("Adv");

            var aaa = OtherInfo.Where(p => adverbs.Contains(p.Key))
                        .ToDictionary(p => p.Key, p => p.Value);

            MostUsedNounsForm munf = new MostUsedNounsForm();
            munf.NounInfo = aaa;

            munf.ShowDialog(this);
            munf.Dispose();
        }

        private void participlesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            GenerateKeywords();

            List<string> adverbs = new List<string>();

            adverbs.Add("partip");

            var aaa = OtherInfo.Where(p => adverbs.Contains(p.Key))
                        .ToDictionary(p => p.Key, p => p.Value);

            MostUsedNounsForm munf = new MostUsedNounsForm();
            munf.NounInfo = aaa;

            munf.ShowDialog(this);
            munf.Dispose();
        }

        private void adjectivesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateKeywords();

            List<string> adverbs = new List<string>();

            adverbs.Add("Adj");

            var aaa = OtherInfo.Where(p => adverbs.Contains(p.Key))
                        .ToDictionary(p => p.Key, p => p.Value);

            MostUsedNounsForm munf = new MostUsedNounsForm();
            munf.NounInfo = aaa;

            munf.ShowDialog(this);
            munf.Dispose();
        }

        private void postPositionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateKeywords();

            List<string> adverbs = new List<string>();

            adverbs.Add("postPos");

            var aaa = OtherInfo.Where(p => adverbs.Contains(p.Key))
                        .ToDictionary(p => p.Key, p => p.Value);

            MostUsedNounsForm munf = new MostUsedNounsForm();
            munf.NounInfo = aaa;

            munf.ShowDialog(this);
            munf.Dispose();

        }

        private void particlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateKeywords();

            List<string> adverbs = new List<string>();

            adverbs.Add("part");

            var aaa = OtherInfo.Where(p => adverbs.Contains(p.Key))
                        .ToDictionary(p => p.Key, p => p.Value);

            MostUsedNounsForm munf = new MostUsedNounsForm();
            munf.NounInfo = aaa;

            munf.ShowDialog(this);
            munf.Dispose();
        }

        private void conjunctionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateKeywords();

            List<string> adverbs = new List<string>();

            adverbs.Add("Conj");

            var aaa = OtherInfo.Where(p => adverbs.Contains(p.Key))
                        .ToDictionary(p => p.Key, p => p.Value);

            MostUsedNounsForm munf = new MostUsedNounsForm();
            munf.NounInfo = aaa;

            munf.ShowDialog(this);
            munf.Dispose();
        }

        private void interjectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateKeywords();

            List<string> adverbs = new List<string>();

            adverbs.Add("Intj");

            var aaa = OtherInfo.Where(p => adverbs.Contains(p.Key))
                        .ToDictionary(p => p.Key, p => p.Value);

            MostUsedNounsForm munf = new MostUsedNounsForm();
            munf.NounInfo = aaa;

            munf.ShowDialog(this);
            munf.Dispose();
        }



        #region AfterCheck
        private void tvAdverbs_AfterCheck(object sender, TreeViewEventArgs e)
        {
            AfterTreeViewClick();
        }

        private void tvAdjectives_AfterCheck(object sender, TreeViewEventArgs e)
        {
            AfterTreeViewClick();
        }

        private void tvConjunctions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            AfterTreeViewClick();
        }

        private void tvInterjections_AfterCheck(object sender, TreeViewEventArgs e)
        {
            AfterTreeViewClick();
        }

        private void tvParticles_AfterCheck(object sender, TreeViewEventArgs e)
        {
            AfterTreeViewClick();
        }
        #endregion

        #region NodeMouseClick
        //private void tvAdjectives_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    CollapseNotSelectedItems(tvAdjectives, e);
        //}

        //private void tvAdverbs_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    CollapseNotSelectedItems(tvAdverbs, e);
        //}

        //private void tvConjunctions_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    CollapseNotSelectedItems(tvConjunctions, e);
        //}

        //private void tvInterjections_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    CollapseNotSelectedItems(tvInterjections, e);
        //}

        //private void tvParticles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    CollapseNotSelectedItems(tvParticles, e);
        //}
        #endregion

        private void rb1T_CheckedChanged(object sender, EventArgs e)
        {
            AfterTreeViewClick();
        }

        private void rb2T_CheckedChanged(object sender, EventArgs e)
        {
            AfterTreeViewClick();
        }

        private void rb3T_CheckedChanged(object sender, EventArgs e)
        {
            AfterTreeViewClick();
        }

        private void rb4T_CheckedChanged(object sender, EventArgs e)
        {
            AfterTreeViewClick();
        }

        private void rb5T_CheckedChanged(object sender, EventArgs e)
        {
            AfterTreeViewClick();
        }

        private void rb6T_CheckedChanged(object sender, EventArgs e)
        {
            AfterTreeViewClick();
        }

        private void rb7T_CheckedChanged(object sender, EventArgs e)
        {
            AfterTreeViewClick();
        }

        private void dynamicAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerateKeywords();

            DynamicAnalysis da = new DynamicAnalysis();

            da.Info = AllDictionaries.SelectMany(dict => dict)
                         .ToDictionary(pair => pair.Key, pair => pair.Value);

            da.ShowDialog(this);
            da.Dispose();
        }

        private void multipleAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultipleAnalysisForm maf = new MultipleAnalysisForm();

            maf.ShowDialog(this);
            maf.Dispose();
        }

        private void multipleDocumentAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultipleDocumentAnalysisForm mdaf = new MultipleDocumentAnalysisForm();

            //mdaf.Info = combinedList;

            mdaf.ShowDialog(this);
            mdaf.Dispose();
        }

        private void multipleAnalysisCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultipleAnalysisWithoutCW maf = new MultipleAnalysisWithoutCW();

            maf.ShowDialog(this);
            maf.Dispose();
        }


        //private void toolStripButton3_Click(object sender, EventArgs e)
        //{
        //    AddDynamicItemForm adif = new AddDynamicItemForm(ItemType.Adjectives);

        //    adif.ShowDialog(this);
        //    adif.Dispose();
        //    LoadDynamicItem(ItemType.Adjectives);
        //}

        //private void tvAdjectives_AfterCheck(object sender, TreeViewEventArgs e)
        //{
        //    AfterTreeViewClick();
        //}

        //private void tvAdjectives_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    CollapseNotSelectedItems(tvAdjectives, e);
        //}

        //private void tvAdverbs_AfterCheck(object sender, TreeViewEventArgs e)
        //{
        //    AfterTreeViewClick();
        //}

        //private void tvAdverbs_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    CollapseNotSelectedItems(tvAdverbs, e);
        //}

        //private void toolStripButton4_Click(object sender, EventArgs e)
        //{
        //    AddDynamicItemForm adif = new AddDynamicItemForm(ItemType.Adverbs);

        //    adif.ShowDialog(this);
        //    adif.Dispose();
        //    LoadDynamicItem(ItemType.Adverbs);
        //}

        //private void toolStripButton5_Click(object sender, EventArgs e)
        //{
        //    AddDynamicItemForm adif = new AddDynamicItemForm(ItemType.Conjunctions);

        //    adif.ShowDialog(this);
        //    adif.Dispose();
        //    LoadDynamicItem(ItemType.Conjunctions);
        //}

        //private void toolStripButton6_Click(object sender, EventArgs e)
        //{
        //    AddDynamicItemForm adif = new AddDynamicItemForm(ItemType.Particles);

        //    adif.ShowDialog(this);
        //    adif.Dispose();
        //    LoadDynamicItem(ItemType.Particles);
        //}

        //private void toolStripButton7_Click(object sender, EventArgs e)
        //{
        //    AddDynamicItemForm adif = new AddDynamicItemForm(ItemType.Intersections);

        //    adif.ShowDialog(this);
        //    adif.Dispose();
        //    LoadDynamicItem(ItemType.Intersections);
        //}

        //private void tvConjunctions_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    CollapseNotSelectedItems(tvConjunctions, e);
        //}

        //private void tvParticles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    CollapseNotSelectedItems(tvVerbs, e);
        //}

        //private void tvInterjections_AfterCheck(object sender, TreeViewEventArgs e)
        //{
        //    AfterTreeViewClick();
        //}

        //private void tvConjunctions_AfterCheck(object sender, TreeViewEventArgs e)
        //{
        //    AfterTreeViewClick();
        //}

        //private void tvParticles_AfterCheck(object sender, TreeViewEventArgs e)
        //{
        //    AfterTreeViewClick();
        //}

        //private void tvInterjections_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    CollapseNotSelectedItems(tvInterjections, e);
        //}
    }
}
