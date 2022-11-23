using System;
using System.Windows.Forms;

namespace FlowTimer {

    public unsafe partial class MainForm : Form {

        public MainForm() {
            InitializeComponent();
            FlowTimer.SetMainForm(this);
            FlowTimer.Init();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            FlowTimer.Destroy();
        }

        private void ButtonStop_Click(object sender, EventArgs e) {
            FlowTimer.StopTimer(false);
        }

        private void ButtonSettings_Click(object sender, EventArgs e) {
            FlowTimer.OpenSettingsForm();
        }

        private void PictureBoxPin_Click(object sender, EventArgs e) {
            FlowTimer.TogglePin();
        }

        private void ButtonPowerOn_Click(object sender, EventArgs e) {
            FlowTimer.ClickPowerOn();
        }

        private void ButtonCalibrate_Click(object sender, EventArgs e) {
            FlowTimer.ClickCalibrate();
        }

        private void InputMinWinSize_ValueChanged(object sender, EventArgs e) {
            int newValue = Math.Max((int) (sender as NumericUpDown).Value, 0);
            FlowTimer.Settings.MinimumWindowSize = newValue;
        }

        private void ChecklistItems_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void ButtonDisplayFrameData_Click(object sender, EventArgs e) {
            FlowTimer.ClickDisplayFrameData(PanelFrameOutputSub);
        }

        private void ButtonClearFrameDataRight_Click(object sender, EventArgs e) {
            FlowTimer.ClickClearFrameData(PanelFrameOutput);
        }

        private void ButtonClearFrameDataDown_Click(object sender, EventArgs e) {
            FlowTimer.ClickClearFrameData(PanelFrameOutputSub);
        }

        private void ButtonBuildCaches_Click(object sender, EventArgs e) {
            FlowTimer.ClickBuildCaches();
        }
    }
}
