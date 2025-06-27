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

namespace Pomodoro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int _workTime = 10;
        public int _restTime = 5;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            //set _workTime to the value in worktxt
            //set _restTime to the value in resttxt
            //start work timer and minimize
            //when work timer is over open new form
        }

        private void worktxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            _workTime = Int32.Parse(worktxt.Text);
        }

        private void resttxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            _restTime = Int32.Parse(resttxt.Text);
        }
    }
}