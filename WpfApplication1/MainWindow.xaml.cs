using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void SetTimeDelegate(DateTime time);
        public static DependencyProperty TimeProperty;
        private Timer myTimer;

        public MainWindow()
        {
            InitializeComponent();
            myTimer = new Timer(new TimerCallback(RefreshTime), new AutoResetEvent(false), 0, 1000);
        }

        public DateTime Time
        {
            get
            {
                return (DateTime)GetValue(TimeProperty);
            }
            set
            {
                SetValue(TimeProperty, value);
            }
        }

        static bool CalidateTimeValue(object obj)
        {
            DateTime dt = (DateTime)obj;
            if (dt.Year > 1990 && dt.Year < 2200)
            { return true; }
            return false;
        }

        static MainWindow()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.Inherits = true;
            metadata.DefaultValue = DateTime.Now;
            metadata.AffectsMeasure = true;
            metadata.PropertyChangedCallback += OnTimerPropertyChanged;
            TimeProperty = DependencyProperty.Register("Timer", typeof(DateTime), typeof(MainWindow), metadata, CalidateTimeValue);
        }

        static void OnTimerPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
        }

        private void RefreshTime(Object stateInfo)
        {
            SetTimeDelegate d = new SetTimeDelegate(SetTimeProperty);
            this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Send, d, DateTime.Now);
        }

        private void SetTimeProperty(DateTime dt)
        {
            this.Time = dt;
        }
    }
}
