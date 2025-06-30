using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pomodoro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _workTime = 10;
        private int _restTime = 5;
        private int _workCounter = 0;
        public int _restCounter = 0;
        DispatcherTimer _dispatcherTimer;

        public MainWindow()
        {
            InitializeComponent();

            // Set up the NotifyIcon so the application can minimize to the system tray
            System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon(@"..\Media\Icons\Main.ico");
            notifyIcon.Visible = true;
            notifyIcon.DoubleClick += 
                delegate(object sender, EventArgs e)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };

        }

        // This method is called when the window state changes, specifically when it is minimized
        // It hides the window instead of closing it.
        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Minimized)
                this.Hide();

            base.OnStateChanged(e);
        }

        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            StartWorkTimer();
        }

        private void stopbtn_Click(object sender, RoutedEventArgs e)
        {
            StopWorkTimer();
        }

        public void StartWorkTimer()
        {
            startbtn.IsEnabled = false;
            startbtn.Visibility = Visibility.Hidden;

            stopbtn.IsEnabled = true;
            stopbtn.Visibility = Visibility.Visible;

            _workTime = Int32.Parse(worktxt.Text);
            _restTime = Int32.Parse(resttxt.Text);

            _workCounter = _workTime;
            _restCounter = _restTime;

            //start work timer and minimize
            //when work timer is over open new form
            _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(Timer_Tick);
            _dispatcherTimer.Interval = TimeSpan.FromMinutes(1);
            _dispatcherTimer.Start();

            this.WindowState = WindowState.Minimized;
        }

        public void StopWorkTimer()
        {

            startbtn.IsEnabled = true;
            startbtn.Visibility = Visibility.Visible;

            stopbtn.IsEnabled = false;
            stopbtn.Visibility = Visibility.Hidden;

            if (_dispatcherTimer != null)
            {
                _dispatcherTimer.Stop();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Logic to handle timer tick
            // This could include updating a label with the remaining time
            _workCounter--;

            if (_workCounter == 0)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"..\Media\Sounds\blip.wav");
                player.Play();
                _dispatcherTimer.Stop();

                // Open rest timer
                RestTimeWindow restTimeWindow = new RestTimeWindow(_restCounter, this);
                restTimeWindow.Owner = this;
                restTimeWindow.Show();
            }
        }
    }
}