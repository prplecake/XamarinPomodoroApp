// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Pomodoro
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSButton ResetButton { get; set; }

		[Outlet]
		AppKit.NSButton StartStopButton { get; set; }

		[Outlet]
		AppKit.NSTextField TimerLabel { get; set; }

		[Action ("ResetButtonClicked:")]
		partial void ResetButtonClicked (Foundation.NSObject sender);

		[Action ("StartStopButtonClicked:")]
		partial void StartStopButtonClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ResetButton != null) {
				ResetButton.Dispose ();
				ResetButton = null;
			}

			if (StartStopButton != null) {
				StartStopButton.Dispose ();
				StartStopButton = null;
			}

			if (TimerLabel != null) {
				TimerLabel.Dispose ();
				TimerLabel = null;
			}
		}
	}
}
