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

namespace XMLConverter
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            fillDropdowns();
        }

        private void fillDropdowns() 
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\Vlad_2\repos\C#\XMLConverter\XMLConverter\ProgLanguages.xml");
            XmlElement root = doc.DocumentElement;
            if (root != null) 
            {
                XmlNodeList childNodes = root.SelectNodes("ProgLanguage");
                for (int i = 0; i < childNodes.Count; i++) 
                {
                    XmlNode childNode = childNodes.Item(i);
                    addItemsToDropdown(childNode);
                }
            }
        }

        private void addItemsToDropdown (XmlNode node) 
        {
            checkPropertyKey(LanguageNameComboBox, node, "@LanguageName");
            checkPropertyKey(AuthorsComboBox, node, "@Authors");
            checkPropertyKey(LanguageTypeComboBox, node, "@TypeOfLanguage");
            checkPropertyKey(ReleaseYearComboBox, node, "@ReleaseYear");
            checkPropertyKey(AbstractionLevelComboBox, node, "@AbstractionLevel");
            checkPropertyKey(CommonUsageComboBox, node, "@CommonlyUsedFor");
        }

        private void checkPropertyKey(ComboBox comboBox, XmlNode node, string property) 
        {
            if (!comboBox.Items.Contains(node.SelectSingleNode(property).Value))
            {
                comboBox.Items.Add(node.SelectSingleNode(property).Value);
                //Console.WriteLine(node.SelectSingleNode(property).Value);
            }
        }
    }
}
