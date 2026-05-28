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
            InitializeComponent();
            _event = ev;
        }

        private void TestQuestionForm_Load(object sender, EventArgs e)
        {
            lblQuestion.Text = _event.QuestionText;
            pnlAnswers.Controls.Clear();

            int top = 10;
            for (int i = 0; i < _event.Answers.Count; i++)
            {
                RadioButton rb = new RadioButton
                {
                    Text = _event.Answers[i].Text,
                    Tag = _event.Answers[i].IsCorrect,
                    Top = top,
                    Left = 10,
                    AutoSize = true
                };
                pnlAnswers.Controls.Add(rb);
                top += 30;
            }
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