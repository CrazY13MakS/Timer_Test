using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Timer_Test.Infrastructure;

namespace Timer_Test.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        Timer _timer;
        String _defaultTime;
        public MainWindowViewModel()
        {
            _timer = new Timer
            {
                Interval = 1000
            };
            _timer.Elapsed += _timer_Elapsed;
            _defaultTime = Time = OddTime = EvenTime = "00:00:00";
        }

        /// <summary>
        /// Handler for timer elapsed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Seconds > 0)
            {
                Seconds--;
                Time = TimeSpan.FromSeconds(Seconds).ToString();
                if (Seconds % 2 == 0)
                {
                    EvenTime = Time;
                }
                else
                {
                    OddTime = Time;
                }
            }
            else
            {
                _timer.Stop();
            }
        }

        private int _seconds;
        /// <summary>
        /// Value in seconds
        /// </summary>
        public int Seconds
        {
            get { return _seconds; }
            set
            {
                if (_seconds == value)
                {
                    return;
                }
                _seconds = value;
                OnPropertyChanged();
            }
        }

        private String _time;

        public String Time
        {
            get { return _time; }
            set
            {
                if (_time == value)
                {
                    return;
                }
                _time = value;
                OnPropertyChanged();
            }
        }


        private String _oddTime;
        /// <summary>
        /// Odd number
        /// </summary>
        public String OddTime
        {
            get { return _oddTime; }
            set
            {
                if (_oddTime == value)
                {
                    return;
                }
                _oddTime = value;
                OnPropertyChanged();
            }
        }
        private String _evenTime;
        /// <summary>
        /// Even number
        /// </summary>
        public String EvenTime
        {
            get { return _evenTime; }
            set
            {
                if (_evenTime == value)
                {
                    return;
                }
                _evenTime = value;
                OnPropertyChanged();
            }
        }


        RelayCommand _startTimer;
        public ICommand StartTimerCommand
        {
            get
            {
                if (_startTimer == null)
                {
                    _startTimer = new RelayCommand(ExecuteStartTimerCommand);
                }
                return _startTimer;
            }
        }
        /// <summary>
        /// Start timer command(textbox lost focus)
        /// </summary>
        /// <param name="parametr"></param>
        private void ExecuteStartTimerCommand(object parametr)
        {
            if (Seconds <= 0)
            {
                Seconds = 0;
                return;
            }
            _timer.Start();
            Time = OddTime = EvenTime = TimeSpan.FromSeconds(Seconds).ToString();
        }

        RelayCommand _pauseTimer;
        public ICommand PauseTimerCommand
        {
            get
            {
                if (_pauseTimer == null)
                {
                    _pauseTimer = new RelayCommand(ExecutePauseTimerCommand);
                }
                return _pauseTimer;
            }
        }

        /// <summary>
        /// Pause timer command (textbox got focus)
        /// </summary>
        /// <param name="parametr"></param>
        private void ExecutePauseTimerCommand(object parametr)
        {
            _timer.Stop();           
        }

    }
}
