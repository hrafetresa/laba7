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
            ApplyThemeToForm(this);

            int savedInterval = Properties.Settings.Default.SlideShowSpeed;

            if (savedInterval <= 0)
            {
                savedInterval = 3000;
            }

            tmrSlideShow.Interval = savedInterval;

            if (_isSlideShowActive)
            {
                tmrSlideShow.Stop();
                tmrSlideShow.Start();
            }
        }

        public static void ApplyThemeToForm(Form form)
        {
            string theme = Properties.Settings.Default.ColorTheme;

            Color backColor;
            Color foreColor;

            if (theme == "Dark")
            {
                backColor = Color.FromArgb(45, 45, 48);      
                foreColor = Color.White;                     
            }
            else
            {
                backColor = SystemColors.Control;            
                foreColor = SystemColors.ControlText;       
            }

            form.BackColor = backColor;
            form.ForeColor = foreColor;

            ChangeControlsColor(form.Controls, backColor, foreColor, theme == "Dark");
        }

        private static void ChangeControlsColor(Control.ControlCollection controls, Color back, Color fore, bool isDark)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is PictureBox) continue; 

                if (ctrl is Button btn)
                {
                    if (isDark)
                    {
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.BackColor = Color.FromArgb(63, 63, 70);
                        btn.FlatAppearance.BorderColor = Color.FromArgb(85, 85, 85);
                        btn.ForeColor = Color.White;
                    }
                    else
                    {
                        btn.FlatStyle = FlatStyle.Standard;
                        btn.BackColor = SystemColors.Control;
                        btn.ForeColor = SystemColors.ControlText;
                    }
                    continue;
                }

                if (ctrl is GroupBox gbx)
                {
                    if (isDark)
                    {

                        gbx.FlatStyle = FlatStyle.Flat;
                    }
                    else
                    {
                        gbx.FlatStyle = FlatStyle.Standard;
                    }

                    gbx.ForeColor = fore; 

                    if (gbx.HasChildren)
                    {
                        ChangeControlsColor(gbx.Controls, back, fore, isDark);
                    }
                    continue;
                }

                if (ctrl is TextBox txt)
                {
                    txt.BackColor = isDark ? Color.FromArgb(30, 30, 30) : SystemColors.Window;
                    txt.ForeColor = fore;
                    continue;
                }

                if (ctrl is ComboBox || ctrl is ListBox)
                {
                    ctrl.BackColor = isDark ? Color.FromArgb(30, 30, 30) : SystemColors.Window;
                    ctrl.ForeColor = fore;
                    continue;
                }


                ctrl.BackColor = back;
                ctrl.ForeColor = fore;

                if (ctrl.HasChildren)
                {
                    ChangeControlsColor(ctrl.Controls, back, fore, isDark);
                }
            }
        }

        private void LoadThemesData()
        {
            cmbThemes.Items.Clear();
            _themes = HistoryManager.LoadData();

            if (Directory.Exists(_baseImgPath))
            {
                string[] directories = Directory.GetDirectories(_baseImgPath);

                foreach (string dir in directories)
                {
                    string folderName = Path.GetFileName(dir);

                    var theme = _themes.Find(t => t.Name.Equals(folderName, StringComparison.OrdinalIgnoreCase));
                    if (theme == null)
                    {
                        theme = new HistoryTheme { Name = folderName };
                        _themes.Add(theme);
                    }

                    string[] extensions = { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif" };
                    bool wasXmlUpdated = false;

                    foreach (var ext in extensions)
                    {
                        string[] files = Directory.GetFiles(dir, ext);
                        foreach (var file in files)
                        {
                            string fileName = Path.GetFileName(file);
                            var existingEvent = theme.Events.Find(e => e.ImageName != null && e.ImageName.Equals(fileName, StringComparison.OrdinalIgnoreCase));

                            if (existingEvent == null)
                            {
                                theme.Events.Add(new HistoryEvent
                                {
                                    Title = Path.GetFileNameWithoutExtension(fileName),
                                    Description = "",
                                    QuestionText = "",
                                    ImageName = fileName,
                                    Answers = new List<HistoryAnswer>
                            {
                                new HistoryAnswer { Text = "", IsCorrect = true },
                                new HistoryAnswer { Text = "", IsCorrect = false },
                                new HistoryAnswer { Text = "", IsCorrect = false },
                                new HistoryAnswer { Text = "", IsCorrect = false }
                            }
                                });
                                wasXmlUpdated = true;
                            }
                        }
                    }

                    if (wasXmlUpdated)
                    {
                        HistoryManager.SaveData(_themes);
                    }
                }
            }

            foreach (var t in _themes)
            {
                if (Directory.Exists(Path.Combine(_baseImgPath, t.Name)))
                {
                    cmbThemes.Items.Add(t.Name);
                }
            }

            if (cmbThemes.Items.Count > 0)
            {
                cmbThemes.SelectedIndex = 0;
            }
            else
            {
                _currentTheme = null;
                ClearEventDisplay();
            }
        }

        private List<string> _currentThemeImageFiles = new List<string>();

        private void cmbThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbThemes.SelectedIndex == -1) return;

            string selectedThemeName = cmbThemes.SelectedItem.ToString();
            _currentTheme = _themes.Find(t => t.Name == selectedThemeName);
            _currentEventIndex = 0;

            string themeFolderPath = Path.Combine(_baseImgPath, selectedThemeName);
            _currentThemeImageFiles.Clear();

            if (Directory.Exists(themeFolderPath))
            {
                string[] extensions = { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif" };
                foreach (var ext in extensions)
                {
                    string[] files = Directory.GetFiles(themeFolderPath, ext);
                    foreach (var file in files)
                    {
                        _currentThemeImageFiles.Add(Path.GetFileName(file));
                    }
                }
            }

            ShowEvent();
        }

        private void ShowEvent()
        {
            if (_currentThemeImageFiles.Count == 0)
            {
                ClearEventDisplay();
                return;
            }

            if (_currentEventIndex >= _currentThemeImageFiles.Count) _currentEventIndex = 0;
            if (_currentEventIndex < 0) _currentEventIndex = _currentThemeImageFiles.Count - 1;

            btnPrev.Enabled = true;
            btnNext.Enabled = true;

            bool hasQuestions = false;
            if (_currentTheme != null)
            {
                foreach (var ev in _currentTheme.Events)
                {
                    if (!string.IsNullOrWhiteSpace(ev.QuestionText))
                    {
                        hasQuestions = true;
                        break; 
                    }
                }
            }
            btnStartTest.Enabled = hasQuestions;

            string currentImageName = _currentThemeImageFiles[_currentEventIndex];
            string fullPath = Path.Combine(_baseImgPath, cmbThemes.SelectedItem.ToString(), currentImageName);

            if (File.Exists(fullPath))
            {
                picBox.Image?.Dispose(); 
                using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                {
                    picBox.Image = Image.FromStream(stream);
                }
            }
            else
            {
                picBox.Image = null;
            }

            txtDescription.Clear();
            if (_currentTheme != null)
            {
                var matchedEvent = _currentTheme.Events.Find(ev => ev.ImageName != null && ev.ImageName.Equals(currentImageName, StringComparison.OrdinalIgnoreCase));
                if (matchedEvent != null)
                {
                    txtDescription.Text = $"=== {matchedEvent.Title} ===\r\n\r\n{matchedEvent.Description}";
                }
                else
                {
                    txtDescription.Text = $"Файл: {currentImageName}\r\n(Описание исторического события не добавлено в админке)";
                }
            }
        }

        private void Navigate(int direction)
        {
            if (_currentThemeImageFiles.Count == 0) return;
            _currentEventIndex += direction;
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

        private void ClearEventDisplay()
        {
            picBox.Image?.Dispose(); 
            picBox.Image = null;     
            txtDescription.Clear(); 

            btnPrev.Enabled = false;
            btnNext.Enabled = false;
            btnStartTest.Enabled = false;
        }
    }
}