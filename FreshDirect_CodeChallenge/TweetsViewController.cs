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
		//string[] tweetsOfUser = new string[]();
		List<string> list = new List<string>();

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//Console.WriteLine(userName);
			APIClient.getTweets(userName, (jsonDic) =>
			 {
				 for (int i = 0; i < jsonDic.Length; i++)
				 {
					 list.Add((string)jsonDic[i]["text"]);
					 Console.WriteLine(list[i]);
				 }

				DispatchQueue.MainQueue.DispatchAsync(() =>
				{
                    Console.WriteLine(list.Count);
					this.TableView.Source = new TweetsDataSource(list.ToArray());
					this.TableView.ReloadData();	
				});

				//this.TableView.Source = new TweetsDataSource(list.ToArray());

			 });
			//tweetsOfUser = list.ToArray();
			//Console.WriteLine(tweetsOfUser.Length);
			//string[] names = new string[3] { "Matt", "Joanne", "Robert" };




			//Console.WriteLine(tweetsOfUser.Length);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			this.TableView.ReloadData();
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			//APIClient.getTweets(userName, (jsonDic) =>
			// {
			//	 for (int i = 0; i < jsonDic.Length; i++)
			//	 {
			//		 list.Add((string)jsonDic[i]["text"]);
			//		 Console.WriteLine(list[i]);
			//	 }
			//	 Console.WriteLine("1111");
				 
			//			 Console.WriteLine("2222");

			//			 Console.WriteLine(list.Count);
			//			 this.TableView.Source = new TweetsDataSource(list.ToArray());
			//			 this.TableView.ReloadData();
					
			//	 //this.TableView.Source = new TweetsDataSource(list.ToArray());

			// });
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}


	}
}

