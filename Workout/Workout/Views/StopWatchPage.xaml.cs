using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Workout.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StopWatchPage : ContentPage
    {
        Timer T = new System.Timers.Timer(1000);
        private static int _hours, _seconds, _minutes, _milliseconds;

        public StopWatchPage()
        {
            InitializeComponent();
            _hours = _seconds = _minutes = _milliseconds = 0;
            T.Elapsed += TimerTick;
        }

        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            IncreaseSeconds();
            ShowTime();
        }

        private void ShowTime()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                displayLblHrs.Text = _hours.ToString("00") + ":" ;
                displayLblMins.Text = _minutes.ToString("00") + ":";
                displayLblSecs.Text = _seconds.ToString("00");
                //displayLblMils.Text = _milliseconds.ToString("00");
            });
        }

        //private void IncreaseMilliSeconds()
        //{
        //    if (_milliseconds == 59)
        //    {
        //        _milliseconds = 0;
        //        IncreaseSeconds();
        //    }
        //    else
        //    {
        //        _milliseconds++;
        //    }
        //}

        private void IncreaseSeconds()
        {
            if (_seconds == 59)
            {
                _seconds = 0;
                IncreaseMinutes();
            }
            else
            {
                _seconds++;
            }
        }

        private void IncreaseMinutes()
        {
            if (_minutes == 59)
            {
                _minutes = 0;
                IncreaseHours();
            }
            else
            {
                _minutes++;
            }
        }

        private void IncreaseHours()
        {
            _hours++;
            if (_hours > 5) T.Stop();
        }

        public void OnStartButtonClicked(object sender, EventArgs args)
        {
            startBtn.IsEnabled = false;
            T.Start();
        }

        public void OnStopButtonClicked(object sender, EventArgs args)
        {
            startBtn.IsEnabled = true;
            T.Stop();
        }

        public void OnResetButtonClicked(object sender, EventArgs args)
        {
            _milliseconds = 0;
            _hours = 0;
            _seconds = 0;
            _minutes = 0;

            ShowTime();
        }
    }
}