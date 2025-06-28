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
        public int _restCounter = 0;
        public string _restTime { get; set; }

        public RestTimeWindow(int restTime)
        {
            _restCounter = restTime;
            _restTime = ($"0:{restTime}:0");

            InitializeComponent();
        }
       

        private void Timer_Tick(object sender, EventArgs e)
        {
            _restCounter--;

            if(_restCounter == 0)
            {
                //Play sound indicating end of rest time
                //Stop timer
                //Start Work Timer
                //Close this window
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"..\Media\Sounds\blip.wav");
                player.Play();

                StopRestTimer();

            }
        }

        private void StartRestTimer()
        {
            _dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            _dispatcherTimer.Tick += new EventHandler(Timer_Tick);
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(1); //Change to minutes
            _dispatcherTimer.Start();
        }

        private void StopRestTimer()
        {
            _dispatcherTimer.Stop();
            this.Close();
        }

        private void tiponebtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
