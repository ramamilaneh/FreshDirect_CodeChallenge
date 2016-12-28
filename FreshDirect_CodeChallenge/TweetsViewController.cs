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
		public TweetsViewController(IntPtr handle) : base(handle)
		{
		}
		public string userName { get; set; }
		List<string> list = new List<string>();

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			APIClient.getTweets(userName, (jsonDic) =>
			 {
				 if (jsonDic == null)
				 {
					DispatchQueue.MainQueue.DispatchAsync(() =>
				 {
					 var okAlertController = UIAlertController.Create("Alert", "Invalid User Name. Please go back and try again.", UIAlertControllerStyle.Alert);

					 //Add Action
					 okAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

					 // Present Alert
					 this.PresentViewController(okAlertController, true, null);
				 });

                    
				 }
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

