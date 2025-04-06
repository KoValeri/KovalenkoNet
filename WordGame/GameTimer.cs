using System;
using System.Timers;

namespace WordGame
{
    public class GameTimer
    {
        private System.Timers.Timer timer;
        private int timeLimitInSeconds;
        private bool timeUp;
        private bool timerStarted;

        public bool IsTimeUp => timeUp;

        public GameTimer(int timeLimitInSeconds)
        {
            this.timeLimitInSeconds = timeLimitInSeconds;
            this.timeUp = false;
            this.timerStarted = false;

            timer = new System.Timers.Timer(timeLimitInSeconds * 1000); // Convert to milliseconds
            timer.Elapsed += TimerElapsed;
        }

        public void Start()
        {
            if (timerStarted)
            {
                Reset();
            }

            timeUp = false;
            timerStarted = true;
            timer.Start();
        }

        public void Reset()
        {
            timer.Stop();
            timer.Start();
            timeUp = false;
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            timeUp = true;
            timer.Stop(); // Stop the timer once time is up
        }
    }
}
