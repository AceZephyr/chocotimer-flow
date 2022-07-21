﻿namespace FlowTimer {
    partial class MainForm {
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
            this.LabelTimer = new System.Windows.Forms.Label();
            this.PictureBoxPin = new System.Windows.Forms.PictureBox();
            this.ButtonLoadStartTimer = new System.Windows.Forms.Button();
            this.ButtonStopTimer = new System.Windows.Forms.Button();
            this.ButtonSettings = new System.Windows.Forms.Button();
            this.ButtonCalibrate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InputMinWinSize = new System.Windows.Forms.NumericUpDown();
            this.GroupBoxRank = new System.Windows.Forms.GroupBox();
            this.RadioS = new System.Windows.Forms.RadioButton();
            this.RadioA = new System.Windows.Forms.RadioButton();
            this.RadioB = new System.Windows.Forms.RadioButton();
            this.RadioC = new System.Windows.Forms.RadioButton();
            this.ChecklistItems = new System.Windows.Forms.CheckedListBox();
            this.GroupBoxItems = new System.Windows.Forms.GroupBox();
            this.ComboItems3 = new System.Windows.Forms.ComboBox();
            this.ComboItems2 = new System.Windows.Forms.ComboBox();
            this.ComboItems1 = new System.Windows.Forms.ComboBox();
            this.GroupBoxNames = new System.Windows.Forms.GroupBox();
            this.ComboNames6 = new System.Windows.Forms.ComboBox();
            this.ComboNames5 = new System.Windows.Forms.ComboBox();
            this.ComboNames4 = new System.Windows.Forms.ComboBox();
            this.ComboNames3 = new System.Windows.Forms.ComboBox();
            this.ComboNames2 = new System.Windows.Forms.ComboBox();
            this.PanelFrameOutput = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonPowerOn = new System.Windows.Forms.Button();
            this.ButtonCalculateFrame = new System.Windows.Forms.Button();
            this.ButtonClearInput = new System.Windows.Forms.Button();
            this.InputFrame = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonCalibrateToFrame = new System.Windows.Forms.Button();
            this.ButtonDisplayFrameData = new System.Windows.Forms.Button();
            this.ButtonClearFrameData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputMinWinSize)).BeginInit();
            this.GroupBoxRank.SuspendLayout();
            this.GroupBoxItems.SuspendLayout();
            this.GroupBoxNames.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelTimer
            // 
            this.LabelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTimer.Location = new System.Drawing.Point(23, 9);
            this.LabelTimer.Name = "LabelTimer";
            this.LabelTimer.Size = new System.Drawing.Size(303, 42);
            this.LabelTimer.TabIndex = 35;
            this.LabelTimer.Text = "0.000";
            // 
            // PictureBoxPin
            // 
            this.PictureBoxPin.Location = new System.Drawing.Point(332, 9);
            this.PictureBoxPin.Name = "PictureBoxPin";
            this.PictureBoxPin.Size = new System.Drawing.Size(16, 16);
            this.PictureBoxPin.TabIndex = 39;
            this.PictureBoxPin.TabStop = false;
            this.PictureBoxPin.Click += new System.EventHandler(this.PictureBoxPin_Click);
            // 
            // ButtonLoadStartTimer
            // 
            this.ButtonLoadStartTimer.Location = new System.Drawing.Point(19, 116);
            this.ButtonLoadStartTimer.Name = "ButtonLoadStartTimer";
            this.ButtonLoadStartTimer.Size = new System.Drawing.Size(121, 25);
            this.ButtonLoadStartTimer.TabIndex = 36;
            this.ButtonLoadStartTimer.TabStop = false;
            this.ButtonLoadStartTimer.Text = "Load + Start Timer";
            this.ButtonLoadStartTimer.UseVisualStyleBackColor = true;
            this.ButtonLoadStartTimer.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // ButtonStopTimer
            // 
            this.ButtonStopTimer.Location = new System.Drawing.Point(19, 147);
            this.ButtonStopTimer.Name = "ButtonStopTimer";
            this.ButtonStopTimer.Size = new System.Drawing.Size(121, 25);
            this.ButtonStopTimer.TabIndex = 37;
            this.ButtonStopTimer.TabStop = false;
            this.ButtonStopTimer.Text = "Stop Timer";
            this.ButtonStopTimer.UseVisualStyleBackColor = true;
            this.ButtonStopTimer.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // ButtonSettings
            // 
            this.ButtonSettings.Location = new System.Drawing.Point(19, 178);
            this.ButtonSettings.Name = "ButtonSettings";
            this.ButtonSettings.Size = new System.Drawing.Size(121, 25);
            this.ButtonSettings.TabIndex = 38;
            this.ButtonSettings.TabStop = false;
            this.ButtonSettings.Text = "Settings";
            this.ButtonSettings.UseVisualStyleBackColor = true;
            this.ButtonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // ButtonCalibrate
            // 
            this.ButtonCalibrate.Location = new System.Drawing.Point(19, 85);
            this.ButtonCalibrate.Name = "ButtonCalibrate";
            this.ButtonCalibrate.Size = new System.Drawing.Size(121, 25);
            this.ButtonCalibrate.TabIndex = 41;
            this.ButtonCalibrate.TabStop = false;
            this.ButtonCalibrate.Text = "Calibrate";
            this.ButtonCalibrate.UseVisualStyleBackColor = true;
            this.ButtonCalibrate.Click += new System.EventHandler(this.ButtonCalibrate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Minimum Window Size:";
            // 
            // InputMinWinSize
            // 
            this.InputMinWinSize.Location = new System.Drawing.Point(19, 227);
            this.InputMinWinSize.Name = "InputMinWinSize";
            this.InputMinWinSize.Size = new System.Drawing.Size(120, 20);
            this.InputMinWinSize.TabIndex = 43;
            this.InputMinWinSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.InputMinWinSize.ValueChanged += new System.EventHandler(this.InputMinWinSize_ValueChanged);
            // 
            // GroupBoxRank
            // 
            this.GroupBoxRank.Controls.Add(this.RadioS);
            this.GroupBoxRank.Controls.Add(this.RadioA);
            this.GroupBoxRank.Controls.Add(this.RadioB);
            this.GroupBoxRank.Controls.Add(this.RadioC);
            this.GroupBoxRank.Location = new System.Drawing.Point(19, 253);
            this.GroupBoxRank.Name = "GroupBoxRank";
            this.GroupBoxRank.Size = new System.Drawing.Size(121, 114);
            this.GroupBoxRank.TabIndex = 44;
            this.GroupBoxRank.TabStop = false;
            this.GroupBoxRank.Text = "Rank";
            // 
            // RadioS
            // 
            this.RadioS.AutoSize = true;
            this.RadioS.Location = new System.Drawing.Point(7, 89);
            this.RadioS.Name = "RadioS";
            this.RadioS.Size = new System.Drawing.Size(32, 17);
            this.RadioS.TabIndex = 3;
            this.RadioS.TabStop = true;
            this.RadioS.Text = "S";
            this.RadioS.UseVisualStyleBackColor = true;
            // 
            // RadioA
            // 
            this.RadioA.AutoSize = true;
            this.RadioA.Location = new System.Drawing.Point(7, 66);
            this.RadioA.Name = "RadioA";
            this.RadioA.Size = new System.Drawing.Size(32, 17);
            this.RadioA.TabIndex = 2;
            this.RadioA.TabStop = true;
            this.RadioA.Text = "A";
            this.RadioA.UseVisualStyleBackColor = true;
            // 
            // RadioB
            // 
            this.RadioB.AutoSize = true;
            this.RadioB.Location = new System.Drawing.Point(7, 43);
            this.RadioB.Name = "RadioB";
            this.RadioB.Size = new System.Drawing.Size(32, 17);
            this.RadioB.TabIndex = 1;
            this.RadioB.TabStop = true;
            this.RadioB.Text = "B";
            this.RadioB.UseVisualStyleBackColor = true;
            // 
            // RadioC
            // 
            this.RadioC.AutoSize = true;
            this.RadioC.Location = new System.Drawing.Point(7, 20);
            this.RadioC.Name = "RadioC";
            this.RadioC.Size = new System.Drawing.Size(32, 17);
            this.RadioC.TabIndex = 0;
            this.RadioC.TabStop = true;
            this.RadioC.Text = "C";
            this.RadioC.UseVisualStyleBackColor = true;
            // 
            // ChecklistItems
            // 
            this.ChecklistItems.FormattingEnabled = true;
            this.ChecklistItems.Items.AddRange(new object[] {
            "Sneak Attack",
            "Enemy Away"});
            this.ChecklistItems.Location = new System.Drawing.Point(19, 374);
            this.ChecklistItems.Name = "ChecklistItems";
            this.ChecklistItems.Size = new System.Drawing.Size(121, 94);
            this.ChecklistItems.TabIndex = 45;
            // 
            // GroupBoxItems
            // 
            this.GroupBoxItems.Controls.Add(this.ComboItems3);
            this.GroupBoxItems.Controls.Add(this.ComboItems2);
            this.GroupBoxItems.Controls.Add(this.ComboItems1);
            this.GroupBoxItems.Location = new System.Drawing.Point(147, 55);
            this.GroupBoxItems.Name = "GroupBoxItems";
            this.GroupBoxItems.Size = new System.Drawing.Size(200, 100);
            this.GroupBoxItems.TabIndex = 46;
            this.GroupBoxItems.TabStop = false;
            this.GroupBoxItems.Text = "Items";
            // 
            // ComboItems3
            // 
            this.ComboItems3.FormattingEnabled = true;
            this.ComboItems3.Location = new System.Drawing.Point(6, 72);
            this.ComboItems3.Name = "ComboItems3";
            this.ComboItems3.Size = new System.Drawing.Size(187, 21);
            this.ComboItems3.TabIndex = 2;
            // 
            // ComboItems2
            // 
            this.ComboItems2.FormattingEnabled = true;
            this.ComboItems2.Location = new System.Drawing.Point(6, 46);
            this.ComboItems2.Name = "ComboItems2";
            this.ComboItems2.Size = new System.Drawing.Size(187, 21);
            this.ComboItems2.TabIndex = 1;
            // 
            // ComboItems1
            // 
            this.ComboItems1.FormattingEnabled = true;
            this.ComboItems1.Location = new System.Drawing.Point(6, 20);
            this.ComboItems1.Name = "ComboItems1";
            this.ComboItems1.Size = new System.Drawing.Size(187, 21);
            this.ComboItems1.TabIndex = 0;
            // 
            // GroupBoxNames
            // 
            this.GroupBoxNames.Controls.Add(this.ComboNames6);
            this.GroupBoxNames.Controls.Add(this.ComboNames5);
            this.GroupBoxNames.Controls.Add(this.ComboNames4);
            this.GroupBoxNames.Controls.Add(this.ComboNames3);
            this.GroupBoxNames.Controls.Add(this.ComboNames2);
            this.GroupBoxNames.Location = new System.Drawing.Point(147, 154);
            this.GroupBoxNames.Name = "GroupBoxNames";
            this.GroupBoxNames.Size = new System.Drawing.Size(200, 150);
            this.GroupBoxNames.TabIndex = 47;
            this.GroupBoxNames.TabStop = false;
            this.GroupBoxNames.Text = "Names";
            // 
            // ComboNames6
            // 
            this.ComboNames6.FormattingEnabled = true;
            this.ComboNames6.Location = new System.Drawing.Point(6, 124);
            this.ComboNames6.Name = "ComboNames6";
            this.ComboNames6.Size = new System.Drawing.Size(187, 21);
            this.ComboNames6.TabIndex = 7;
            // 
            // ComboNames5
            // 
            this.ComboNames5.FormattingEnabled = true;
            this.ComboNames5.Location = new System.Drawing.Point(6, 98);
            this.ComboNames5.Name = "ComboNames5";
            this.ComboNames5.Size = new System.Drawing.Size(187, 21);
            this.ComboNames5.TabIndex = 6;
            // 
            // ComboNames4
            // 
            this.ComboNames4.FormattingEnabled = true;
            this.ComboNames4.Location = new System.Drawing.Point(6, 72);
            this.ComboNames4.Name = "ComboNames4";
            this.ComboNames4.Size = new System.Drawing.Size(187, 21);
            this.ComboNames4.TabIndex = 5;
            // 
            // ComboNames3
            // 
            this.ComboNames3.FormattingEnabled = true;
            this.ComboNames3.Location = new System.Drawing.Point(6, 46);
            this.ComboNames3.Name = "ComboNames3";
            this.ComboNames3.Size = new System.Drawing.Size(187, 21);
            this.ComboNames3.TabIndex = 4;
            // 
            // ComboNames2
            // 
            this.ComboNames2.FormattingEnabled = true;
            this.ComboNames2.Location = new System.Drawing.Point(6, 20);
            this.ComboNames2.Name = "ComboNames2";
            this.ComboNames2.Size = new System.Drawing.Size(187, 21);
            this.ComboNames2.TabIndex = 3;
            // 
            // PanelFrameOutput
            // 
            this.PanelFrameOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelFrameOutput.Location = new System.Drawing.Point(354, 9);
            this.PanelFrameOutput.Name = "PanelFrameOutput";
            this.PanelFrameOutput.Size = new System.Drawing.Size(1218, 840);
            this.PanelFrameOutput.TabIndex = 48;
            // 
            // ButtonPowerOn
            // 
            this.ButtonPowerOn.Location = new System.Drawing.Point(19, 54);
            this.ButtonPowerOn.Name = "ButtonPowerOn";
            this.ButtonPowerOn.Size = new System.Drawing.Size(121, 25);
            this.ButtonPowerOn.TabIndex = 40;
            this.ButtonPowerOn.TabStop = false;
            this.ButtonPowerOn.Text = "Power On";
            this.ButtonPowerOn.UseVisualStyleBackColor = true;
            this.ButtonPowerOn.Click += new System.EventHandler(this.ButtonPowerOn_Click);
            // 
            // ButtonCalculateFrame
            // 
            this.ButtonCalculateFrame.Location = new System.Drawing.Point(147, 305);
            this.ButtonCalculateFrame.Name = "ButtonCalculateFrame";
            this.ButtonCalculateFrame.Size = new System.Drawing.Size(98, 25);
            this.ButtonCalculateFrame.TabIndex = 8;
            this.ButtonCalculateFrame.Text = "Calculate Frame";
            this.ButtonCalculateFrame.UseVisualStyleBackColor = true;
            // 
            // ButtonClearInput
            // 
            this.ButtonClearInput.Location = new System.Drawing.Point(249, 305);
            this.ButtonClearInput.Name = "ButtonClearInput";
            this.ButtonClearInput.Size = new System.Drawing.Size(98, 25);
            this.ButtonClearInput.TabIndex = 9;
            this.ButtonClearInput.Text = "Clear Input";
            this.ButtonClearInput.UseVisualStyleBackColor = true;
            // 
            // InputFrame
            // 
            this.InputFrame.Location = new System.Drawing.Point(189, 334);
            this.InputFrame.Name = "InputFrame";
            this.InputFrame.Size = new System.Drawing.Size(158, 20);
            this.InputFrame.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Frame";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonCalibrateToFrame
            // 
            this.ButtonCalibrateToFrame.Location = new System.Drawing.Point(147, 360);
            this.ButtonCalibrateToFrame.Name = "ButtonCalibrateToFrame";
            this.ButtonCalibrateToFrame.Size = new System.Drawing.Size(200, 25);
            this.ButtonCalibrateToFrame.TabIndex = 11;
            this.ButtonCalibrateToFrame.Text = "Calibrate To Frame";
            this.ButtonCalibrateToFrame.UseVisualStyleBackColor = true;
            // 
            // ButtonDisplayFrameData
            // 
            this.ButtonDisplayFrameData.Location = new System.Drawing.Point(147, 391);
            this.ButtonDisplayFrameData.Name = "ButtonDisplayFrameData";
            this.ButtonDisplayFrameData.Size = new System.Drawing.Size(200, 25);
            this.ButtonDisplayFrameData.TabIndex = 12;
            this.ButtonDisplayFrameData.Text = "Display Frame Data";
            this.ButtonDisplayFrameData.UseVisualStyleBackColor = true;
            // 
            // ButtonClearFrameData
            // 
            this.ButtonClearFrameData.Location = new System.Drawing.Point(147, 422);
            this.ButtonClearFrameData.Name = "ButtonClearFrameData";
            this.ButtonClearFrameData.Size = new System.Drawing.Size(200, 25);
            this.ButtonClearFrameData.TabIndex = 13;
            this.ButtonClearFrameData.Text = "Clear Frame Data";
            this.ButtonClearFrameData.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.ButtonClearFrameData);
            this.Controls.Add(this.ButtonDisplayFrameData);
            this.Controls.Add(this.ButtonCalibrateToFrame);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InputFrame);
            this.Controls.Add(this.ButtonClearInput);
            this.Controls.Add(this.ButtonCalculateFrame);
            this.Controls.Add(this.PanelFrameOutput);
            this.Controls.Add(this.GroupBoxNames);
            this.Controls.Add(this.GroupBoxItems);
            this.Controls.Add(this.ChecklistItems);
            this.Controls.Add(this.GroupBoxRank);
            this.Controls.Add(this.InputMinWinSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonCalibrate);
            this.Controls.Add(this.ButtonPowerOn);
            this.Controls.Add(this.LabelTimer);
            this.Controls.Add(this.PictureBoxPin);
            this.Controls.Add(this.ButtonLoadStartTimer);
            this.Controls.Add(this.ButtonStopTimer);
            this.Controls.Add(this.ButtonSettings);
            this.Name = "MainForm";
            this.Text = "FlowTimer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxPin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputMinWinSize)).EndInit();
            this.GroupBoxRank.ResumeLayout(false);
            this.GroupBoxRank.PerformLayout();
            this.GroupBoxItems.ResumeLayout(false);
            this.GroupBoxNames.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label LabelTimer;
        public System.Windows.Forms.PictureBox PictureBoxPin;
        public System.Windows.Forms.Button ButtonLoadStartTimer;
        public System.Windows.Forms.Button ButtonStopTimer;
        public System.Windows.Forms.Button ButtonSettings;
        public System.Windows.Forms.Button ButtonCalibrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown InputMinWinSize;
        public System.Windows.Forms.GroupBox GroupBoxRank;
        public System.Windows.Forms.RadioButton RadioS;
        public System.Windows.Forms.RadioButton RadioA;
        public System.Windows.Forms.RadioButton RadioB;
        public System.Windows.Forms.RadioButton RadioC;
        public System.Windows.Forms.CheckedListBox ChecklistItems;
        public System.Windows.Forms.GroupBox GroupBoxItems;
        public System.Windows.Forms.GroupBox GroupBoxNames;
        public System.Windows.Forms.FlowLayoutPanel PanelFrameOutput;
        public System.Windows.Forms.Button ButtonPowerOn;
        public System.Windows.Forms.Button ButtonCalculateFrame;
        public System.Windows.Forms.Button ButtonClearInput;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button ButtonCalibrateToFrame;
        public System.Windows.Forms.Button ButtonDisplayFrameData;
        public System.Windows.Forms.Button ButtonClearFrameData;
        public System.Windows.Forms.ComboBox ComboItems3;
        public System.Windows.Forms.ComboBox ComboItems2;
        public System.Windows.Forms.ComboBox ComboItems1;
        public System.Windows.Forms.ComboBox ComboNames6;
        public System.Windows.Forms.ComboBox ComboNames5;
        public System.Windows.Forms.ComboBox ComboNames4;
        public System.Windows.Forms.ComboBox ComboNames3;
        public System.Windows.Forms.ComboBox ComboNames2;
        public System.Windows.Forms.TextBox InputFrame;
    }
}
