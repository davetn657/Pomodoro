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
        public int _workTime = 10;
        public int _restTime = 5;
        public int _workCounter = 0;
        public int _restCounter = 0;
        DispatcherTimer _dispatcherTimer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            //start work timer and minimize
            //when work timer is over open new form
            _workTime = Int32.Parse(worktxt.Text);
            _restTime = Int32.Parse(resttxt.Text);

            _workCounter = _workTime;
            _restCounter = _restTime;

            _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(Timer_Tick);
            _dispatcherTimer.Interval = TimeSpan.FromMinutes(1);
            _dispatcherTimer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Logic to handle timer tick
            // This could include updating a label with the remaining time
            worktxt.Text = _workCounter.ToString();
            _workCounter--;

            if (_workCounter == 0)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Projects\Pomodoro\Pomodoro\Media\Sounds\blip.wav");
                player.Play();
                _dispatcherTimer.Stop();
            }
        }
    }
}