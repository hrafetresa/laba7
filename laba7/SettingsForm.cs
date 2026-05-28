using laba7;
using System;
using System.Windows.Forms;

namespace laba7
{
    public partial class SettingsForm : Form
    {
        private MainForm _mainForm;

        public SettingsForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            cmbThemeStyle.SelectedItem = Properties.Settings.Default.ColorTheme == "Dark" ? "Тёмная" : "Светлая";
            numSpeed.Value = Properties.Settings.Default.SlideShowSpeed / 1000; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ColorTheme = cmbThemeStyle.SelectedItem.ToString() == "Тёмная" ? "Dark" : "Light";
            Properties.Settings.Default.SlideShowSpeed = (int)numSpeed.Value * 1000;
            Properties.Settings.Default.Save();

            _mainForm.ApplySettings();
            this.Close();
        }
    }
}