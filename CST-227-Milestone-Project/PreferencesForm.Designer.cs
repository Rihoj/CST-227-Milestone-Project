namespace CST_227_Milestone_Project
{
    partial class PreferencesForm
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
            this.SizeFormHeader = new System.Windows.Forms.Label();
            this.BoardSizeButton = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SmallRadioButton = new System.Windows.Forms.RadioButton();
            this.XsmallRadioButton = new System.Windows.Forms.RadioButton();
            this.MedRadioButton = new System.Windows.Forms.RadioButton();
            this.LargeRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.easyRadioButton = new System.Windows.Forms.RadioButton();
            this.InsaneRadioButton = new System.Windows.Forms.RadioButton();
            this.NormalRadioButton = new System.Windows.Forms.RadioButton();
            this.HardRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SizeFormHeader
            // 
            this.SizeFormHeader.AutoSize = true;
            this.SizeFormHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SizeFormHeader.Location = new System.Drawing.Point(12, 9);
            this.SizeFormHeader.Name = "SizeFormHeader";
            this.SizeFormHeader.Size = new System.Drawing.Size(162, 29);
            this.SizeFormHeader.TabIndex = 1;
            this.SizeFormHeader.Text = "Preferences:";
            // 
            // BoardSizeButton
            // 
            this.BoardSizeButton.Location = new System.Drawing.Point(17, 199);
            this.BoardSizeButton.Name = "BoardSizeButton";
            this.BoardSizeButton.Size = new System.Drawing.Size(89, 23);
            this.BoardSizeButton.TabIndex = 4;
            this.BoardSizeButton.Text = "Change Board";
            this.BoardSizeButton.UseVisualStyleBackColor = true;
            this.BoardSizeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(361, 206);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(89, 23);
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // SmallRadioButton
            // 
            this.SmallRadioButton.AutoSize = true;
            this.SmallRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmallRadioButton.Location = new System.Drawing.Point(6, 49);
            this.SmallRadioButton.Name = "SmallRadioButton";
            this.SmallRadioButton.Size = new System.Drawing.Size(66, 24);
            this.SmallRadioButton.TabIndex = 2;
            this.SmallRadioButton.TabStop = true;
            this.SmallRadioButton.Text = "Small";
            this.SmallRadioButton.UseVisualStyleBackColor = true;
            this.SmallRadioButton.CheckedChanged += new System.EventHandler(this.SmallRadioButton_CheckedChanged);
            // 
            // XsmallRadioButton
            // 
            this.XsmallRadioButton.AutoSize = true;
            this.XsmallRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XsmallRadioButton.Location = new System.Drawing.Point(6, 19);
            this.XsmallRadioButton.Name = "XsmallRadioButton";
            this.XsmallRadioButton.Size = new System.Drawing.Size(107, 24);
            this.XsmallRadioButton.TabIndex = 0;
            this.XsmallRadioButton.TabStop = true;
            this.XsmallRadioButton.Text = "Extra Small";
            this.XsmallRadioButton.UseVisualStyleBackColor = true;
            this.XsmallRadioButton.CheckedChanged += new System.EventHandler(this.XsmallRadioButton_CheckedChanged);
            // 
            // MedRadioButton
            // 
            this.MedRadioButton.AutoSize = true;
            this.MedRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MedRadioButton.Location = new System.Drawing.Point(6, 79);
            this.MedRadioButton.Name = "MedRadioButton";
            this.MedRadioButton.Size = new System.Drawing.Size(83, 24);
            this.MedRadioButton.TabIndex = 3;
            this.MedRadioButton.TabStop = true;
            this.MedRadioButton.Text = "Medium";
            this.MedRadioButton.UseVisualStyleBackColor = true;
            this.MedRadioButton.CheckedChanged += new System.EventHandler(this.MedRadioButton_CheckedChanged);
            // 
            // LargeRadioButton
            // 
            this.LargeRadioButton.AutoSize = true;
            this.LargeRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LargeRadioButton.Location = new System.Drawing.Point(6, 109);
            this.LargeRadioButton.Name = "LargeRadioButton";
            this.LargeRadioButton.Size = new System.Drawing.Size(68, 24);
            this.LargeRadioButton.TabIndex = 4;
            this.LargeRadioButton.TabStop = true;
            this.LargeRadioButton.Text = "Large";
            this.LargeRadioButton.UseVisualStyleBackColor = true;
            this.LargeRadioButton.CheckedChanged += new System.EventHandler(this.LargeRadioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.XsmallRadioButton);
            this.groupBox1.Controls.Add(this.LargeRadioButton);
            this.groupBox1.Controls.Add(this.SmallRadioButton);
            this.groupBox1.Controls.Add(this.MedRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(17, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 143);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Board Size";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.easyRadioButton);
            this.groupBox2.Controls.Add(this.InsaneRadioButton);
            this.groupBox2.Controls.Add(this.NormalRadioButton);
            this.groupBox2.Controls.Add(this.HardRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(250, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 143);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Difficulty";
            // 
            // easyRadioButton
            // 
            this.easyRadioButton.AutoSize = true;
            this.easyRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyRadioButton.Location = new System.Drawing.Point(6, 19);
            this.easyRadioButton.Name = "easyRadioButton";
            this.easyRadioButton.Size = new System.Drawing.Size(62, 24);
            this.easyRadioButton.TabIndex = 0;
            this.easyRadioButton.TabStop = true;
            this.easyRadioButton.Text = "Easy";
            this.easyRadioButton.UseVisualStyleBackColor = true;
            this.easyRadioButton.CheckedChanged += new System.EventHandler(this.easyRadioButton_CheckedChanged);
            // 
            // InsaneRadioButton
            // 
            this.InsaneRadioButton.AutoSize = true;
            this.InsaneRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsaneRadioButton.Location = new System.Drawing.Point(6, 109);
            this.InsaneRadioButton.Name = "InsaneRadioButton";
            this.InsaneRadioButton.Size = new System.Drawing.Size(76, 24);
            this.InsaneRadioButton.TabIndex = 4;
            this.InsaneRadioButton.TabStop = true;
            this.InsaneRadioButton.Text = "Insane";
            this.InsaneRadioButton.UseVisualStyleBackColor = true;
            this.InsaneRadioButton.CheckedChanged += new System.EventHandler(this.InsaneRadioButton_CheckedChanged);
            // 
            // NormalRadioButton
            // 
            this.NormalRadioButton.AutoSize = true;
            this.NormalRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NormalRadioButton.Location = new System.Drawing.Point(6, 49);
            this.NormalRadioButton.Name = "NormalRadioButton";
            this.NormalRadioButton.Size = new System.Drawing.Size(77, 24);
            this.NormalRadioButton.TabIndex = 2;
            this.NormalRadioButton.TabStop = true;
            this.NormalRadioButton.Text = "Normal";
            this.NormalRadioButton.UseVisualStyleBackColor = true;
            this.NormalRadioButton.CheckedChanged += new System.EventHandler(this.NormalRadioButton_CheckedChanged);
            // 
            // HardRadioButton
            // 
            this.HardRadioButton.AutoSize = true;
            this.HardRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HardRadioButton.Location = new System.Drawing.Point(6, 79);
            this.HardRadioButton.Name = "HardRadioButton";
            this.HardRadioButton.Size = new System.Drawing.Size(62, 24);
            this.HardRadioButton.TabIndex = 3;
            this.HardRadioButton.TabStop = true;
            this.HardRadioButton.Text = "Hard";
            this.HardRadioButton.UseVisualStyleBackColor = true;
            this.HardRadioButton.CheckedChanged += new System.EventHandler(this.HardRadioButton_CheckedChanged);
            // 
            // PreferencesForm
            // 
            this.AcceptButton = this.BoardSizeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(484, 241);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.BoardSizeButton);
            this.Controls.Add(this.SizeFormHeader);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 280);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 280);
            this.Name = "PreferencesForm";
            this.Text = "Preferences";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label SizeFormHeader;
        private System.Windows.Forms.Button BoardSizeButton;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.RadioButton SmallRadioButton;
        private System.Windows.Forms.RadioButton XsmallRadioButton;
        private System.Windows.Forms.RadioButton MedRadioButton;
        private System.Windows.Forms.RadioButton LargeRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton easyRadioButton;
        private System.Windows.Forms.RadioButton InsaneRadioButton;
        private System.Windows.Forms.RadioButton NormalRadioButton;
        private System.Windows.Forms.RadioButton HardRadioButton;
    }
}