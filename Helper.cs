using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Alev
{
    public class Helper
    {
        #region hide check box at root nodes
        private const int TVIF_STATE = 0x8;
        private const int TVIS_STATEIMAGEMASK = 0xF000;
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETITEM = TV_FIRST + 63;

        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
        private struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam,
                                                 ref TVITEM lParam);

        /// <summary>
        /// Hides the checkbox for the specified node on a TreeView control.
        /// </summary>
        public static void HideCheckBox(TreeView tvw, TreeNode node)
        {
            TVITEM tvi = new TVITEM();
            tvi.hItem = node.Handle;
            tvi.mask = TVIF_STATE;
            tvi.stateMask = TVIS_STATEIMAGEMASK;
            tvi.state = 0;
            SendMessage(tvw.Handle, TVM_SETITEM, IntPtr.Zero, ref tvi);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">Example; nouns.xml</param>
        /// <param name="tagName">Example; noun</param>
        /// <param name="dict"></param>
        public static void LoadItemsFromFile(string fileName, string tagName, Dictionary<string, string> dict)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNodeList node = doc.GetElementsByTagName(tagName);

            foreach (XmlNode xn in node)
            {
                dict.Add(xn.FirstChild.InnerText, xn.LastChild.InnerText);
            }
        }

        public static void LoadStaticItems(Dictionary<string, string> dict)
        {
            dict.Add("p1s", "p1s");
            dict.Add("p2s", "p2s");
            dict.Add("p3s", "p3s");
            dict.Add("p1p", "p1p");
            dict.Add("p2p", "p2p");
            dict.Add("p3p", "p3p");

            dict.Add("pss1s", "pss1s");
            dict.Add("pss2s", "pss2s");
            dict.Add("pss3s", "pss3s");
            dict.Add("pss1p", "pss1p");
            dict.Add("pss2p", "pss2p");
            dict.Add("pss3p", "pss3p");

            dict.Add("Exist", "Existential");
            dict.Add("ExistNeg", "Existential Neg");
            dict.Add("Hvow", "Vowel harmony");
            dict.Add("Hcons", "Consonant harmony");

            dict.Add("dat", "dative");
            dict.Add("loc", "locative");
            dict.Add("abl", "ablative");
            //dict.Add("ins", "instrumental");
            //dict.Add("gen", "genetive");
            dict.Add("acc", "accusative");
            dict.Add("nom", "nominative");

            dict.Add("buff", "Buffer letter");

            dict.Add("Q", "Question particle");

            dict.Add("NegmA", "Neg mA");
            dict.Add("Değil", "Değil");

            dict.Add("prep", "Preposition");

            dict.Add("Tprog", "Present progressive tense suffix");
            dict.Add("Tpres", "Simple present tense");
            dict.Add("Tpast", "Past tense suffix (DI)");
            dict.Add("TInEvPast", "Indirect evidence past tense");
            dict.Add("PastCon", "Past continous");
            dict.Add("futur", "Future tense");

            dict.Add("plr", "Plural");
            dict.Add("partip", "Participles");
            dict.Add("Adv", "Adverb");
            dict.Add("Adj", "Adjective");
            //dict.Add("postPos", "Post position");// sil
            dict.Add("part", "Particles");
            dict.Add("Conj", "Conjunction");
            dict.Add("Intj", "Interjection");
            dict.Add("Abil", "Ability");
            dict.Add("iuon", "Incorrect use of noun");
            dict.Add("softCons", "Softening of consonants");
            dict.Add("pron", "Prononciation");
            dict.Add("RepSp", "Reported speech");
            dict.Add("necc", "Necessity");
            dict.Add("wOrder", "Word order");
            dict.Add("con", "If conditional");
            dict.Add("req", "Request");
            dict.Add("impr", "Imperative");
            dict.Add("compNoun", "Compound noun");
        }

        #region Load Dynamic Items
        public static void LoadDynamicItem(TreeView tv, ItemType itemType)
        {
            var itemNamePlural = itemType.ToString();
            var itemNamePluralLowerCase = itemType.ToString().ToLower().Replace('ı', 'i');
            var itemNameSingular = itemNamePlural.Substring(0, itemType.ToString().Length - 1);
            var itemNameSingularLowerCase = itemNamePlural.Substring(0, itemType.ToString().Length - 1).ToLower().Replace('ı', 'i');

            tv.Nodes.Clear();

            XDocument doc = XDocument.Load(itemNamePluralLowerCase + ".xml");

            var dynamicItems = from v in doc.Descendants(itemNamePluralLowerCase).Descendants(itemNameSingularLowerCase)
                               select new
                               {
                                   Key = v.Element("key").Value,
                                   Value = v.Element("value").Value
                               };

            dynamicItems = dynamicItems.OrderBy(x => x.Value);

            var letters = dynamicItems.Select(x => x.Value.Substring(0, 1).ToUpper()).Distinct().ToList();

            for (int i = 0; i < letters.Count; i++)
            {
                tv.Nodes.Add(letters[i]);
                Helper.HideCheckBox(tv, tv.Nodes[i]);

                foreach (var kvp in dynamicItems.Where(x => x.Value.StartsWith(letters[i], StringComparison.CurrentCultureIgnoreCase)))
                {
                    tv.Nodes[i].Nodes.Add(kvp.Key, kvp.Value);
                }
            }

            doc = null;
        }
        #endregion

        public static string SaveMyFile(RichTextBox rtb)
        {
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extention for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";

            // Determine whether the user selected a file name from the saveFileDialog. 
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                rtb.SaveFile(saveFile1.FileName);
                return saveFile1.FileName;
            }

            return "";
        }
    }
}
