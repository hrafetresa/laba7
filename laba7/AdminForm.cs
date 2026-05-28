using laba7;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace laba7
{
    public partial class AdminForm : Form
    {
        private List<HistoryTheme> _themes;
        private HistoryTheme _selectedTheme;
        private HistoryEvent _selectedEvent;

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            RefreshThemes();
        }

        private void RefreshThemes()
        {
            _themes = HistoryManager.LoadData();
            lstThemes.Items.Clear();
            foreach (var t in _themes) lstThemes.Items.Add(t.Name);
            lstEvents.Items.Clear();
            ClearEventFields();
        }

        private void btnAddTheme_Click(object sender, EventArgs e)
        {
            string themeName = txtNewThemeName.Text.Trim();
            if (string.IsNullOrEmpty(themeName)) return;

            string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Themes", themeName);
            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);

            _themes.Add(new HistoryTheme { Name = themeName });
            HistoryManager.SaveData(_themes);
            txtNewThemeName.Clear();
            RefreshThemes();
        }

        private void lstThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstThemes.SelectedIndex == -1) return;
            _selectedTheme = _themes[lstThemes.SelectedIndex];

            lstEvents.Items.Clear();
            foreach (var ev in _selectedTheme.Events)
            {
                lstEvents.Items.Add(ev.ImageName ?? "Событие без картинки");
            }
            ClearEventFields();
        }

        private void btnAddImageEvent_Click(object sender, EventArgs e)
        {
            if (_selectedTheme == null)
            {
                MessageBox.Show("Сначала выберите тему!");
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string fileName = Path.GetFileName(ofd.FileName);
                    string targetDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Themes", _selectedTheme.Name);
                    string targetPath = Path.Combine(targetDir, fileName);

                    if (!Directory.Exists(targetDir)) Directory.CreateDirectory(targetDir);

                    // Копирование файла в директорию темы согласно ТЗ
                    if (!File.Exists(targetPath)) File.Copy(ofd.FileName, targetPath);

                    var newEvent = new HistoryEvent
                    {
                        ImageName = fileName,
                        Description = "Новое описание..."
                    };
                    _selectedTheme.Events.Add(newEvent);
                    HistoryManager.SaveData(_themes);

                    lstThemes_SelectedIndexChanged(null, null);
                }
            }
        }

        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEvents.SelectedIndex == -1 || _selectedTheme == null) return;
            _selectedEvent = _selectedTheme.Events[lstEvents.SelectedIndex];

            txtDescEdit.Text = _selectedEvent.Description;
            txtQuestionEdit.Text = _selectedEvent.QuestionText;

            txtAns1.Text = _selectedEvent.Answers.Count > 0 ? _selectedEvent.Answers[0].Text : "";
            txtAns2.Text = _selectedEvent.Answers.Count > 1 ? _selectedEvent.Answers[1].Text : "";
            txtAns3.Text = _selectedEvent.Answers.Count > 2 ? _selectedEvent.Answers[2].Text : "";

            rb1.Checked = _selectedEvent.Answers.Count > 0 && _selectedEvent.Answers[0].IsCorrect;
            rb2.Checked = _selectedEvent.Answers.Count > 1 && _selectedEvent.Answers[1].IsCorrect;
            rb3.Checked = _selectedEvent.Answers.Count > 2 && _selectedEvent.Answers[2].IsCorrect;
        }

        private void btnSaveEventChanges_Click(object sender, EventArgs e)
        {
            if (_selectedEvent == null) return;

            _selectedEvent.Description = txtDescEdit.Text;
            _selectedEvent.QuestionText = txtQuestionEdit.Text;

            _selectedEvent.Answers.Clear();
            _selectedEvent.Answers.Add(new HistoryAnswer { Text = txtAns1.Text, IsCorrect = rb1.Checked });
            _selectedEvent.Answers.Add(new HistoryAnswer { Text = txtAns2.Text, IsCorrect = rb2.Checked });
            _selectedEvent.Answers.Add(new HistoryAnswer { Text = txtAns3.Text, IsCorrect = rb3.Checked });

            HistoryManager.SaveData(_themes);
            MessageBox.Show("Данные события обновлены и сохранены в XML.");
        }

        private void ClearEventFields()
        {
            _selectedEvent = null;
            txtDescEdit.Clear();
            txtQuestionEdit.Clear();
            txtAns1.Clear(); txtAns2.Clear(); txtAns3.Clear();
            rb1.Checked = true;
        }
    }
}