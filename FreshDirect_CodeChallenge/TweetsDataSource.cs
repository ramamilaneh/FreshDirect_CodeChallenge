using System;
using UIKit;
using Foundation;

namespace FreshDirect_CodeChallenge
{
	public class TweetsDataSource : UITableViewSource
	{
		string[] TableItems;

		public TweetsDataSource( string[] items)
		{
			TableItems = items;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return TableItems.Length;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			// request a recycled cell to save memory
			UITableViewCell cell = tableView.DequeueReusableCell("tweetCell");
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Default, "tweetCell");
			cell.TextLabel.Text = TableItems[indexPath.Row];
			return cell;
		}
	}

}
