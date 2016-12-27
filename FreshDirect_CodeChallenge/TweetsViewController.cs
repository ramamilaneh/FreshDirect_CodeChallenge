using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CoreFoundation;
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
		public string userName { get; set; }
		List<string> list = new List<string>();

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			APIClient.getTweets(userName, (jsonDic) =>
			 {
				 for (int i = 0; i < jsonDic.Length; i++)
				 {
					 list.Add((string)jsonDic[i]["text"]);
					 Console.WriteLine(list[i]);
				 }

				DispatchQueue.MainQueue.DispatchAsync(() =>
				{
					this.TableView.Source = new TweetsDataSource(list.ToArray());
					this.TableView.ReloadData();	
				});


			 });
			TableView.RowHeight = UITableView.AutomaticDimension;
			TableView.EstimatedRowHeight = 60;

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}


	}
}

