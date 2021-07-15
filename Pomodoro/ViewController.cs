using System;
using System.Timers;
using AppKit;
using Foundation;

namespace Pomodoro
{
    public partial class ViewController : NSViewController
    {

        Timer MainTimer;
        int TimeLeft = 1500; // 1500 seconds is 25 minutes
        bool TimerStopped = false;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Fire the timer once a second
            MainTimer = new Timer(1000);
            MainTimer.Elapsed += (sender, e) =>
            {
                TimeLeft--;

                // Format the remaining time nicely for the label
                TimeSpan time = TimeSpan.FromSeconds(TimeLeft);
                string timeString = time.ToString(@"mm\:ss");
                InvokeOnMainThread(() =>
                {
                    // We want to interact with the UI from a different thread,
                    // so we must invoke this change on the main thread
                    TimerLabel.StringValue = timeString;
                });

                // If 25 minutes have passed
                if (TimeLeft == 0)
                {
                    // Stop the timer and reset
                    MainTimer.Stop();
                    TimeLeft = 1500;
                    InvokeOnMainThread(() =>
                    {
                        // Reset the UI
                        TimerLabel.StringValue = "25:00";
                        StartStopButton.Title = "Start";
                        ResetButton.Hidden = true;
                        NSAlert alert = new NSAlert();
                        // Set the style and message text
                        alert.AlertStyle = NSAlertStyle.Informational;
                        alert.MessageText = "25 minutes elasped! Take a 5 minute break.";
                        // Display the NSAlert from the current view
                        alert.BeginSheet(View.Window);
                    });
                }
            };
        }

        partial void StartStopButtonClicked(NSObject sender)
        {
            Console.WriteLine("StartStopButton pressed");
            // If the timer is running, we want to stop it,
            // otherwise we want to start it
            if (MainTimer.Enabled)
            {
                MainTimer.Stop();
                ResetButton.Hidden = false;
                TimerStopped = true;
                StartStopButton.Title = "Start";
            } else
            {
                MainTimer.Start();
                StartStopButton.Title = "Stop";
            }
        }

        partial void ResetButtonClicked(NSObject sender)
        {
            Console.WriteLine("ResetButton pressed");
            // If the Reset button is pressed after Stopping the timer,
            // show the Reset button and reset the timer is pressed.
            if (TimerStopped)
            {
                TimerStopped = false;
                TimeLeft = 1500;
                TimerLabel.StringValue = "25:00";
                ResetButton.Hidden = true;
            }
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
