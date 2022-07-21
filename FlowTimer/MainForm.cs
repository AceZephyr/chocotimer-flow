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

        private void ButtonStart_Click(object sender, EventArgs e) {
            FlowTimer.ClickStartTimer();
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
            int newValue;
            if(InputMinWinSize.Text == "") {
                newValue = 0;
            } else {
                try {
                    newValue = Convert.ToInt32(InputMinWinSize.Text);
                } catch(System.FormatException ex) {
                    return;
                }
            }
            newValue = Math.Max(newValue, 0);
            FlowTimer.Settings.MinimumWindowSize = newValue;
        }
    }
}
