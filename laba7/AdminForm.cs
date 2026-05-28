using laba7;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            MainForm.ApplyThemeToForm(this);
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            RefreshThemes();
        }

        private void RefreshThemes()
        {
            // 1. Загружаем данные из XML
            _themes = HistoryManager.LoadData();
            lstThemes.Items.Clear();

            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Themes");
            if (Directory.Exists(basePath))
            {
                string[] themeDirs = Directory.GetDirectories(basePath);

                foreach (string dir in themeDirs)
                {
                    string themeName = Path.GetFileName(dir);

                    var theme = _themes.Find(t => t.Name.Equals(themeName, StringComparison.OrdinalIgnoreCase));
                    if (theme == null)
                    {
                        theme = new HistoryTheme { Name = themeName };
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
                if (Directory.Exists(Path.Combine(basePath, t.Name)))
                {
                    lstThemes.Items.Add(t.Name);
                }
            }

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
                lstEvents.Items.Add(string.IsNullOrEmpty(ev.Title) ? "Событие без названия" : ev.Title);
            }
            ClearEventFields();
            if (_selectedTheme.Events.Count > 0)
            {
                lstEvents.SelectedIndex = 0;
            }
        }

        private void btnAddImageEvent_Click(object sender, EventArgs e)
        {
            if (_selectedTheme == null || _selectedEvent == null)
            {
                MessageBox.Show("Сначала выберите или создайте событие в списке!");
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Графические файлы|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Выберите картинку для исторического события";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string themeDirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Themes", _selectedTheme.Name);
                        if (!Directory.Exists(themeDirPath))
                        {
                            Directory.CreateDirectory(themeDirPath);
                        }

                        string sourceFilePath = ofd.FileName;
                        string fileName = Path.GetFileName(sourceFilePath);
                        string destFilePath = Path.Combine(themeDirPath, fileName);

                        if (File.Exists(destFilePath) && sourceFilePath != destFilePath)
                        {
                            string nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
                            string ext = Path.GetExtension(fileName);
                            fileName = $"{nameWithoutExt}_{DateTime.Now.Ticks}{ext}";
                            destFilePath = Path.Combine(themeDirPath, fileName);
                        }

                        if (sourceFilePath != destFilePath)
                        {
                            File.Copy(sourceFilePath, destFilePath, true);
                        }

                        _selectedEvent.ImageName = fileName;
                        HistoryManager.SaveData(_themes);

                        UpdateEventImagePreview();
                        UpdateImageButtonText();

                        MessageBox.Show($"Картинка {fileName} успешно скопирована в тему и привязана!", "Успех");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при копировании файла: {ex.Message}", "Ошибка");
                    }
                }
            }
        }

        private void UpdateEventImagePreview()
        {
            if (_selectedTheme == null || _selectedEvent == null || string.IsNullOrEmpty(_selectedEvent.ImageName))
            {
                pictureBoxEventImage.Image = null;
                return;
            }

            string imgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Themes", _selectedTheme.Name, _selectedEvent.ImageName);

            if (File.Exists(imgPath))
            {
                try
                {
                    pictureBoxEventImage.Image?.Dispose();
                    using (var stream = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
                    {
                        pictureBoxEventImage.Image = Image.FromStream(stream);
                    }
                }
                catch
                {
                    pictureBoxEventImage.Image = null;
                }
            }
            else
            {
                pictureBoxEventImage.Image = null;
            }
        }

        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEvents.SelectedIndex == -1 || _selectedTheme == null)
            {
                ClearEventFields(); 
                return;
            }

            _selectedEvent = _selectedTheme.Events[lstEvents.SelectedIndex]; 

            grpEventEdit.Enabled = true;

            txtTitleEdit.Text = _selectedEvent.Title; 
            txtDescEdit.Text = _selectedEvent.Description; 
            txtQuestionEdit.Text = _selectedEvent.QuestionText; 

            txtAns1.Text = _selectedEvent.Answers.Count > 0 ? _selectedEvent.Answers[0].Text : ""; 
            txtAns2.Text = _selectedEvent.Answers.Count > 1 ? _selectedEvent.Answers[1].Text : ""; 
            txtAns3.Text = _selectedEvent.Answers.Count > 2 ? _selectedEvent.Answers[2].Text : ""; 
            txtAns4.Text = _selectedEvent.Answers.Count > 3 ? _selectedEvent.Answers[3].Text : ""; 

            rb1.Checked = _selectedEvent.Answers.Count > 0 && _selectedEvent.Answers[0].IsCorrect; 
            rb2.Checked = _selectedEvent.Answers.Count > 1 && _selectedEvent.Answers[1].IsCorrect; 
            rb3.Checked = _selectedEvent.Answers.Count > 2 && _selectedEvent.Answers[2].IsCorrect; 
            rb4.Checked = _selectedEvent.Answers.Count > 3 && _selectedEvent.Answers[3].IsCorrect; 

            UpdateImageButtonText(); 
            UpdateEventImagePreview(); 
        }

        private void UpdateImageButtonText()
        {
            if (_selectedEvent == null || string.IsNullOrEmpty(_selectedEvent.ImageName))
            {
                btnAddImageEvent.Text = "Добавить картинку";
                return;
            }
            string imgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Themes", _selectedTheme.Name, _selectedEvent.ImageName);
            if (File.Exists(imgPath))
            {
                btnAddImageEvent.Text = "Изменить картинку";
            }
            else
            {
                btnAddImageEvent.Text = "Добавить картинку";
            }
        }

        private void btnSaveEventChanges_Click(object sender, EventArgs e)
        {
            if (_selectedEvent == null) return;

            _selectedEvent.Title = txtTitleEdit.Text.Trim();
            _selectedEvent.Description = txtDescEdit.Text;
            _selectedEvent.QuestionText = txtQuestionEdit.Text;

            _selectedEvent.Answers.Clear();

            if (!string.IsNullOrWhiteSpace(txtAns1.Text))
                _selectedEvent.Answers.Add(new HistoryAnswer { Text = txtAns1.Text.Trim(), IsCorrect = rb1.Checked });

            if (!string.IsNullOrWhiteSpace(txtAns2.Text))
                _selectedEvent.Answers.Add(new HistoryAnswer { Text = txtAns2.Text.Trim(), IsCorrect = rb2.Checked });

            if (!string.IsNullOrWhiteSpace(txtAns3.Text))
                _selectedEvent.Answers.Add(new HistoryAnswer { Text = txtAns3.Text.Trim(), IsCorrect = rb3.Checked });

            if (!string.IsNullOrWhiteSpace(txtAns4.Text))
                _selectedEvent.Answers.Add(new HistoryAnswer { Text = txtAns4.Text.Trim(), IsCorrect = rb4.Checked });

            HistoryManager.SaveData(_themes);

            int currentIndex = lstEvents.SelectedIndex;
            lstThemes_SelectedIndexChanged(null, null);
            if (currentIndex >= 0 && currentIndex < lstEvents.Items.Count)
            {
                lstEvents.SelectedIndex = currentIndex;
            }

            MessageBox.Show("Данные события успешно сохранены!");
        }

        private void ClearEventFields()
        {
            _selectedEvent = null; 
            txtTitleEdit.Clear(); 
            txtDescEdit.Clear(); 
            txtQuestionEdit.Clear(); 
            txtAns1.Clear(); txtAns2.Clear(); txtAns3.Clear(); txtAns4.Clear(); 
            rb1.Checked = true; 
            btnAddImageEvent.Text = "Добавить картинку"; 
            pictureBoxEventImage.Image = null; 

            grpEventEdit.Enabled = false;
        }

        private void btnDeleteTheme_Click(object sender, EventArgs e)
        {
            if (lstThemes.SelectedIndex == -1 || _selectedTheme == null)
            {
                MessageBox.Show("Выберите тему для удаления!", "Предупреждение");
                return;
            }

            var dialogResult = MessageBox.Show(
                $"Вы уверены, что хотите удалить тему \"{_selectedTheme.Name}\" и все её файлы?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (dialogResult == DialogResult.Yes)
            {
                string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Themes", _selectedTheme.Name);
                if (Directory.Exists(dirPath))
                {
                    try
                    {
                        Directory.Delete(dirPath, true); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не удалось удалить файлы с диска: {ex.Message}");
                    }
                }

                _themes.Remove(_selectedTheme);
                HistoryManager.SaveData(_themes);

                RefreshThemes();
                MessageBox.Show("Тема успешно удалена.");
            }
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            if (lstEvents.SelectedIndex == -1 || _selectedEvent == null || _selectedTheme == null)
            {
                MessageBox.Show("Выберите событие для удаления!", "Предупреждение");
                return;
            }

            var dialogResult = MessageBox.Show(
                "Удалить выбранное событие из этой темы?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialogResult == DialogResult.Yes)
            {
                _selectedTheme.Events.Remove(_selectedEvent);
                HistoryManager.SaveData(_themes);

                lstThemes_SelectedIndexChanged(null, null);
                MessageBox.Show("Событие удалено.");
            }
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            if (_selectedTheme == null)
            {
                MessageBox.Show("Сначала выберите тему!");
                return;
            }

            var newEvent = new HistoryEvent
            {
                Title = "Новое событие",
                Description = "",
                QuestionText = "",
                ImageName = "",
                Answers = new List<HistoryAnswer>
        {
            new HistoryAnswer { Text = "", IsCorrect = true },
            new HistoryAnswer { Text = "", IsCorrect = false },
            new HistoryAnswer { Text = "", IsCorrect = false },
            new HistoryAnswer { Text = "", IsCorrect = false }
        }
            };

            _selectedTheme.Events.Add(newEvent);

            HistoryManager.SaveData(_themes);

            int savedThemeIndex = lstThemes.SelectedIndex;
            RefreshThemes();
            lstThemes.SelectedIndex = savedThemeIndex;

            lstEvents.SelectedIndex = _selectedTheme.Events.Count - 1;
        }
    }
}