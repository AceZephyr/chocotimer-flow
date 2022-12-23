using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace FlowTimer {

    public partial class SettingsForm : Form {

        public static bool UpdateFound;

        public SettingsForm() {
            InitializeComponent();

            foreach(string file in Directory.GetFiles(FlowTimer.Beeps, "*.wav")) {
                ComboBoxBeep.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
            ComboBoxBeep.SelectedItem = FlowTimer.Settings.Beep;

            TrackBarVolume.Value = FlowTimer.Settings.Volume;
            TextBoxVolume.Text = FlowTimer.Settings.Volume.ToString();
            UpDownBeepCount.Value = FlowTimer.Settings.BeepCount;
            InputFPS.Text = FlowTimer.Settings.FPS.ToString();
            InputTimeBetweenBeeps.Text = FlowTimer.Settings.TimeBetweenBeeps.ToString();
            InputCalibrationTimer.Text = FlowTimer.Settings.CalibrateTimer.ToString();
            InputMinStartTime.Text = FlowTimer.Settings.MinStartTime.ToString();
            InputBeepTimerFrequency.Text = FlowTimer.Settings.BeepTimerFrequency.ToString();
            InputDatabaseFile.Text = FlowTimer.Settings.DatabaseFile.ToString();

            ComboBoxBeep.SelectedIndexChanged += ComboBoxBeep_SelectedIndexChanged;
            TrackBarVolume.ValueChanged += TrackBarVolume_ValueChanged;
            TrackBarVolume.MouseUp += TrackBarVolume_MouseUp;
            TextBoxVolume.KeyPress += TextBoxVolume_KeyPress;
            TextBoxVolume.TextChanged += TextBoxVolume_TextChanged;
        }

        private void ComboBoxBeep_SelectedIndexChanged(object sender, EventArgs e) {
            FlowTimer.ChangeBeepSound(ComboBoxBeep.SelectedItem as string);
        }

        private void ButtonImportBeep_Click(object sender, EventArgs e) {
            FlowTimer.OpenImportBeepSoundDialog();
        }

        private void TrackBarVolume_ValueChanged(object sender, EventArgs e) {
            if((Win32.GetKeyState(Keys.LButton) & 0x80) == 0) {
                if(TextBoxVolume.Text != "")
                    TextBoxVolume.Text = TrackBarVolume.Value.ToString();
                FlowTimer.AdjustBeepSoundVolume(TrackBarVolume.Value);
                FlowTimer.AudioContext.QueueAudio(FlowTimer.BeepSound);
                FlowTimer.Settings.Volume = TrackBarVolume.Value;
            }
        }

        private void TrackBarVolume_MouseUp(object sender, MouseEventArgs e) {
            TrackBarVolume_ValueChanged(sender, e);
        }

        private void TextBoxVolume_KeyPress(object sender, KeyPressEventArgs e) {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }

            if(e.KeyChar != 0x8 && TextBoxVolume.Text.Length >= 3) {
                e.Handled = true;
            }
        }

        private void TextBoxVolume_TextChanged(object sender, EventArgs e) {
            int newValue;
            if(TextBoxVolume.Text == "") {
                newValue = 0;
            } else {
                newValue = Convert.ToInt32(TextBoxVolume.Text);
                newValue = Math.Min(newValue, 100);
                newValue = Math.Max(newValue, 0);
                int cursorPosition = TextBoxVolume.SelectionStart;
                TextBoxVolume.Text = newValue.ToString();
                TextBoxVolume.SelectionStart = cursorPosition;
            }

            TrackBarVolume.Value = newValue;
        }

        private void InputFPS_TextChanged(object sender, EventArgs e) {
            double newValue;
            if(InputFPS.Text == "") {
                newValue = 0;
            } else {
                try {
                    newValue = Convert.ToDouble(InputFPS.Text);
                } catch(System.FormatException ex) {
                    return;
                }
            }
            newValue = Math.Max(newValue, 0);
            FlowTimer.Settings.FPS = newValue;
        }

        private void InputTimeBetweenBeeps_TextChanged(object sender, EventArgs e) {
            double newValue;
            if(InputTimeBetweenBeeps.Text == "") {
                newValue = 0;
            } else {
                try {
                    newValue = Convert.ToDouble(InputTimeBetweenBeeps.Text);
                } catch(System.FormatException ex) {
                    return;
                }
            }
            newValue = Math.Max(newValue, 0);
            FlowTimer.Settings.TimeBetweenBeeps = newValue;
        }

        private void InputCalibrationTimer_TextChanged(object sender, EventArgs e) {
            double newValue;
            if(InputCalibrationTimer.Text == "") {
                newValue = 0;
            } else {
                try {
                    newValue = Convert.ToDouble(InputCalibrationTimer.Text);
                } catch(System.FormatException ex) {
                    return;
                }
            }
            newValue = Math.Max(newValue, 0);
            FlowTimer.Settings.CalibrateTimer = newValue;
        }

        private void InputMinStartTime_TextChanged(object sender, EventArgs e) {
            double newValue;
            if(InputMinStartTime.Text == "") {
                newValue = 0;
            } else {
                try {
                    newValue = Convert.ToDouble(InputMinStartTime.Text);
                } catch(System.FormatException ex) {
                    return;
                }
            }
            newValue = Math.Max(newValue, 0);
            FlowTimer.Settings.MinStartTime = newValue;
        }

        private void InputBeepTimerFrequency_TextChanged(object sender, EventArgs e) {
            int newValue;
            if(InputBeepTimerFrequency.Text == "") {
                newValue = 0;
            } else {
                try {
                    newValue = Convert.ToInt32(InputBeepTimerFrequency.Text);
                } catch(System.FormatException ex) {
                    return;
                }
            }
            newValue = Math.Max(newValue, 0);
            FlowTimer.Settings.BeepTimerFrequency = newValue;
        }

        private void InputDatabaseFile_TextChanged(object sender, EventArgs e) {
            FlowTimer.Settings.DatabaseFile = InputDatabaseFile.Text;
        }

        private void UpDownBeepCount_ValueChanged(object sender, EventArgs e) {
            FlowTimer.Settings.BeepCount = (int) UpDownBeepCount.Value;
        }

        private void button1_Click_1(object sender, EventArgs e) {
            Console.WriteLine(FlowTimer.Folder);
            String f = FlowTimer.Folder.Replace("/", "\\");
            if(Directory.Exists(f)) {
                ProcessStartInfo startInfo = new ProcessStartInfo {
                    Arguments = f,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            } else {
                MessageBox.Show(string.Format("{0} Directory does not exist!", f));
            }
        }
    }
}
