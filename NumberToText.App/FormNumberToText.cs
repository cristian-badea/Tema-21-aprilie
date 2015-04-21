using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Humanizer;
using System.Globalization;

namespace NumberToText.App
{
    public partial class FormNumberToText : Form
    {

        public FormNumberToText()
        {
            InitializeComponent();
            Dictionary<string, string> _comboBoxDictionary = new Dictionary<string, string>();
            _comboBoxDictionary.Add("en", "English");
            _comboBoxDictionary.Add("fr", "French");
            _comboBoxDictionary.Add("it", "Italian");
            _comboBoxDictionary.Add("de", "German");

            comboBoxLanguage.DataSource = new BindingSource(_comboBoxDictionary, null);
            comboBoxLanguage.DisplayMember = "Value";
            comboBoxLanguage.ValueMember = "Key";

            comboBoxLanguage.SelectedIndex = 0;
        }

        private void textBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char character = e.KeyChar;
            if (Char.IsDigit(character) == false && character != 8)
            {
                e.Handled = true;
                MessageBox.Show("Only numbers!");
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (textBoxNumber.Text != "")
            {
                labelText.Text = int.Parse(textBoxNumber.Text).ToWords(new CultureInfo(((KeyValuePair<string, string>)comboBoxLanguage.SelectedItem).Key));
                
            }
            else
            {
                MessageBox.Show("Please insert a number first!");
            }
        }
    }
}
