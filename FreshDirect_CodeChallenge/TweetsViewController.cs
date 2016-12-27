using System;

using UIKit;

namespace FreshDirect_CodeChallenge
{
	public partial class TweetsViewController : UITableViewController
	{
		public TweetsViewController() : base("TweetsViewController", null)
		{
		}
		public TweetsViewController(IntPtr handle) : base (handle)
        {
		}
		public string [] tweetsOfUser { get; set; }
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Console.WriteLine(tweetsOfUser);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

