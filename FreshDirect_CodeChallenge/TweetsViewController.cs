using System;
using System.Diagnostics.Contracts;
using Foundation;
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
			TableView.Source = new TweetsDataSource(this);
			Console.WriteLine(tweetsOfUser.Length);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		class TweetsDataSource : UITableViewSource
		{
			TweetsViewController controller;
			public TweetsDataSource(TweetsViewController controller)
			{
				this.controller = controller;
			}

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				return controller.tweetsOfUser.Length;
			}

			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				// request a recycled cell to save memory
				UITableViewCell cell = tableView.DequeueReusableCell("tweetCell");
				// if there are no cells to reuse, create a new one
				if (cell == null)
					cell = new UITableViewCell(UITableViewCellStyle.Default, "tweetCell");
				cell.TextLabel.Text = controller.tweetsOfUser[indexPath.Row];
				return cell;
			}
		}
	}
}

