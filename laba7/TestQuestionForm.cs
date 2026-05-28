using laba7;
using System;
using System.Windows.Forms;

namespace laba7
{
    public partial class TestQuestionForm : Form
    {
        private HistoryEvent _event;
        public bool IsCorrectAnswer { get; private set; } = false;

        public TestQuestionForm(HistoryEvent ev)
        {
            MainForm.ApplyThemeToForm(this);
            InitializeComponent();
            _event = ev;
        }

        private void TestQuestionForm_Load(object sender, EventArgs e)
        {
            lblQuestion.Text = _event.QuestionText;
            pnlAnswers.Controls.Clear();

            int topOffset = 10; 

            for (int i = 0; i < _event.Answers.Count; i++)
            {
                RadioButton rb = new RadioButton
                {
                    Text = _event.Answers[i].Text,
                    Tag = _event.Answers[i].IsCorrect,
                    Left = 10,
                    Top = topOffset,
                    Width = pnlAnswers.Width - 30, 
                    AutoSize = true 
                };

                pnlAnswers.Controls.Add(rb);

                topOffset += 32;
            }

            pnlAnswers.Height = topOffset + 10;

            btnSubmit.Top = pnlAnswers.Bottom + 15;

            this.Height = btnSubmit.Bottom + 50;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (Control c in pnlAnswers.Controls)
            {
                if (c is RadioButton rb && rb.Checked)
                {
                    IsCorrectAnswer = (bool)rb.Tag;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
            }
            MessageBox.Show("Выберите вариант ответа!", "Предупреждение");
        }
    }
}