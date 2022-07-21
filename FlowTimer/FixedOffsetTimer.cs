using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace FlowTimer {

    public class FixedOffsetTimer : BaseTimer {


        public FixedOffsetTimer() : base((target) => Math.Max((target - Win32.GetTime()) / 1000.0, 0.0)) {

        }

        public override void OnInit() {
            if(FlowTimer.Settings.LastLoadedTimers != null && File.Exists(FlowTimer.Settings.LastLoadedTimers)) {
            } else {
            }
        }

        public override void OnLoad() {
            base.OnLoad();
        }

        public override void OnTimerStart() {
            
        }

        public override void OnVisualTimerStart() {
            EnableControls(false);
        }

        public override void OnTimerStop() {
            EnableControls(true);
        }

        public override void OnKeyEvent(Keys key) {
        }

        public override void OnBeepSoundChange() {
        }

        public override void OnBeepVolumeChange() {
        }

        public void EnableControls(bool enabled) {

        }
    }
}
