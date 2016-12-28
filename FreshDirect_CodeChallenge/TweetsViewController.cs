using System;
using System.Collections.Generic;
using CoreFoundation;
using UIKit;

namespace FreshDirect_CodeChallenge
{
	public partial class TweetsViewController : UITableViewController
	{
		public TweetsViewController() : base("TweetsViewController", null)
		{
		}
		public TweetsViewController(IntPtr handle) : base(handle)
		{
		}

		public string userName { get; set; }
		List<string> list = new List<string>();

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Make API call to get the Tweets
			APIClient.getTweets(userName, (jsonDic) =>
			 {
				// Check if there is an error, show alert message and dismiss the VC 
				if (jsonDic == null)
				 {
					DispatchQueue.MainQueue.DispatchAsync(() =>
				 {
					 var okAlertController = UIAlertController.Create("Alert", "Invalid User Name. Please go back and try again.", UIAlertControllerStyle.Alert);

					 //Add Action
						okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Cancel, (obj) =>
					 {
						 NavigationController.PopToRootViewController(true);

					 }));

					 // Present Alert
					 PresentViewController(okAlertController, true, null);
					
				 });

				 }
				// if there is no error create an array of tweets and populate the table
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
			    TableView.EstimatedRowHeight = 120;

		}

	public override void DidReceiveMemoryWarning()
	{
		base.DidReceiveMemoryWarning();
	}


}
}

