using laba7;
using System;
using System.Windows.Forms;

namespace laba7
{
    public partial class SettingsForm : Form
    {
        private MainForm _mainForm;
        private bool _isLoading = true; 

        public SettingsForm(MainForm mainForm)
        {
            MainForm.ApplyThemeToForm(this);
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            _isLoading = true; 

            
            cmbThemeStyle.SelectedItem = Properties.Settings.Default.ColorTheme == "Dark" ? "Тёмная" : "Светлая";

            
            int currentInterval = Properties.Settings.Default.SlideShowSpeed;

            if (currentInterval <= 1000) trackSpeed.Value = 5;       
            else if (currentInterval <= 2000) trackSpeed.Value = 4;  
            else if (currentInterval <= 3000) trackSpeed.Value = 3;  
            else if (currentInterval <= 4000) trackSpeed.Value = 2;  
            else trackSpeed.Value = 1;                               

            _isLoading = false; 
        }

        
        private void trackSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (_isLoading) return; 

            int intervalInMs;
            switch (trackSpeed.Value)
            {
                case 1: intervalInMs = 5000; break; 
                case 2: intervalInMs = 4000; break; 
                case 3: intervalInMs = 3000; break; 
                case 4: intervalInMs = 2000; break; 
                case 5: intervalInMs = 1000; break; 
                default: intervalInMs = 3000; break;
            }

            Properties.Settings.Default.SlideShowSpeed = intervalInMs;
            Properties.Settings.Default.Save(); 

            _mainForm.ApplySettings(); 
        }

        private void cmbThemeStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading || cmbThemeStyle.SelectedItem == null) return;

            Properties.Settings.Default.ColorTheme = cmbThemeStyle.SelectedItem.ToString() == "Тёмная" ? "Dark" : "Light";
            Properties.Settings.Default.Save();

            _mainForm.ApplySettings(); 
            MainForm.ApplyThemeToForm(this); 
        }
    }
}