using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;

namespace Timer_Test.Model
{
    /// <summary>
    /// Countdown timer
    /// </summary>
  public  class TimerSimple :INotifyPropertyChanged
    {
        public Timer Timer { get; protected set; }

        private int _seconds;

        public int Seconds
        {
            get { return _seconds; }
            set {
                if(_seconds==value)
                {
                    return;
                }
                _seconds = value;
                OnPropertyChanged();
            }
        }
        public event EventHandler<ElapsedEventArgs> TimerElapsed;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="interval">Interval of an event call in milliseconds</param>
        public TimerSimple(double interval)
        {
            Timer = new Timer(interval);
            Timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {           
            if(Seconds<=0)
            {
                Timer.Stop();
                return;
            }
            Seconds--;
            TimerElapsed?.Invoke(this, e);
        }
        public virtual void Stop()
        {
            Timer.Stop();
        }
        public virtual void Start()
        {
            Timer.Start();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
