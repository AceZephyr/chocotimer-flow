using System.Windows.Forms;

namespace FlowTimer {
    
    public abstract class BaseTimer {

        public delegate double TimerUpdateCallback(double targetTime);

        public TimerUpdateCallback TimerCallback;
        
        public BaseTimer(TimerUpdateCallback timerCallback) {
            TimerCallback = timerCallback;
        }

        public virtual void OnLoad() {
        }

        public abstract void OnInit();
        public abstract void OnTimerStart();
        public abstract void OnVisualTimerStart();
        public abstract void OnTimerStop();
        public abstract void OnKeyEvent(Keys key);
        public abstract void OnBeepSoundChange();
        public abstract void OnBeepVolumeChange();
    }
}
