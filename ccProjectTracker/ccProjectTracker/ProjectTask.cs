using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ccProjectTracker
{
    /// <summary>
    /// Represents a task that has a start time, end time, and a thread that keeps track of when it's running
    /// </summary>
    public class ProjectTask : IDisposable
    {
        int _roundingMinutes = 1;
        Timer _taksTimer = null;
        int _duration = 0;
        string _description = ccProjectTracker.Default.DefaultTaskDescription;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public DateTime StartTime
        {
            get;
            set;
        }
        public DateTime EndTime
        {
            get;
            set;
        }
        public int Duration
        {
            get {
                _duration = (int)((EndTime - StartTime).TotalMinutes);
                return _duration;   
            }
            set { _duration = value; }
        }
        public ProjectTask() { }
        public ProjectTask(string description)
        {
            _description = description;
        }
        /// <summary>
        /// Starts Current Task, if one has not been stared
        /// </summary>
        public void Start()
        {
            StartTime = DateTime.Now;
            EndTime = DateTime.Now.AddMinutes(_roundingMinutes);
            if (_taksTimer == null)
                _taksTimer = new Timer(TimerCallback, null, _roundingMinutes * 60 * 1000, _roundingMinutes * 60 * 1000);
        }
        /// <summary>
        /// Stops the current project task if one has been started
        /// </summary>
        public void Stop()
        {
            if (_taksTimer != null)
            {
                WaitHandle timerWait = new EventWaitHandle(false, EventResetMode.AutoReset);
                _taksTimer.Dispose(timerWait);              // block until the timer is disposed
            }
        }
        /// <summary>
        /// Fires whenever the timer gets to the next roudning period
        /// </summary>
        /// <param name="state">null</param>
        public void TimerCallback(object state)
        {
            EndTime = EndTime.AddMinutes(_roundingMinutes);
        }
        /// <summary>
        /// Disposes of the project instance.
        /// </summary>
        public void Dispose()
        {
            Stop();                     // stop the task
        }
    }
}
