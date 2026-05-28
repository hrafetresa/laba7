namespace laba7
{
    partial class SettingsForm
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
            this.cmbThemeStyle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackSpeed = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbThemeStyle
            // 
            this.cmbThemeStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThemeStyle.FormattingEnabled = true;
            this.cmbThemeStyle.Items.AddRange(new object[] {
            "Светлая",
            "Тёмная"});
            this.cmbThemeStyle.Location = new System.Drawing.Point(114, 20);
            this.cmbThemeStyle.Name = "cmbThemeStyle";
            this.cmbThemeStyle.Size = new System.Drawing.Size(121, 21);
            this.cmbThemeStyle.TabIndex = 0;
            this.cmbThemeStyle.SelectedIndexChanged += new System.EventHandler(this.cmbThemeStyle_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Скорость слайд-шоу:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Цветовая схема:";
            // 
            // trackSpeed
            // 
            this.trackSpeed.Location = new System.Drawing.Point(18, 79);
            this.trackSpeed.Maximum = 5;
            this.trackSpeed.Minimum = 1;
            this.trackSpeed.Name = "trackSpeed";
            this.trackSpeed.Size = new System.Drawing.Size(217, 45);
            this.trackSpeed.TabIndex = 5;
            this.trackSpeed.Value = 3;
            this.trackSpeed.ValueChanged += new System.EventHandler(this.trackSpeed_ValueChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 131);
            this.Controls.Add(this.trackSpeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbThemeStyle);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbThemeStyle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackSpeed;
    }
}