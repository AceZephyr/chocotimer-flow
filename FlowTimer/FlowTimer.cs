using System;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using static FlowTimer.Win32;
using static FlowTimer.SDL;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace FlowTimer {

    public class PrizeData {
        public int[] items, tileCards, names;
    }

    public class RaceData {
        public int rank, frame, teioh, inputs, winner;
    }

    public class Window {
        public int rank, startFrame, winLength;
        public ulong itemFlags;
    }

    public class WindowFrameData {
        public int teioh, winners;
        public int[] items;
        public int[] cards;
        public ulong itemFlags;
    }

    public static class FlowTimer {

        public static readonly string[] CHOCO_NAMES = {"SAM", "ELEN", "BLUES", "TOM", "JOHN", "GARY", "MIKE", "SANDY", "JU", "LY", "JOEL", "GREY", "EDWARD", "JAMES",
    "HARVEY", "DAN", "RUDY", "GRAHAM", "FOX", "CLIVE", "SEAN", "YOUNG", "ROBIN", "DARIO", "ARL", "SARA", "MARIE",
    "SAMMY", "LIA", "KNIGHT", "PAULA", "PAU", "LE", "PETER", "AIMEE", "TERRY", "ANDY", "NANCY", "TIM", "ROBER",
    "GEORGE", "JENNY", "RICA", "JULIA"};

        public static readonly string[] ITEM_NAMES = {"Sprint Shoes", "Counter", "Magic Counter", "Precious Watch", "Cat's Bell", "Enemy Away", "Sneak Attack",
    "Chocobracelet", "Ether", "Elixir", "Hero Drink", "Bolt Plume", "Fire Fang", "Antarctic Wind", "Swift Bolt",
    "Fire Veil", "Ice Crystal", "Megalixir", "Turbo Ether", "Potion", "Phoenix Down", "Hyper", "Tranquilizer",
    "Hi-Potion"};

        public static readonly Dictionary<int, string> SOLUTION_STRINGS = new Dictionary<int, string>();
        public static readonly Dictionary<string, ulong> PRIZE_FAMILIES = new Dictionary<string, ulong>();

        public const string TimerFileFilter = "Json files (*.json)|*.json";
        public const string BeepFileFilter = "WAV files (*.wav)|*.wav";

        public static readonly string Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/flowtimer/";
        public static readonly string Beeps = Folder + "beeps/";
        public static readonly string SettingsFile = Folder + "settings.json";

        public static MainForm MainForm;
        public static int MainFormBaseHeight;

        public static FixedOffsetTimer FixedOffset;
        public static BaseTimer CurrentTab {
            get {
                return FixedOffset;
            }
        }

        public static SettingsForm SettingsForm;
        public static Settings Settings;

        public static SpriteSheet PinSheet;

        public static AudioContext AudioContext;
        public static byte[] BeepSound;
        public static byte[] BeepSoundUnadjusted;
        public static byte[] PCM;

        public static bool IsTimerRunning;
        public static bool IsTimerAudioRunning;
        public static double TimerTarget;
        public static Thread TimerUpdateThread;

        public static Proc KeyboardCallback;
        public static IntPtr KeyboardHook;

        public static double PowerOnTime = -1,
            CalibrationTime = -1,
            NextWindowTargetTime = -1;
        public static int CalibrationFrame = -1,
            NextWindowStartFrame = -1,
            NextWindowLength = -1,
            NextWindowTargetFrame = -1,
            NextWindowLastFrame = -1;

        public static Dictionary<int, Window> WINDOW_MAP = new Dictionary<int, Window>();
        public static List<int> WINDOW_MAP_FRAMES_LIST_SORTED = new List<int>();
        public static ulong WINDOW_MAP_ITEM_FLAGS = 0;
        public static int WINDOW_MAP_FRAME_LIMIT = 0;
        public static int WINDOW_MAP_RANK = -1;

        public static void Init() {
            SOLUTION_STRINGS.Add(0, "Automatic");
            SOLUTION_STRINGS.Add(65536, "Manual");
            SOLUTION_STRINGS.Add(65552, "M Up");
            SOLUTION_STRINGS.Add(65568, "M Right");
            SOLUTION_STRINGS.Add(65584, "M Up-Right");
            SOLUTION_STRINGS.Add(65600, "M Down");
            SOLUTION_STRINGS.Add(65632, "M Down-Right");
            SOLUTION_STRINGS.Add(65664, "M Left");
            SOLUTION_STRINGS.Add(65680, "M Up-Left");
            SOLUTION_STRINGS.Add(65728, "M Down-Left");
            SOLUTION_STRINGS.Add(68096, "M R1R2");
            SOLUTION_STRINGS.Add(68112, "M R1R2 Up");
            SOLUTION_STRINGS.Add(68128, "M R1R2 Right");
            SOLUTION_STRINGS.Add(68144, "M R1R2 Up-Right");
            SOLUTION_STRINGS.Add(68160, "M R1R2 Down");
            SOLUTION_STRINGS.Add(68192, "M R1R2 Down-Right");
            SOLUTION_STRINGS.Add(68224, "M R1R2 Left");
            SOLUTION_STRINGS.Add(68240, "M R1R2 Up-Left");
            SOLUTION_STRINGS.Add(68288, "M R1R2 Down-Left");
            SOLUTION_STRINGS.Add(73728, "M Circle");
            SOLUTION_STRINGS.Add(73744, "M Circle Up");
            SOLUTION_STRINGS.Add(73760, "M Circle Right");
            SOLUTION_STRINGS.Add(73776, "M Circle Up-Right");
            SOLUTION_STRINGS.Add(73792, "M Circle Down");
            SOLUTION_STRINGS.Add(73824, "M Circle Down-Right");
            SOLUTION_STRINGS.Add(73856, "M Circle Left");
            SOLUTION_STRINGS.Add(73872, "M Circle Up-Left");
            SOLUTION_STRINGS.Add(73920, "M Circle Down-Left");
            SOLUTION_STRINGS.Add(98304, "M Square");
            SOLUTION_STRINGS.Add(98320, "M Square Up");
            SOLUTION_STRINGS.Add(98336, "M Square Right");
            SOLUTION_STRINGS.Add(98352, "M Square Up-Right");
            SOLUTION_STRINGS.Add(98368, "M Square Down");
            SOLUTION_STRINGS.Add(98400, "M Square Down-Right");
            SOLUTION_STRINGS.Add(98432, "M Square Left");
            SOLUTION_STRINGS.Add(98448, "M Square Up-Left");
            SOLUTION_STRINGS.Add(98496, "M Square Down-Left");

            PRIZE_FAMILIES.Add("Enemy Away", 1UL << 5);
            PRIZE_FAMILIES.Add("Sneak Attack", 1UL << 6);

            PRIZE_FAMILIES.Add("500+", 21);
            PRIZE_FAMILIES.Add("300+", 131327);
            PRIZE_FAMILIES.Add("150+", 393983);

            FixedOffset = new FixedOffsetTimer();

            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;
            Win32.InitTiming();

            if(File.Exists(SettingsFile)) {
                try {
                    Settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(SettingsFile));
                } catch(Exception e) {
                    MessageBox.Show("The settings could not be loaded and have been reset to their default values.\n" + e.Source + ": " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if(Settings == null) {
                Settings = new Settings();
            }

            PinSheet = new SpriteSheet(new Bitmap(FileSystem.ReadPackedResourceStream("FlowTimer.Resources.pin.png")), 16, 16);
            Pin(Settings.Pinned);

            AudioContext.GlobalInit();
            ChangeBeepSound(Settings.Beep, false);

            TimerUpdateThread = new Thread(TimerUpdateCallback);

            MainForm.ButtonLoadStartTimer.DisableSelect();
            MainForm.ButtonStopTimer.DisableSelect();
            MainForm.ButtonSettings.DisableSelect();
            MainForm.ButtonPowerOn.DisableSelect();
            MainForm.ButtonCalibrate.DisableSelect();

            MainForm.ButtonCalibrate.Enabled = false;
            MainForm.ButtonLoadStartTimer.Enabled = false;
            MainForm.ButtonStopTimer.Enabled = false;

            MainForm.RadioA.Checked = true;

            MainForm.ComboItems1.Items.AddRange(ITEM_NAMES);
            MainForm.ComboItems2.Items.AddRange(ITEM_NAMES);
            MainForm.ComboItems3.Items.AddRange(ITEM_NAMES);

            MainForm.ComboItems1.PreviewKeyDown += InputCombo_PreviewKeyDown;
            MainForm.ComboItems2.PreviewKeyDown += InputCombo_PreviewKeyDown;
            MainForm.ComboItems3.PreviewKeyDown += InputCombo_PreviewKeyDown;

            MainForm.ComboNames2.Items.AddRange(CHOCO_NAMES);
            MainForm.ComboNames3.Items.AddRange(CHOCO_NAMES);
            MainForm.ComboNames4.Items.AddRange(CHOCO_NAMES);
            MainForm.ComboNames5.Items.AddRange(CHOCO_NAMES);
            MainForm.ComboNames6.Items.AddRange(CHOCO_NAMES);

            MainForm.ComboNames2.PreviewKeyDown += InputCombo_PreviewKeyDown;
            MainForm.ComboNames3.PreviewKeyDown += InputCombo_PreviewKeyDown;
            MainForm.ComboNames4.PreviewKeyDown += InputCombo_PreviewKeyDown;
            MainForm.ComboNames5.PreviewKeyDown += InputCombo_PreviewKeyDown;
            MainForm.ComboNames6.PreviewKeyDown += InputCombo_PreviewKeyDown;

            MainForm.ButtonClearInput.Click += new System.EventHandler(ButtonClearInput_Click);
            MainForm.ButtonCalculateFrame.Click += new System.EventHandler(ButtonCalculateFrame_Click);
            MainForm.ButtonCalibrateToFrame.Click += new System.EventHandler(ButtonCalibrateToFrame_Click);
            MainForm.ButtonLoadStartTimer.Click += new System.EventHandler(ButtonLoadStartTimer_Click);

            KeyboardCallback = Keycallback;
            KeyboardHook = SetHook(WH_KEYBOARD_LL, KeyboardCallback);

            FixedOffset.OnInit();
        }

        public static void Destroy() {
            UnhookWindowsHookEx(KeyboardHook);
            TimerUpdateThread.AbortIfAlive();
            AudioContext.ClearQueuedAudio();
            AudioContext.Destroy();
            AudioContext.GlobalDestroy();
            File.WriteAllText(SettingsFile, JsonConvert.SerializeObject(Settings));
        }

        public static int GetCurrentBuild() {
            return Assembly.GetExecutingAssembly().GetName().Version.Major;
        }

        public static void SetMainForm(MainForm mainForm) {
            MainForm = mainForm;
            MainFormBaseHeight = mainForm.Height;
            MainForm.RemoveKeyControls();

            int buildVersion = Assembly.GetExecutingAssembly().GetName().Version.Major;
            MainForm.Text += " (Build " + buildVersion + ")";
        }

        public static void RemoveKeyControls(this Control control) {
            foreach(Control ctrl in control.Controls) {
                ctrl.RemoveKeyControls();
                ctrl.PreviewKeyDown += MainForm_PreviewKeyDown;
                ctrl.KeyDown += MainForm_KeyDownEvent;
            }
        }

        private static void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs args) {
            switch(args.KeyCode) {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    args.IsInputKey = true;
                    break;
            }
        }

        private static string prefix(ComboBox.ObjectCollection coll, string target) {
            List<string> o = new List<string>();
            for(int i = 0; i < coll.Count; i++) {
                var s = coll[i] as string;
                if(s.ToLower().StartsWith(target.ToLower())) {
                    o.Add(s);
                }
            }
            if(o.Count < 1) {
                return "";
            } else if(o.Count == 1) {
                return o[0];
            } else {
                return "(" + String.Join("|", o) + ")";
            }
        }

        private static string lev(ComboBox.ObjectCollection coll, string target) {
            int min = int.MaxValue;
            for(int i = 0; i < coll.Count; i++) {
                var s = coll[i] as string;
                int dist = Fastenshtein.Levenshtein.Distance(s, target);
                if(dist < min) {
                    min = dist;
                }
            }
            List<string> o = new List<string>();
            for(int i = 0; i < coll.Count; i++) {
                var s = coll[i] as string;
                int dist = Fastenshtein.Levenshtein.Distance(s, target);
                if(dist == min) {
                    o.Add(s);
                }
            }
            if(o.Count < 1) {
                throw new Exception();
            } else if(o.Count == 1) {
                return o[0];
            } else {
                return "(" + string.Join("|", o) + ")";
            }
        }

        private static string autocomplete(ComboBox.ObjectCollection coll, string target) {
            if(target.Length <= 1) {
                return target;
            }
            var o = prefix(coll, target);
            if(o.Length == 0) {
                o = lev(coll, target);
            }
            return o;
        }

        private static void InputCombo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs args) {
            if(!(sender is ComboBox)) {
                return;
            }
            ComboBox s = sender as ComboBox;
            switch(args.KeyCode) {
                case Keys.Tab:
                    if(s.Text.StartsWith("(")) {
                        return;
                    }
                    var x = autocomplete(s.Items, s.Text);
                    s.Text = x;
                    break;
            }
        }

        private static void MainForm_KeyDownEvent(object sender, KeyEventArgs args) {
            switch(args.KeyCode) {
                case Keys.Escape:
                    MainForm.ActiveControl = null;
                    args.Handled = true;
                    args.SuppressKeyPress = true;
                    break;
            }
        }

        private static void wipeWindowMap(ulong selItemFlags, int rank) {
            WINDOW_MAP.Clear();
            WINDOW_MAP_FRAMES_LIST_SORTED.Clear();
            WINDOW_MAP_ITEM_FLAGS = selItemFlags;
            WINDOW_MAP_RANK = rank;
            WINDOW_MAP_FRAME_LIMIT = 0;
        }

        private static bool isWindowMapValid(ulong selItemFlags, int rank) {
            return WINDOW_MAP_ITEM_FLAGS == selItemFlags && WINDOW_MAP_RANK == rank;
        }

        private static void expandWindowMap(ulong selItemFlags, int frame, int rank, int expandByFrames = 30 * 60 * 60) {
            int frameStart;
            if(!isWindowMapValid(selItemFlags, rank)) {
                wipeWindowMap(selItemFlags, rank);
                frameStart = frame;
            } else {
                frameStart = WINDOW_MAP_FRAME_LIMIT;
            }
            int frameEnd = frame + expandByFrames;
            string query = $@"SELECT DISTINCT Races.Frame, Races.Teioh, Races.Winner, Prizes.Item1, Prizes.Item2, Prizes.Item3, Prizes.Card1_1, Prizes.Card1_2, Prizes.Card1_3, Prizes.Card1_4, Prizes.Card1_5 FROM Prizes
                INNER JOIN Races ON (
                    Races.Frame = Prizes.Frame AND
                    Races.Rank = Prizes.rank
                    )
                WHERE Races.Teioh = 0
                and Races.Winner != -1
                and Prizes.Rank = {rank}
                and Races.Frame >= {frameStart}
                and Races.Frame < {frameEnd}
                ORDER BY Prizes.Frame";
            using(var conn = makeConnection()) {
                conn.Open();
                SQLiteCommand c = conn.CreateCommand();
                c.CommandText = query;
                SQLiteDataReader reader = c.ExecuteReader();
                // sanity checking
                if(!isWindowMapValid(selItemFlags, rank)) {
                    return;
                }
                List<int[]> rows = new List<int[]>();
                try {
                    while(reader.Read()) {
                        int[] row = new int[reader.VisibleFieldCount];
                        for(int i = 0; i < reader.VisibleFieldCount; i++) {
                            row[i] = reader.GetInt32(i);
                        }
                        rows.Add(row);
                    }
                } finally {
                    reader.Close();
                }
                conn.Close();
                Dictionary<int, List<int>> winnersByFrame = new Dictionary<int, List<int>>();
                foreach(int[] r in rows) {
                    int f = r[0];
                    if(!winnersByFrame.ContainsKey(f)) {
                        winnersByFrame.Add(f, new List<int>());
                    }
                    if(r[2] != -1) {
                        winnersByFrame[f].Add(r[2]);
                    }
                }
                Dictionary<int, WindowFrameData> fdata = new Dictionary<int, WindowFrameData>();
                ulong itemFlags;
                foreach(int[] r in rows) {
                    int f = r[0];
                    if(!fdata.ContainsKey(f)) {
                        int[] items = new int[] { r[3], r[4], r[5] };
                        int[] cards = new int[] { r[6], r[7], r[8], r[9], r[10] };
                        List<int> winners = winnersByFrame[f];
                        itemFlags = 0;
                        foreach(int w in winners) {
                            itemFlags |= (1UL << items[cards[w - 2]]);
                        }
                        if((itemFlags & WINDOW_MAP_ITEM_FLAGS) != 0) {
                            WindowFrameData wfd = new WindowFrameData();
                            wfd.teioh = r[2];
                            wfd.items = items;
                            wfd.cards = cards;
                            wfd.itemFlags = itemFlags;
                            fdata.Add(f, wfd);
                        }
                    }
                }
                List<int> framesList = fdata.Keys.ToList();
                framesList.Sort();

                if(framesList.Count > 0) {
                    int windowStartFrame = framesList[0];
                    int windowLength = 1;
                    itemFlags = fdata[windowStartFrame].itemFlags;
                    for(int i = 1; i < framesList.Count; i++) {
                        int f = framesList[i];
                        if(f < WINDOW_MAP_FRAME_LIMIT) {
                            continue;
                        }
                        if(windowStartFrame == f - windowLength) {
                            itemFlags |= fdata[f].itemFlags;
                            windowLength++;
                        } else {
                            if(windowLength > 1) {
                                Console.WriteLine(windowStartFrame);
                                Window w = new Window();
                                w.rank = rank;
                                w.startFrame = windowStartFrame;
                                w.winLength = windowLength;
                                w.itemFlags = itemFlags;
                                WINDOW_MAP.Add(windowStartFrame, w);
                                WINDOW_MAP_FRAMES_LIST_SORTED.Add(windowStartFrame);
                            }
                            windowStartFrame = f;
                            windowLength = 1;
                            itemFlags = fdata[f].itemFlags;
                        }
                    }
                    WINDOW_MAP_FRAMES_LIST_SORTED.Sort();
                }

                WINDOW_MAP_FRAME_LIMIT = frameEnd;
            }
        }

        public static int binSearch(List<int> arr, int x) {
            int lo = 0;
            int hi = arr.Count - 1;
            while(lo <= hi) {
                int mid = (lo + hi) >> 1;
                if(arr[mid] == x)
                    return mid;
                else if(arr[mid] < x)
                    lo = mid + 1;
                else
                    hi = mid - 1;
            }
            return lo;
        }

        public static int getNextWindow(int startFrame, int minWindowSize, ulong selectedItemFlags, int rank, int currentFrame, int remainingTries = 1) {
            if(!isWindowMapValid(selectedItemFlags, rank)) {
                expandWindowMap(selectedItemFlags, currentFrame, rank);
                if(!isWindowMapValid(selectedItemFlags, rank)) {
                    MessageBox.Show("No windows.", "ChocoTimer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            int startIndex = binSearch(WINDOW_MAP_FRAMES_LIST_SORTED, startFrame);

            for(int i = startIndex; i < WINDOW_MAP_FRAMES_LIST_SORTED.Count; i++) {
                Window w = WINDOW_MAP[WINDOW_MAP_FRAMES_LIST_SORTED[i]];
                if(w.rank == rank && w.startFrame > startFrame && w.winLength >= minWindowSize && (w.itemFlags & selectedItemFlags) != 0) {
                    return WINDOW_MAP_FRAMES_LIST_SORTED[i];
                }
            }
            // couldn't find window. attempt to generate more data.
            if(remainingTries > 0) {
                expandWindowMap(selectedItemFlags, currentFrame, rank);
                return getNextWindow(startFrame, minWindowSize, selectedItemFlags, rank, currentFrame, remainingTries - 1);
            }
            return -1;
        }

        private static void ButtonLoadStartTimer_Click(object sender, EventArgs e) {
            if(PowerOnTime == -1 || CalibrationTime == -1 || CalibrationFrame == -1) {
                MessageBox.Show("Power on and calibrate first.", "ChocoTimer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double now = Win32.GetTime();
            int currentFrame = framesBetweenTimes(now, PowerOnTime);
            int startFrame = framesBetweenTimes(Settings.MinStartTime + now, PowerOnTime);
            ulong selectedItemFlags = getSelectedItemFlags();
            if(selectedItemFlags == 0UL) {
                MessageBox.Show("Select at least one item.", "ChocoTimer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int rank = getSelectedRank();
            int winFrame = getNextWindow(startFrame, Settings.MinimumWindowSize, selectedItemFlags, rank, currentFrame);
            if(winFrame < 0) {
                MessageBox.Show("Could not find window.", "ChocoTimer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Window win = WINDOW_MAP[winFrame];
            NextWindowStartFrame = win.startFrame;
            NextWindowLength = win.winLength;
            NextWindowTargetFrame = NextWindowStartFrame + (NextWindowLength / 2);
            NextWindowTargetTime = PowerOnTime + Math.Round(framesToMilliseconds(NextWindowTargetFrame));
            NextWindowLastFrame = NextWindowStartFrame + NextWindowLength - 1;
            CalibrationTime = NextWindowTargetTime;
            CalibrationFrame = 0;

            clearFramesData(MainForm.PanelFrameOutput);
            putFramesData(NextWindowStartFrame, NextWindowLastFrame, rank, selectedItemFlags, MainForm.PanelFrameOutput);
            StartTimer(NextWindowTargetTime);
        }

        private static void ButtonClearInput_Click(object sender, EventArgs e) {
            MainForm.ComboItems1.Text = "";
            MainForm.ComboItems2.Text = "";
            MainForm.ComboItems3.Text = "";

            MainForm.ComboNames2.Text = "";
            MainForm.ComboNames3.Text = "";
            MainForm.ComboNames4.Text = "";
            MainForm.ComboNames5.Text = "";
            MainForm.ComboNames6.Text = "";
        }

        private static int indexOf(string[] arr, string target) {
            for(int k = 0; k < arr.Length; k++) {
                if(target == arr[k]) {
                    return k;
                }
            }
            return -1;
        }

        private static int minDistToFrame(List<int> possibleFrames, int target) {
            int currMin = possibleFrames[0];
            for(int i = 1; i < possibleFrames.Count; i++) {
                int currMinDelta = Math.Abs(currMin - target);
                int newDelta = Math.Abs(possibleFrames[i] - target);
                if(newDelta < currMin) {
                    currMin = newDelta;
                }
            }
            return currMin;
        }

        private static void ButtonCalculateFrame_Click(object sender, EventArgs e) {
            var itemStrs = new string[] {
                MainForm.ComboItems1.Text,
                MainForm.ComboItems2.Text,
                MainForm.ComboItems3.Text
            };

            var nameStrs = new string[] {
                MainForm.ComboNames2.Text,
                MainForm.ComboNames3.Text,
                MainForm.ComboNames4.Text,
                MainForm.ComboNames5.Text,
                MainForm.ComboNames6.Text
            };

            var queryParts = new List<string>();
            var rank = getSelectedRank();

            for(int i = 0; i < itemStrs.Length; i++) {
                if(itemStrs[i].Trim().Length == 0)
                    continue;
                string s;
                if(itemStrs[i].StartsWith("(") && itemStrs[i].EndsWith(")")) {
                    s = itemStrs[i].Substring(1, itemStrs[i].Length - 2);
                } else {
                    s = itemStrs[i];
                }
                string[] parts = s.Split(new char[] { '|' });
                string[] qParts = new string[parts.Length];
                for(int j = 0; j < parts.Length; j++) {
                    qParts[j] = $"Item{i + 1} = {indexOf(ITEM_NAMES, parts[j])}";
                }
                queryParts.Add("(" + String.Join(" OR ", qParts) + ")");
            }

            for(int i = 0; i < nameStrs.Length; i++) {
                if(nameStrs[i].Trim().Length == 0)
                    continue;
                string s;
                if(nameStrs[i].StartsWith("(") && nameStrs[i].EndsWith(")")) {
                    s = nameStrs[i].Substring(1, nameStrs[i].Length - 2);
                } else {
                    s = nameStrs[i];
                }
                string[] parts = s.Split(new char[] { '|' });
                string[] qParts = new string[parts.Length];
                for(int j = 0; j < parts.Length; j++) {
                    qParts[j] = $"Name{i + 2} = {indexOf(CHOCO_NAMES, parts[j])}";
                }
                queryParts.Add("(" + String.Join(" OR ", qParts) + ")");
            }

            if(queryParts.Count == 0) {
                MessageBox.Show("Must input at least one query", "ChocoTimer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var framesFirstEstimate = framesBetweenTimes(CalibrationTime, PowerOnTime);
            var query = $"select Frame from prizes where Rank = {rank} and {String.Join(" AND ", queryParts.ToArray())}";
            List<int> possibleFrames = new List<int>();
            using(var conn = makeConnection()) {
                conn.Open();
                SQLiteCommand c = conn.CreateCommand();
                c.CommandText = query;
                SQLiteDataReader r = c.ExecuteReader();
                try {
                    while(r.Read()) {
                        possibleFrames.Add(r.GetInt32(0));
                    }
                } finally {
                    r.Close();
                }
                conn.Close();
            }
            if(possibleFrames.Count > 0) {
                MainForm.InputFrame.Text = $"{minDistToFrame(possibleFrames, framesFirstEstimate)}";
            } else {
                MessageBox.Show("Could not match frame.", "ChocoTimer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ButtonCalibrateToFrame_Click(object sender, EventArgs e) {
            if(PowerOnTime == -1 || CalibrationTime == -1) {
                MessageBox.Show("Signal a power on time and prepare to calibrate with a race before putting in data.", "ChocoTimer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(MainForm.InputFrame.Text.Length == 0) {
                MessageBox.Show("Input a frame in the Frame box.", "ChocoTimer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CalibrationFrame = Int32.Parse(MainForm.InputFrame.Text);
            PowerOnTime = CalibrationTime - Math.Round((1000 / Settings.FPS) * CalibrationFrame);
        }

        private static IntPtr Keycallback(int nCode, int wParam, IntPtr lParam) {
            if(SettingsForm == null || !SettingsForm.Visible) {
                if(nCode >= 0 && Settings.KeyMethod.IsActivatedByEvent(wParam)) {
                    Keys key = (Keys) Marshal.ReadInt32(lParam);

                    CurrentTab.OnKeyEvent(key);
                }
            }

            return CallNextHookEx(KeyboardHook, nCode, wParam, lParam);
        }

        public static void ResizeForm(int width, int height) {
            Size size = new Size() {
                Width = width,
                Height = height,
            };

            MainForm.MinimumSize = size;
            MainForm.MaximumSize = size;
            MainForm.Size = size;
        }

        public static void EnableControls(bool enabled) {
            MainForm.ButtonSettings.Enabled = enabled;
        }

        public static void TogglePin() {
            Pin(!Settings.Pinned);
        }

        public static void Pin(bool pin) {
            MainForm.TopMost = pin;
            if(SettingsForm != null)
                SettingsForm.TopMost = pin;
            Settings.Pinned = pin;
            MainForm.PictureBoxPin.Image = PinSheet[pin ? 1 : 0];
        }

        public static void ClickPowerOn() {
            double t = Win32.GetTime();
            PowerOnTime = t;
            MainForm.ButtonCalibrate.Enabled = true;
        }

        public static void ClickCalibrate() {
            MainForm.ButtonLoadStartTimer.Enabled = true;
            MainForm.ButtonStopTimer.Enabled = true;
            double t = Win32.GetTime() + FlowTimer.Settings.CalibrateTimer;
            StartTimer(t);
            CalibrationTime = t;
        }

        public static void ClickDisplayFrameData(FlowLayoutPanel container) {
            if(MainForm.InputFrame.Text.Length == 0) {
                MessageBox.Show("Input a frame in the Frame box.", "ChocoTimer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int displayFrame = Int32.Parse(MainForm.InputFrame.Text);
            int rank = getSelectedRank();
            ulong targetPrizeFlags = getSelectedItemFlags();
            clearFramesData(container);
            putFramesData(displayFrame, displayFrame, rank, targetPrizeFlags, container);
        }

        public static void ClickClearFrameData(FlowLayoutPanel container) {
            clearFramesData(container);
        }

        public static void ClickBuildCaches() {
            expandWindowMap(getSelectedItemFlags(), framesBetweenTimes(Settings.MinStartTime + Win32.GetTime(), PowerOnTime), getSelectedRank());
        }

        public static void UpdatePCM(double[] offsets, uint interval, uint numBeeps, bool garbageCollect = true) {
            // try to force garbage collection on the old pcm data
            if(garbageCollect)
                GC.Collect();
            double maxOffset = offsets.Max();

            PCM = new byte[((int) Math.Ceiling(maxOffset / 1000.0 * AudioContext.SampleRate)) * AudioContext.NumChannels * AudioContext.BytesPerSample + BeepSound.Length];

            foreach(double offset in offsets) {
                for(int i = 0; i < numBeeps; i++) {
                    int destOffset = (int) ((offset - i * interval) / 1000.0 * AudioContext.SampleRate) * AudioContext.NumChannels * 2;
                    Array.Copy(BeepSound, 0, PCM, destOffset, BeepSound.Length);
                }
            }
        }

        public static void StartAudio() {
            Console.WriteLine("Creating PCM");
            double now = Win32.GetTime();
            double offset = TimerTarget - now;
            UpdatePCM(new double[] { offset }, (uint) FlowTimer.Settings.TimeBetweenBeeps, (uint) FlowTimer.Settings.BeepCount);
            AudioContext.QueueAudio(PCM);
            IsTimerAudioRunning = true;
        }

        public static void StartTimer(double target) {
            AudioContext.ClearQueuedAudio();
            IsTimerAudioRunning = false;

            IsTimerRunning = true;
            TimerTarget = target;

            if(!MainForm.ButtonLoadStartTimer.Enabled) {
                AudioContext.ClearQueuedAudio();
                return;
            }

            EnableControls(false);

            TimerUpdateThread.AbortIfAlive();
            TimerUpdateThread = new Thread(TimerUpdateCallback);
            TimerUpdateThread.Start();
            CurrentTab.OnVisualTimerStart();
        }

        public static void StopTimer(bool timerExpired) {
            if(!timerExpired) {
                AudioContext.ClearQueuedAudio();
                IsTimerAudioRunning = false;
                TimerUpdateThread.AbortIfAlive();
            }

            IsTimerRunning = false;
            CurrentTab.OnTimerStop();
            EnableControls(true);
        }

        private static void TimerUpdateCallback() {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;
            const uint resolution = 15;

            MethodInvoker inv;
            double currentTime = 0.0f;

            do {
                inv = delegate {
                    currentTime = CurrentTab.TimerCallback(TimerTarget);

                    if(!IsTimerAudioRunning && currentTime < FlowTimer.Settings.CreateAudioAtTime) {
                        StartAudio();
                    }

                    MainForm.LabelTimer.Text = currentTime.ToFormattedString();
                };
                MainForm.Invoke(inv);

                SDL_Delay(resolution);
            } while(currentTime > 0.0);

            inv = delegate {
                StopTimer(true);
            };
            MainForm.Invoke(inv);
        }

        public static void OpenSettingsForm() {
            SettingsForm = new SettingsForm();
            Settings.SetSettingsTexts();
            SettingsForm.TopMost = Settings.Pinned;
            SettingsForm.RemoveKeyControls();
            SettingsForm.ShowDialog(MainForm);
        }

        public static void OpenImportBeepSoundDialog() {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = BeepFileFilter;

            if(dialog.ShowDialog() == DialogResult.OK) {
                ImportBeepSound(dialog.FileName, true);
            }
        }

        public static bool ImportBeepSound(string filePath, bool displayMessages = true) {
            string fileName = Path.GetFileName(filePath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

            if(File.Exists(Beeps + fileName)) {
                if(displayMessages) {
                    MessageBox.Show("Beep sound '" + fileNameWithoutExtension + "' already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

            SDL_AudioSpec audioSpec;
            Wave.LoadWAV(filePath, out _, out audioSpec);

            if(audioSpec.format != AUDIO_S16LSB) {
                if(displayMessages) {
                    MessageBox.Show("FlowTimer does not support this audio file (yet).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

            File.Copy(filePath, Beeps + fileName);
            if(SettingsForm != null)
                SettingsForm.ComboBoxBeep.Items.Add(fileNameWithoutExtension);
            MessageBox.Show("Beep sucessfully imported from '" + filePath + "'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        public static void ChangeBeepSound(string beepName, bool playSound = true) {
            if(AudioContext != null) {
                AudioContext.Destroy();
                IsTimerAudioRunning = false;
            }


            SDL_AudioSpec audioSpec;
            Wave.LoadWAV(Beeps + beepName + ".wav", out BeepSoundUnadjusted, out audioSpec);
            AudioContext = new AudioContext(audioSpec.freq, audioSpec.format, audioSpec.channels);
            AdjustBeepSoundVolume(Settings.Volume);
            CurrentTab.OnBeepSoundChange();
            Settings.Beep = beepName;

            if(playSound) {
                AudioContext.QueueAudio(BeepSound);
            }
        }

        public static void AdjustBeepSoundVolume(int newVolume) {
            float vol = newVolume / 100.0f;
            BeepSound = new byte[BeepSoundUnadjusted.Length];
            for(int i = 0; i < BeepSound.Length; i += 2) {
                short sample = (short) (BeepSoundUnadjusted[i] | (BeepSoundUnadjusted[i + 1] << 8));
                float floatSample = sample;

                floatSample *= vol;

                if(floatSample < short.MinValue)
                    floatSample = short.MinValue;
                if(floatSample > short.MaxValue)
                    floatSample = short.MaxValue;

                sample = (short) floatSample;
                BeepSound[i] = (byte) (sample & 0xFF);
                BeepSound[i + 1] = (byte) (sample >> 8);
            }

            CurrentTab.OnBeepVolumeChange();
        }

        public static void ChangeKeyMethod(KeyMethod newMethod) {
            Settings.KeyMethod = newMethod;
        }

        public static int framesBetweenTimes(double time1, double time2) {
            return (int) Math.Round(((time1 - time2) * Settings.FPS) / 1000);
        }

        public static double framesToMilliseconds(int frame) {
            return frame * (1000 / Settings.FPS);
        }

        public static SQLiteDataReader fetchRangePrizes(SQLiteConnection conn, int startFrame, int endFrame, int rank) {
            SQLiteCommand c = conn.CreateCommand();
            c.CommandText = $@"select * from Prizes
                    where Rank = {rank}
                    and Frame >= {startFrame}
                    and Frame <= {endFrame}
                    order by Frame asc";
            return c.ExecuteReader();
        }

        public static SQLiteDataReader fetchRangeRaces(SQLiteConnection conn, int startFrame, int endFrame, int rank) {
            SQLiteCommand c = conn.CreateCommand();
            c.CommandText = $@"select * from Races
                    where Rank = {rank}
                    and Frame >= {startFrame}
                    and Frame <= {endFrame}
                    order by Frame asc";
            return c.ExecuteReader();
        }

        public static int getSelectedRank() {
            switch(MainForm.GroupBoxRank.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text) {
                case "C":
                    return 0;
                case "B":
                    return 1;
                case "A":
                    return 2;
                case "S":
                    return 3;
            }
            return -1;
        }

        public static ulong getSelectedItemFlags() {
            ulong i = 0;
            foreach(string item in MainForm.ChecklistItems.CheckedItems) {
                i |= PRIZE_FAMILIES[item];
            }
            return i;
        }

        public static SQLiteConnection makeConnection() {
            return new SQLiteConnection($"Data Source={Settings.DatabaseFile};Version=3;");
        }

        public static void clearFramesData(FlowLayoutPanel container) {
            while(container.Controls.Count > 0) {
                container.Controls.RemoveAt(0);
            }
        }

        private static void addTextRow(TableLayoutPanel panel, string text, ContentAlignment align, int height = 20, bool bold = false, System.Single size = 10F) {
            var h = panel.Height;
            panel.Height += height;

            var label = new Label();
            label.Anchor = ((AnchorStyles) ((((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right)));
            label.AutoSize = true;
            var fontStyle = bold ? FontStyle.Bold : FontStyle.Regular;
            label.Font = new Font("Microsoft Sans Serif", size, fontStyle, GraphicsUnit.Point, ((byte) (0)));
            label.Size = new Size(194, height);
            label.Location = new Point(3, h);
            label.Text = text;
            label.TextAlign = align;

            panel.RowCount++;
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, height));
            panel.Controls.Add(label, 0, panel.RowCount - 1);
        }


        public static void putFramesData(int startFrame, int endFrame, int rank, ulong targetPrizeFlags, FlowLayoutPanel container) {
            using(var conn = makeConnection()) {
                conn.Open();
                var racesByFrame = new Dictionary<int, List<RaceData>>();
                var racesReader = fetchRangeRaces(conn, startFrame, endFrame, rank);
                try {
                    while(racesReader.Read()) {
                        var rd = new RaceData();
                        rd.rank = racesReader.GetInt32(0);
                        rd.frame = racesReader.GetInt32(1);
                        rd.teioh = racesReader.GetInt32(2);
                        rd.inputs = racesReader.GetInt32(3);
                        rd.winner = racesReader.GetInt32(4);

                        if(!racesByFrame.ContainsKey(rd.frame)) {
                            racesByFrame.Add(rd.frame, new List<RaceData>());
                        }
                        racesByFrame[rd.frame].Add(rd);
                    }
                } finally {
                    racesReader.Close();
                }
                var prizesReader = fetchRangePrizes(conn, startFrame, endFrame, rank);
                try {
                    for(int i = 0; prizesReader.Read(); i++) {
                        int frame = startFrame + i;
                        var prizeData = new PrizeData();
                        prizeData.items = new int[] {
                            prizesReader.GetInt32(2),
                            prizesReader.GetInt32(3),
                            prizesReader.GetInt32(4)
                        };
                        prizeData.tileCards = new int[] {
                            prizesReader.GetInt32(5),
                            prizesReader.GetInt32(6),
                            prizesReader.GetInt32(7),
                            prizesReader.GetInt32(8),
                            prizesReader.GetInt32(9),
                            prizesReader.GetInt32(10),
                            prizesReader.GetInt32(11),
                            prizesReader.GetInt32(12),
                            prizesReader.GetInt32(13),
                            prizesReader.GetInt32(14),
                            prizesReader.GetInt32(15),
                            prizesReader.GetInt32(16),
                            prizesReader.GetInt32(17),
                            prizesReader.GetInt32(18),
                            prizesReader.GetInt32(19)
                        };
                        prizeData.names = new int[] {
                            prizesReader.GetInt32(20),
                            prizesReader.GetInt32(21),
                            prizesReader.GetInt32(22),
                            prizesReader.GetInt32(23),
                            prizesReader.GetInt32(24)
                        };

                        var panel = new TableLayoutPanel();
                        panel.SuspendLayout();
                        container.Controls.Add(panel);
                        panel.ColumnCount = 1;
                        panel.Location = new Point(0, 0);
                        panel.Size = new Size(200, 0);

                        addTextRow(panel, $"{frame} [{rank}]", ContentAlignment.MiddleCenter, 24, true, 12);

                        addTextRow(panel, "Item Pool", ContentAlignment.MiddleCenter, 20, true, 10);
                        foreach(var prizeIndex in prizeData.items) {
                            addTextRow(panel, ITEM_NAMES[prizeIndex], ContentAlignment.MiddleLeft, 20, false, 10);
                        }

                        addTextRow(panel, "Racers", ContentAlignment.MiddleCenter, 20, true, 10);
                        foreach(var racerIndex in prizeData.names) {
                            addTextRow(panel, CHOCO_NAMES[racerIndex], ContentAlignment.MiddleLeft, 20, false, 10);
                        }

                        addTextRow(panel, "Tiles", ContentAlignment.MiddleCenter, 20, true, 10);

                        panel.ResumeLayout(true);
                        panel.SuspendLayout();

                        var tilesPanel = new TableLayoutPanel();
                        tilesPanel.SuspendLayout();
                        tilesPanel.ColumnCount = 5;
                        tilesPanel.RowCount = 3;
                        tilesPanel.Size = new Size(194, 0);
                        tilesPanel.Anchor = ((AnchorStyles) ((((AnchorStyles.Top | AnchorStyles.Bottom)
                                    | AnchorStyles.Left)
                                    | AnchorStyles.Right)));

                        for(int k = 0; k < 5; k++)
                            tilesPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

                        for(int j = 0, h = 0; j < 3; j++, h += 20) {
                            tilesPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
                            for(int k = 0, w = 3; k < 5; k++, w += 38) {
                                var l = new Label();
                                l.Anchor = ((AnchorStyles) ((((AnchorStyles.Top | AnchorStyles.Bottom)
                                    | AnchorStyles.Left)
                                    | AnchorStyles.Right)));
                                l.AutoSize = true;
                                l.Text = $"{prizeData.tileCards[j * 5 + k] + 1}";
                                l.TextAlign = ContentAlignment.MiddleCenter;
                                l.Size = new Size(32, 20);
                                l.Location = new Point(w, h);
                                tilesPanel.Controls.Add(l, k, j);
                            }
                            tilesPanel.Height += 20;
                        }

                        panel.Height += tilesPanel.Height;

                        panel.RowCount++;
                        panel.RowStyles.Add(new RowStyle());
                        panel.Controls.Add(tilesPanel, 0, panel.RowCount - 1);

                        panel.ResumeLayout(true);
                        panel.SuspendLayout();

                        addTextRow(panel, "Solutions", ContentAlignment.MiddleCenter, 20, true, 10);
                        if(racesByFrame.ContainsKey(frame)) {
                            Dictionary<int, RaceData> solutionsByPrize = new Dictionary<int, RaceData>();
                            foreach(RaceData raceData in racesByFrame[frame]) {
                                if(raceData.winner >= 2 && raceData.winner <= 6) {
                                    int racePrize = prizeData.items[prizeData.tileCards[raceData.winner - 2]];
                                    if((targetPrizeFlags & (1UL << racePrize)) != 0 && !solutionsByPrize.ContainsKey(racePrize)) {
                                        solutionsByPrize[racePrize] = raceData;
                                    }
                                }
                            }

                            foreach(int targetPrize in solutionsByPrize.Keys) {
                                RaceData raceSolution = solutionsByPrize[targetPrize];
                                addTextRow(panel, ITEM_NAMES[targetPrize], ContentAlignment.MiddleCenter, 20, false, 10);
                                addTextRow(panel, SOLUTION_STRINGS[raceSolution.inputs], ContentAlignment.MiddleLeft, 20, false, 10);
                            }
                        } else {
                            addTextRow(panel, "No Race Data", ContentAlignment.MiddleCenter, 20, false, 10);
                        }

                    }
                } finally {
                    prizesReader.Close();
                }
                conn.Close();
            }
        }
    }
}
