namespace laba7
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbThemes = new System.Windows.Forms.ComboBox();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnToggleSlideShow = new System.Windows.Forms.Button();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrSlideShow = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbThemes
            // 
            this.cmbThemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThemes.FormattingEnabled = true;
            this.cmbThemes.Location = new System.Drawing.Point(26, 59);
            this.cmbThemes.Name = "cmbThemes";
            this.cmbThemes.Size = new System.Drawing.Size(121, 21);
            this.cmbThemes.TabIndex = 0;
            this.cmbThemes.SelectedIndexChanged += new System.EventHandler(this.cmbThemes_SelectedIndexChanged);
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(26, 103);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(219, 145);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(269, 103);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(240, 145);
            this.txtDescription.TabIndex = 2;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(93, 267);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(34, 23);
            this.btnPrev.TabIndex = 3;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(133, 267);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnToggleSlideShow
            // 
            this.btnToggleSlideShow.Location = new System.Drawing.Point(83, 296);
            this.btnToggleSlideShow.Name = "btnToggleSlideShow";
            this.btnToggleSlideShow.Size = new System.Drawing.Size(92, 23);
            this.btnToggleSlideShow.TabIndex = 4;
            this.btnToggleSlideShow.Text = "Старт Слайд-шоу";
            this.btnToggleSlideShow.UseVisualStyleBackColor = true;
            this.btnToggleSlideShow.Click += new System.EventHandler(this.btnToggleSlideShow_Click);
            // 
            // btnStartTest
            // 
            this.btnStartTest.Location = new System.Drawing.Point(83, 325);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(92, 23);
            this.btnStartTest.TabIndex = 4;
            this.btnStartTest.Text = "Пройти тест";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSettings,
            this.btnAdmin});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(544, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnSettings
            // 
            this.btnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(79, 20);
            this.btnSettings.Text = "Настройки";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(134, 20);
            this.btnAdmin.Text = "Администрирование";
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // tmrSlideShow
            // 
            this.tmrSlideShow.Tick += new System.EventHandler(this.tmrSlideShow_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Тема:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 375);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartTest);
            this.Controls.Add(this.btnToggleSlideShow);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.cmbThemes);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbThemes;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnToggleSlideShow;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnSettings;
        private System.Windows.Forms.ToolStripMenuItem btnAdmin;
        private System.Windows.Forms.Timer tmrSlideShow;
        private System.Windows.Forms.Label label1;
    }
}

