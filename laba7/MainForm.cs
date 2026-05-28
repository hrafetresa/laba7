using laba7;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace laba7
{
    public partial class MainForm : Form
    {
        private List<HistoryTheme> _themes;
        private HistoryTheme _currentTheme;
        private int _currentEventIndex = 0;
        private bool _isSlideShowActive = false;
        private string _baseImgPath;

        public MainForm()
        {
            InitializeComponent();
            this.KeyPreview = true; 
            _baseImgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Themes");
            if (!Directory.Exists(_baseImgPath)) Directory.CreateDirectory(_baseImgPath);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ApplySettings();
            LoadThemesData();
        }

        public void ApplySettings()
        {
            string theme = Properties.Settings.Default.ColorTheme;
            if (theme == "Dark")
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
                this.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;
            }

  
            tmrSlideShow.Interval = Properties.Settings.Default.SlideShowSpeed;
        }

        private void LoadThemesData()
        {
            _themes = HistoryManager.LoadData();
            cmbThemes.Items.Clear();
            foreach (var t in _themes)
            {
                cmbThemes.Items.Add(t.Name);
            }
            if (cmbThemes.Items.Count > 0) cmbThemes.SelectedIndex = 0;
        }

        private void cmbThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbThemes.SelectedIndex == -1) return;
            _currentTheme = _themes[cmbThemes.SelectedIndex];
            _currentEventIndex = 0;
            ShowEvent();
        }

        private void ShowEvent()
        {
            if (_currentTheme == null || _currentTheme.Events.Count == 0)
            {
                picBox.Image = null;
                txtDescription.Text = "В этой теме нет событий.";
                btnStartTest.Enabled = false;
                return;
            }

            btnStartTest.Enabled = true;
            var ev = _currentTheme.Events[_currentEventIndex];
            txtDescription.Text = ev.Description;

            string fullPath = Path.Combine(_baseImgPath, _currentTheme.Name, ev.ImageName ?? "");
            if (File.Exists(fullPath))
            {
                picBox.Image?.Dispose();
                picBox.Image = Image.FromFile(fullPath);
            }
            else
            {
                picBox.Image = null;
            }
        }

        private void Navigate(int direction)
        {
            if (_currentTheme == null || _currentTheme.Events.Count == 0) return;
            _currentEventIndex += direction;

            if (_currentEventIndex >= _currentTheme.Events.Count) _currentEventIndex = 0;
            if (_currentEventIndex < 0) _currentEventIndex = _currentTheme.Events.Count - 1;

            ShowEvent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Right) { Navigate(1); return true; }
            if (keyData == Keys.Left) { Navigate(-1); return true; }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnPrev_Click(object sender, EventArgs e) => Navigate(-1);
        private void btnNext_Click(object sender, EventArgs e) => Navigate(1);

        private void btnToggleSlideShow_Click(object sender, EventArgs e)
        {
            _isSlideShowActive = !_isSlideShowActive;
            if (_isSlideShowActive)
            {
                tmrSlideShow.Start();
                btnToggleSlideShow.Text = "Стоп Слайд-шоу";
            }
            else
            {
                tmrSlideShow.Stop();
                btnToggleSlideShow.Text = "Старт Слайд-шоу";
            }
        }

        private void tmrSlideShow_Tick(object sender, EventArgs e) => Navigate(1);

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (SettingsForm sf = new SettingsForm(this))
            {
                sf.ShowDialog();
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            tmrSlideShow.Stop();
            _isSlideShowActive = false;
            btnToggleSlideShow.Text = "Старт Слайд-шоу";

            using (AdminForm af = new AdminForm())
            {
                af.ShowDialog();
            }
            LoadThemesData(); 
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            if (_currentTheme == null || _currentTheme.Events.Count == 0) return;

            int score = 0;
            foreach (var ev in _currentTheme.Events)
            {
                if (string.IsNullOrWhiteSpace(ev.QuestionText)) continue;

                using (TestQuestionForm tqf = new TestQuestionForm(ev))
                {
                    if (tqf.ShowDialog() == DialogResult.OK && tqf.IsCorrectAnswer)
                    {
                        score++;
                    }
                }
            }
            MessageBox.Show($"Тестирование завершено!\nПравильных ответов: {score} из {_currentTheme.Events.Count}", "Результат теста");
        }
    }
}