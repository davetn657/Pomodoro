using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pomodoro
{
    /// <summary>
    /// Interaction logic for RestTimeWindow.xaml
    /// </summary>
    public partial class RestTimeWindow : Window
    {
        DispatcherTimer _dispatcherTimer;
        MainWindow _mainWindow;
        public int _restCounter = 0;
        public string _restTime { get; set; }

        public RestTimeWindow(int restTime, Window mainWindow)
        {
            _restCounter = restTime;
            _restTime = ($"0:{restTime}:0");

            _mainWindow = mainWindow as MainWindow;

            InitializeComponent();

            StartRestTimer();
        }
       

        private void Timer_Tick(object sender, EventArgs e)
        {
            _restCounter--;

            if(_restCounter == 0)
            {
                StopRestTimer();
            }
        }

        private void Esc_Key_Pressed(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                StopRestTimer();
            }
        }

        private void StartRestTimer()
        {
            _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(Timer_Tick);
            _dispatcherTimer.Interval = TimeSpan.FromMinutes(1);
            _dispatcherTimer.Start();
        }

        private void StopRestTimer()
        {
            //Play sound indicating end of rest time
            //Stop timer
            //Start Work Timer
            //Close this window
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"..\Media\Sounds\blip.wav");
            player.Play();

            _dispatcherTimer.Stop();
            _mainWindow.StartWorkTimer();

            this.Close();
        }
    }
}
