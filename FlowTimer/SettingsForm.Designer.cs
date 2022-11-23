namespace FlowTimer {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.LabelBeep = new System.Windows.Forms.Label();
            this.ComboBoxBeep = new System.Windows.Forms.ComboBox();
            this.ButtonImportBeep = new System.Windows.Forms.Button();
            this.TrackBarVolume = new System.Windows.Forms.TrackBar();
            this.TextBoxVolume = new System.Windows.Forms.TextBox();
            this.LabelVolume = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.UpDownBeepCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.InputFPS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.InputTimeBetweenBeeps = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.InputCalibrationTimer = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.InputMinStartTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.InputBeepTimerFrequency = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.InputDatabaseFile = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarVolume)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownBeepCount)).BeginInit();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel8.SuspendLayout();
            this.flowLayoutPanel9.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelBeep
            // 
            this.LabelBeep.AutoSize = true;
            this.LabelBeep.Location = new System.Drawing.Point(3, 0);
            this.LabelBeep.Name = "LabelBeep";
            this.LabelBeep.Size = new System.Drawing.Size(35, 13);
            this.LabelBeep.TabIndex = 20;
            this.LabelBeep.Text = "Beep:";
            // 
            // ComboBoxBeep
            // 
            this.ComboBoxBeep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxBeep.FormattingEnabled = true;
            this.ComboBoxBeep.Location = new System.Drawing.Point(3, 3);
            this.ComboBoxBeep.Name = "ComboBoxBeep";
            this.ComboBoxBeep.Size = new System.Drawing.Size(120, 21);
            this.ComboBoxBeep.TabIndex = 22;
            // 
            // ButtonImportBeep
            // 
            this.ButtonImportBeep.Location = new System.Drawing.Point(129, 3);
            this.ButtonImportBeep.Name = "ButtonImportBeep";
            this.ButtonImportBeep.Size = new System.Drawing.Size(114, 23);
            this.ButtonImportBeep.TabIndex = 23;
            this.ButtonImportBeep.Text = "Import Beep";
            this.ButtonImportBeep.UseVisualStyleBackColor = true;
            this.ButtonImportBeep.Click += new System.EventHandler(this.ButtonImportBeep_Click);
            // 
            // TrackBarVolume
            // 
            this.TrackBarVolume.AutoSize = false;
            this.TrackBarVolume.Location = new System.Drawing.Point(3, 3);
            this.TrackBarVolume.Maximum = 100;
            this.TrackBarVolume.Name = "TrackBarVolume";
            this.TrackBarVolume.Size = new System.Drawing.Size(165, 21);
            this.TrackBarVolume.TabIndex = 28;
            this.TrackBarVolume.TickFrequency = 0;
            this.TrackBarVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrackBarVolume.Value = 100;
            // 
            // TextBoxVolume
            // 
            this.TextBoxVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.7F);
            this.TextBoxVolume.Location = new System.Drawing.Point(174, 3);
            this.TextBoxVolume.Name = "TextBoxVolume";
            this.TextBoxVolume.Size = new System.Drawing.Size(73, 21);
            this.TextBoxVolume.TabIndex = 29;
            // 
            // LabelVolume
            // 
            this.LabelVolume.AutoSize = true;
            this.LabelVolume.Location = new System.Drawing.Point(3, 68);
            this.LabelVolume.Name = "LabelVolume";
            this.LabelVolume.Size = new System.Drawing.Size(45, 13);
            this.LabelVolume.TabIndex = 30;
            this.LabelVolume.Text = "Volume:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelBeep, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LabelVolume, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel6, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel8, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel9, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel7, 1, 8);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(515, 463);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Calib. timer (ms)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Beeps:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.ComboBoxBeep);
            this.flowLayoutPanel1.Controls.Add(this.ButtonImportBeep);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(153, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(359, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel3.Controls.Add(this.UpDownBeepCount);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(153, 37);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(359, 28);
            this.flowLayoutPanel3.TabIndex = 31;
            // 
            // UpDownBeepCount
            // 
            this.UpDownBeepCount.Location = new System.Drawing.Point(3, 3);
            this.UpDownBeepCount.Name = "UpDownBeepCount";
            this.UpDownBeepCount.Size = new System.Drawing.Size(120, 20);
            this.UpDownBeepCount.TabIndex = 0;
            this.UpDownBeepCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.UpDownBeepCount.ValueChanged += new System.EventHandler(this.UpDownBeepCount_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "FPS:";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel4.Controls.Add(this.InputFPS);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(153, 105);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(359, 28);
            this.flowLayoutPanel4.TabIndex = 35;
            // 
            // InputFPS
            // 
            this.InputFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.7F);
            this.InputFPS.Location = new System.Drawing.Point(3, 3);
            this.InputFPS.Name = "InputFPS";
            this.InputFPS.Size = new System.Drawing.Size(120, 21);
            this.InputFPS.TabIndex = 34;
            this.InputFPS.Text = "59.82";
            this.InputFPS.TextChanged += new System.EventHandler(this.InputFPS_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Time btwn beeps (ms)";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel5.Controls.Add(this.InputTimeBetweenBeeps);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(153, 139);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(359, 28);
            this.flowLayoutPanel5.TabIndex = 37;
            // 
            // InputTimeBetweenBeeps
            // 
            this.InputTimeBetweenBeeps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.7F);
            this.InputTimeBetweenBeeps.Location = new System.Drawing.Point(3, 3);
            this.InputTimeBetweenBeeps.Name = "InputTimeBetweenBeeps";
            this.InputTimeBetweenBeeps.Size = new System.Drawing.Size(120, 21);
            this.InputTimeBetweenBeeps.TabIndex = 35;
            this.InputTimeBetweenBeeps.Text = "500";
            this.InputTimeBetweenBeeps.TextChanged += new System.EventHandler(this.InputTimeBetweenBeeps_TextChanged);
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel6.Controls.Add(this.InputCalibrationTimer);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(153, 173);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(359, 28);
            this.flowLayoutPanel6.TabIndex = 41;
            // 
            // InputCalibrationTimer
            // 
            this.InputCalibrationTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.7F);
            this.InputCalibrationTimer.Location = new System.Drawing.Point(3, 3);
            this.InputCalibrationTimer.Name = "InputCalibrationTimer";
            this.InputCalibrationTimer.Size = new System.Drawing.Size(120, 21);
            this.InputCalibrationTimer.TabIndex = 35;
            this.InputCalibrationTimer.Text = "4000";
            this.InputCalibrationTimer.TextChanged += new System.EventHandler(this.InputCalibrationTimer_TextChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.TrackBarVolume);
            this.flowLayoutPanel2.Controls.Add(this.TextBoxVolume);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(153, 71);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(359, 28);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Min start time (ms)";
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel8.Controls.Add(this.InputMinStartTime);
            this.flowLayoutPanel8.Location = new System.Drawing.Point(153, 207);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(359, 28);
            this.flowLayoutPanel8.TabIndex = 44;
            // 
            // InputMinStartTime
            // 
            this.InputMinStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.7F);
            this.InputMinStartTime.Location = new System.Drawing.Point(3, 3);
            this.InputMinStartTime.Name = "InputMinStartTime";
            this.InputMinStartTime.Size = new System.Drawing.Size(120, 21);
            this.InputMinStartTime.TabIndex = 35;
            this.InputMinStartTime.Text = "4000";
            this.InputMinStartTime.TextChanged += new System.EventHandler(this.InputMinStartTime_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Beep timer frequency (ms)";
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel9.Controls.Add(this.InputBeepTimerFrequency);
            this.flowLayoutPanel9.Location = new System.Drawing.Point(153, 241);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Size = new System.Drawing.Size(359, 28);
            this.flowLayoutPanel9.TabIndex = 46;
            // 
            // InputBeepTimerFrequency
            // 
            this.InputBeepTimerFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.7F);
            this.InputBeepTimerFrequency.Location = new System.Drawing.Point(3, 3);
            this.InputBeepTimerFrequency.Name = "InputBeepTimerFrequency";
            this.InputBeepTimerFrequency.Size = new System.Drawing.Size(120, 21);
            this.InputBeepTimerFrequency.TabIndex = 35;
            this.InputBeepTimerFrequency.Text = "15";
            this.InputBeepTimerFrequency.TextChanged += new System.EventHandler(this.InputBeepTimerFrequency_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Database File";
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel7.Controls.Add(this.InputDatabaseFile);
            this.flowLayoutPanel7.Location = new System.Drawing.Point(153, 275);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(359, 28);
            this.flowLayoutPanel7.TabIndex = 48;
            // 
            // InputDatabaseFile
            // 
            this.InputDatabaseFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputDatabaseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.7F);
            this.InputDatabaseFile.Location = new System.Drawing.Point(3, 3);
            this.InputDatabaseFile.Name = "InputDatabaseFile";
            this.InputDatabaseFile.Size = new System.Drawing.Size(356, 21);
            this.InputDatabaseFile.TabIndex = 35;
            this.InputDatabaseFile.Text = "C:\\Users\\pokef\\PyCharmProjects\\chocoduck-builder\\choco.db";
            this.InputDatabaseFile.TextChanged += new System.EventHandler(this.InputDatabaseFile_TextChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarVolume)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UpDownBeepCount)).EndInit();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel8.ResumeLayout(false);
            this.flowLayoutPanel8.PerformLayout();
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel9.PerformLayout();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ComboBox ComboBoxBeep;
        public System.Windows.Forms.Label LabelBeep;
        public System.Windows.Forms.Button ButtonImportBeep;
        public System.Windows.Forms.Label LabelVolume;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        public System.Windows.Forms.TextBox InputFPS;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        public System.Windows.Forms.TextBox InputTimeBetweenBeeps;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        public System.Windows.Forms.TextBox InputCalibrationTimer;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        public System.Windows.Forms.TextBox InputMinStartTime;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        public System.Windows.Forms.TextBox InputBeepTimerFrequency;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        public System.Windows.Forms.TextBox InputDatabaseFile;
        public System.Windows.Forms.NumericUpDown UpDownBeepCount;
        public System.Windows.Forms.TrackBar TrackBarVolume;
        public System.Windows.Forms.TextBox TextBoxVolume;
    }
}