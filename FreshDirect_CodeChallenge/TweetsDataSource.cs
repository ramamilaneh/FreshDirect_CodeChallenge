using System;
using UIKit;
using Foundation;
using System.Drawing;
using System.Diagnostics.Contracts;
using CoreGraphics;

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
			Contract.Ensures(Contract.Result<UITableViewCell>() != null);
			// request a recycled cell to save memory
			UITableViewCell cell = tableView.DequeueReusableCell("tweetCell");
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Default, "tweetCell");
			cell.TextLabel.Lines = 0;
			cell.TextLabel.Text = TableItems[indexPath.Row];
			cell.TextLabel.SizeToFit();
			return cell;
		}
	}

}
