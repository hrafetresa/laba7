namespace laba7
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstThemes = new System.Windows.Forms.ListBox();
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.txtNewThemeName = new System.Windows.Forms.TextBox();
            this.btnAddTheme = new System.Windows.Forms.Button();
            this.btnAddImageEvent = new System.Windows.Forms.Button();
            this.txtDescEdit = new System.Windows.Forms.TextBox();
            this.txtQuestionEdit = new System.Windows.Forms.TextBox();
            this.txtAns1 = new System.Windows.Forms.TextBox();
            this.txtAns2 = new System.Windows.Forms.TextBox();
            this.txtAns3 = new System.Windows.Forms.TextBox();
            this.txtAns4 = new System.Windows.Forms.TextBox();
            this.rb1 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.btnSaveEventChanges = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeleteTheme = new System.Windows.Forms.Button();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            this.txtTitleEdit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grpEventEdit = new System.Windows.Forms.GroupBox();
            this.pictureBoxEventImage = new System.Windows.Forms.PictureBox();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.grpEventEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEventImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lstThemes
            // 
            this.lstThemes.FormattingEnabled = true;
            this.lstThemes.Location = new System.Drawing.Point(12, 130);
            this.lstThemes.Name = "lstThemes";
            this.lstThemes.Size = new System.Drawing.Size(168, 95);
            this.lstThemes.TabIndex = 0;
            this.lstThemes.SelectedIndexChanged += new System.EventHandler(this.lstThemes_SelectedIndexChanged);
            // 
            // lstEvents
            // 
            this.lstEvents.FormattingEnabled = true;
            this.lstEvents.Location = new System.Drawing.Point(12, 293);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(168, 95);
            this.lstEvents.TabIndex = 0;
            this.lstEvents.SelectedIndexChanged += new System.EventHandler(this.lstEvents_SelectedIndexChanged);
            // 
            // txtNewThemeName
            // 
            this.txtNewThemeName.Location = new System.Drawing.Point(12, 43);
            this.txtNewThemeName.Name = "txtNewThemeName";
            this.txtNewThemeName.Size = new System.Drawing.Size(168, 20);
            this.txtNewThemeName.TabIndex = 1;
            // 
            // btnAddTheme
            // 
            this.btnAddTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTheme.Location = new System.Drawing.Point(12, 69);
            this.btnAddTheme.Name = "btnAddTheme";
            this.btnAddTheme.Size = new System.Drawing.Size(168, 23);
            this.btnAddTheme.TabIndex = 2;
            this.btnAddTheme.Text = "Добавить тему";
            this.btnAddTheme.UseVisualStyleBackColor = true;
            this.btnAddTheme.Click += new System.EventHandler(this.btnAddTheme_Click);
            // 
            // btnAddImageEvent
            // 
            this.btnAddImageEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddImageEvent.Location = new System.Drawing.Point(217, 116);
            this.btnAddImageEvent.Name = "btnAddImageEvent";
            this.btnAddImageEvent.Size = new System.Drawing.Size(125, 24);
            this.btnAddImageEvent.TabIndex = 3;
            this.btnAddImageEvent.Text = "Добавить картинку";
            this.btnAddImageEvent.UseVisualStyleBackColor = true;
            this.btnAddImageEvent.Click += new System.EventHandler(this.btnAddImageEvent_Click);
            // 
            // txtDescEdit
            // 
            this.txtDescEdit.Location = new System.Drawing.Point(9, 223);
            this.txtDescEdit.Multiline = true;
            this.txtDescEdit.Name = "txtDescEdit";
            this.txtDescEdit.Size = new System.Drawing.Size(337, 179);
            this.txtDescEdit.TabIndex = 4;
            // 
            // txtQuestionEdit
            // 
            this.txtQuestionEdit.Location = new System.Drawing.Point(18, 51);
            this.txtQuestionEdit.Multiline = true;
            this.txtQuestionEdit.Name = "txtQuestionEdit";
            this.txtQuestionEdit.Size = new System.Drawing.Size(183, 102);
            this.txtQuestionEdit.TabIndex = 5;
            // 
            // txtAns1
            // 
            this.txtAns1.Location = new System.Drawing.Point(38, 175);
            this.txtAns1.Name = "txtAns1";
            this.txtAns1.Size = new System.Drawing.Size(163, 20);
            this.txtAns1.TabIndex = 6;
            // 
            // txtAns2
            // 
            this.txtAns2.Location = new System.Drawing.Point(38, 200);
            this.txtAns2.Name = "txtAns2";
            this.txtAns2.Size = new System.Drawing.Size(163, 20);
            this.txtAns2.TabIndex = 6;
            // 
            // txtAns3
            // 
            this.txtAns3.Location = new System.Drawing.Point(38, 227);
            this.txtAns3.Name = "txtAns3";
            this.txtAns3.Size = new System.Drawing.Size(163, 20);
            this.txtAns3.TabIndex = 6;
            // 
            // txtAns4
            // 
            this.txtAns4.Location = new System.Drawing.Point(38, 253);
            this.txtAns4.Name = "txtAns4";
            this.txtAns4.Size = new System.Drawing.Size(163, 20);
            this.txtAns4.TabIndex = 6;
            // 
            // rb1
            // 
            this.rb1.AutoSize = true;
            this.rb1.Location = new System.Drawing.Point(18, 178);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(14, 13);
            this.rb1.TabIndex = 0;
            this.rb1.TabStop = true;
            this.rb1.UseVisualStyleBackColor = true;
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(18, 204);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(14, 13);
            this.rb2.TabIndex = 0;
            this.rb2.TabStop = true;
            this.rb2.UseVisualStyleBackColor = true;
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Location = new System.Drawing.Point(18, 230);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(14, 13);
            this.rb3.TabIndex = 0;
            this.rb3.TabStop = true;
            this.rb3.UseVisualStyleBackColor = true;
            // 
            // rb4
            // 
            this.rb4.AutoSize = true;
            this.rb4.Location = new System.Drawing.Point(18, 256);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(14, 13);
            this.rb4.TabIndex = 0;
            this.rb4.TabStop = true;
            this.rb4.UseVisualStyleBackColor = true;
            // 
            // btnSaveEventChanges
            // 
            this.btnSaveEventChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveEventChanges.Location = new System.Drawing.Point(590, 352);
            this.btnSaveEventChanges.Name = "btnSaveEventChanges";
            this.btnSaveEventChanges.Size = new System.Drawing.Size(118, 36);
            this.btnSaveEventChanges.TabIndex = 8;
            this.btnSaveEventChanges.Text = "Сохранить";
            this.btnSaveEventChanges.UseVisualStyleBackColor = true;
            this.btnSaveEventChanges.Click += new System.EventHandler(this.btnSaveEventChanges_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Описание:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Темы:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Вопрос:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAns3);
            this.groupBox1.Controls.Add(this.txtQuestionEdit);
            this.groupBox1.Controls.Add(this.txtAns2);
            this.groupBox1.Controls.Add(this.rb4);
            this.groupBox1.Controls.Add(this.rb1);
            this.groupBox1.Controls.Add(this.txtAns4);
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Controls.Add(this.txtAns1);
            this.groupBox1.Location = new System.Drawing.Point(590, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 292);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Редактирование вопроса";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Название темы:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "События:";
            // 
            // btnDeleteTheme
            // 
            this.btnDeleteTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTheme.Location = new System.Drawing.Point(12, 235);
            this.btnDeleteTheme.Name = "btnDeleteTheme";
            this.btnDeleteTheme.Size = new System.Drawing.Size(168, 23);
            this.btnDeleteTheme.TabIndex = 2;
            this.btnDeleteTheme.Text = "Удалить тему";
            this.btnDeleteTheme.UseVisualStyleBackColor = true;
            this.btnDeleteTheme.Click += new System.EventHandler(this.btnDeleteTheme_Click);
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteEvent.Location = new System.Drawing.Point(12, 425);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(168, 23);
            this.btnDeleteEvent.TabIndex = 2;
            this.btnDeleteEvent.Text = "Удалить событие";
            this.btnDeleteEvent.UseVisualStyleBackColor = true;
            this.btnDeleteEvent.Click += new System.EventHandler(this.btnDeleteEvent_Click);
            // 
            // txtTitleEdit
            // 
            this.txtTitleEdit.Location = new System.Drawing.Point(9, 171);
            this.txtTitleEdit.Name = "txtTitleEdit";
            this.txtTitleEdit.Size = new System.Drawing.Size(337, 20);
            this.txtTitleEdit.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Имя события:";
            // 
            // grpEventEdit
            // 
            this.grpEventEdit.Controls.Add(this.pictureBoxEventImage);
            this.grpEventEdit.Controls.Add(this.label6);
            this.grpEventEdit.Controls.Add(this.txtDescEdit);
            this.grpEventEdit.Controls.Add(this.txtTitleEdit);
            this.grpEventEdit.Controls.Add(this.label1);
            this.grpEventEdit.Controls.Add(this.btnAddImageEvent);
            this.grpEventEdit.Enabled = false;
            this.grpEventEdit.Location = new System.Drawing.Point(200, 21);
            this.grpEventEdit.Name = "grpEventEdit";
            this.grpEventEdit.Size = new System.Drawing.Size(357, 427);
            this.grpEventEdit.TabIndex = 17;
            this.grpEventEdit.TabStop = false;
            this.grpEventEdit.Text = "Редактирование события";
            // 
            // pictureBoxEventImage
            // 
            this.pictureBoxEventImage.Location = new System.Drawing.Point(12, 25);
            this.pictureBoxEventImage.Name = "pictureBoxEventImage";
            this.pictureBoxEventImage.Size = new System.Drawing.Size(188, 115);
            this.pictureBoxEventImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEventImage.TabIndex = 17;
            this.pictureBoxEventImage.TabStop = false;
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEvent.Location = new System.Drawing.Point(12, 395);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(168, 23);
            this.btnAddEvent.TabIndex = 18;
            this.btnAddEvent.Text = "Добавить событие";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 485);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.grpEventEdit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSaveEventChanges);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDeleteEvent);
            this.Controls.Add(this.btnDeleteTheme);
            this.Controls.Add(this.btnAddTheme);
            this.Controls.Add(this.txtNewThemeName);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.lstThemes);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpEventEdit.ResumeLayout(false);
            this.grpEventEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEventImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstThemes;
        private System.Windows.Forms.ListBox lstEvents;
        private System.Windows.Forms.TextBox txtNewThemeName;
        private System.Windows.Forms.Button btnAddTheme;
        private System.Windows.Forms.Button btnAddImageEvent;
        private System.Windows.Forms.TextBox txtDescEdit;
        private System.Windows.Forms.TextBox txtQuestionEdit;
        private System.Windows.Forms.TextBox txtAns1;
        private System.Windows.Forms.TextBox txtAns2;
        private System.Windows.Forms.TextBox txtAns3;
        private System.Windows.Forms.TextBox txtAns4;
        private System.Windows.Forms.RadioButton rb4;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.RadioButton rb1;
        private System.Windows.Forms.Button btnSaveEventChanges;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDeleteTheme;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.TextBox txtTitleEdit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpEventEdit;
        private System.Windows.Forms.PictureBox pictureBoxEventImage;
        private System.Windows.Forms.Button btnAddEvent;
    }
}